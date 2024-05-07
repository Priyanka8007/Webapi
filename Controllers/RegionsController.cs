using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;
using NZWalks.API.Repositories;
using System.Text.Json;

namespace NZWalks.API.Controllers
{
    //https://localhost:1234/api/regions
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;

        private readonly NZWalksDbContext dbContext;

        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;
        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper,
            ILogger<RegionsController> logger)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;

        }

        //GET ALL Regions
        //GET:https//localhost:portnumber//api/region
        [HttpGet]
        //[Authorize(Roles ="Reader,Writer")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                //throw new Exception("This is a custom Exception");
                var regionsDomain = await regionRepository.GetAllAsync();
                logger.LogInformation($"Finished GetAllRegions request with data: {JsonSerializer.Serialize(regionsDomain)}");

                var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);
                return Ok(regionsDto);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
            //logger.LogWarning("This is warning log");
            //logger.LogError("This is error log");
            // get data from database - from domain models

            //Map Domain Model to Dto
            //var regionsDto = new List<RegionDto>();
            //foreach(var regionDomain in regionsDomain)
            //{
            //	regionsDto.Add(new RegionDto()
            //	{
            //		Id = regionDomain.Id,
            //		Name = regionDomain.Name,
            //		Code = regionDomain.Code,
            //		RegionImageUrl = regionDomain.RegionImageUrl,
            //	});
            //}

            //Map domain Models To Dto By AutoMapper

        }

        //Get SINGLE REGION(Get Region By ID)
        //get:HTTPS://localhost:portnumber/api/region/{id}

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region=dbContext.Regions.Find(id);
            //get region Domain Model from Database

            var regionDomain = await regionRepository.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            //Map/convert Region Domain Model to Region DTO
            //var regionDto = new RegionDto
            //{
            //	Id = regionDomain.Id,
            //	Code = regionDomain.Code,
            //	Name = regionDomain.Name,
            //	RegionImageUrl = regionDomain.RegionImageUrl
            //}
            //;
            //return Dto back to client
            return Ok(mapper.Map<RegionDto>(regionDomain));

        }

        //post to create new Region
        //POST:https://localhost:portnumber/api/regions
        [HttpPost]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //map or convert DTO to Domain model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);
            //use Domain model to create region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDto);
        }
        //update region
        //put:https://localhost:portnumber/api/regions
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            //Map  DTO to domain model

            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
            //check if region exist
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //domain model to dto
            var RegionDto = mapper.Map<RegionDto>(regionDomainModel);
            return Ok(RegionDto);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);


            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Domain to DTO
            var RegionDto = mapper.Map<RegionDto>(regionDomainModel);
            return Ok(RegionDto);

        }
    }
}




