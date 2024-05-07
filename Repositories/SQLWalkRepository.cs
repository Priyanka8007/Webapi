using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;
        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingwalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id==id);
            if(existingwalk == null)
            {
                return null;
            }
            dbContext.Walks.Remove(existingwalk);
            await dbContext.SaveChangesAsync();
            return existingwalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filteron = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            //return  await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();

            // var walks = dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            var walks = dbContext.Walks.AsQueryable();

            //FILTERING

            if (string.IsNullOrWhiteSpace(filteron)==false&&(string.IsNullOrWhiteSpace(filterQuery)==false))
            {
                if(filteron.Equals("Name",StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(X => X.Name.Contains(filterQuery));
                }
            }

            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }

                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }

            }
            //var skipResult = (pageNumber - 1) * pageSize;
            //walks = walks.Skip(skipResult).Take(pageSize);

            return await walks.ToListAsync();

        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
        
            return await dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == id);
            
            
           
        
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
           var existingwalk=await  dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if(existingwalk==null)
            {
                return null; 
            }
            existingwalk.Name = walk.Name;
            existingwalk.LengthInKm = walk.LengthInKm;
            existingwalk.Discription = walk.Discription;
            existingwalk.WalkImageUrl = walk.WalkImageUrl;
            existingwalk.DifficultyId = walk.DifficultyId;
            existingwalk.RegionId = walk.RegionId;

            await dbContext.SaveChangesAsync();

            return existingwalk;




        }
    }
}
