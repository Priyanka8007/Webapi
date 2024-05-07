using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.Dto;
using NZWalks.API.Repositories;
using System.Runtime.CompilerServices;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        [HttpPost]
        [ValidateModelAttribute]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //map Dto to domain model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                
            // Process the valid model
            return Ok("Model is valid");
            var WalkDomainModel = mapper.Map<Walk>(addWalkRequestDto);
            WalkDomainModel = await walkRepository.CreateAsync(WalkDomainModel);
            var walkDto = mapper.Map<AddWalkRequestDto>(WalkDomainModel);
            return Ok(walkDto);
        }
        //HttpGet:api/walks?filteron=Name&filterQuery=Track
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filteron, [FromQuery]string ? filterQuery, [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize=1000)
        {
            var walkDomainModel = await walkRepository.GetAllAsync(filteron, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            //create an exception for checking Global Exception
            throw new Exception("This exception is manually generated for checking Gloabal Exception Handler");
            //Map Domain to Dto
            var walkDto = mapper.Map<List<WalkDto>>(walkDomainModel);
            return Ok(walkDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            //map model to dto
            var walkDto = mapper.Map<WalkDto>(walkDomainModel);
            return Ok(walkDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,UpdateWalkRequestDto updateWalkRequestDto)
        {
            //map dtos to model
            var WalkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);
            WalkDomainModel = await walkRepository.UpdateAsync(id, WalkDomainModel);
            if(WalkDomainModel==null)
            {
                return NotFound();
            }
            //Model to DTOS
            var walkDto = mapper.Map<WalkDto>(WalkDomainModel);
            return Ok(walkDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.DeleteAsync(id);


            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Domain to DTO
            var WalkDto = mapper.Map<WalkDto>(walkDomainModel);
            return Ok(WalkDto);

        }
    }
}
