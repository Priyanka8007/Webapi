using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;
using static System.Net.WebRequestMethods;

namespace NZWalks.API.Data
{
	public class NZWalksDbContext :DbContext
	{
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions):base(dbContextOptions)
        {
                
        }
        public DbSet<Difficulty> Difficulties { set; get; }
        public DbSet<Region> Regions { set; get; }
        public DbSet<Walk> Walks { set; get; }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed for difficulties
            //Easy Medium Hard

            var difficulties = new List<Difficulty>()
            {
               
                  new Difficulty()
                {
                    Id=Guid.Parse("d09f585f-8792-49f5-9401-d8a03d1dc379"),
                    Name="Easy"
                },
                     new Difficulty()
                {
                    Id=Guid.Parse("7b2a2ef9-4f0f-4685-91b8-00b27251c609"),
                    Name="Medium"
                },

                      new Difficulty()
                {
                    Id=Guid.Parse("540f0e75-ffc1-42b2-bda0-d8bac6ca0367"),
                    Name="Hard"
                },
            };
            //seed difficulties to database 

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            var regions = new List<Region>()
            {
                new Region
                {
                    Id=Guid.Parse("3d0e7a41-91f1-4aea-99f5-b7182d858c87"),
                    Code="AKL",
                    Name="Aukland",
                    RegionImageUrl="https://tse4.mm.bing.net/th?id=OIP.GbvnlvwTocdjfHI6sCfzcgHaE8&pid=Api&P=0&h=180.jpg"

                },

                 new Region
                {
                    Id=Guid.Parse("b05d04d2-2f6e-43d2-bbcd-0ec2db15bdc0"),
                    Code="WDL",
                    Name="Welligton",
                    RegionImageUrl="https://mediaim.expedia.com/destination/1/e34399c39d76167d8fead4e03a9efd2f.jpg"

                },

                   new Region
                {
                    Id=Guid.Parse("cc654047-0e86-4f39-95fd-433d794192ae"),
                    Code="BPL",
                    Name="Bay Of Plenty",
                    RegionImageUrl="https://tse4.mm.bing.net/th?id=OIP.4OOoGfJ50A-r_b5MWsgi0gHaE8&pid=Api&P=0&h=180.jpg"

                },

                     new Region
                {
                    Id=Guid.Parse("b6f3a6f0-5226-4ff9-b2a0-14fb89f749cb"),
                    Code="STL",
                    Name="SouthLand",
                    RegionImageUrl="http://www.lasty.com.pl/region/large/1/RAUNZ/region-auckland.JPG"

                      },

                  
            };

            modelBuilder.Entity<Region>().HasData(regions);


        }

    }
}
