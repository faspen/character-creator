using AutoMapper;
using CharacterCreator.Data;
using CharacterCreator.Dtos;
using CharacterCreator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly ILocationRepository _repository;
        private readonly IMapper _mapper;
        
        public LocationController(ILocationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<LocationDto>))]
        public IActionResult GetLocations()
        {
            var locations = _repository.GetLocations();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var locationsMap = _mapper.Map<List<LocationDto>>(locations);
            return Ok(locationsMap);
        }

        [HttpGet("{locationId}")]
        [ProducesResponseType(200, Type = typeof(LocationDto))]
        public IActionResult GetLocation(int locationId)
        {
            var exists = _repository.LocationExists(locationId);

            if (!exists)
                return NotFound();

            var location = _repository.GetLocation(locationId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var locationMap = _mapper.Map<LocationDto>(location);
            return Ok(locationMap);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateLocation([FromBody] LocationAddEditDto locationCreate)
        {
            if (locationCreate == null)
                return BadRequest(ModelState);
            
            var location = _repository.GetLocations()
                .Where(x => x.Name.Trim().ToLower() == locationCreate.Name.Trim().ToLower())
                .FirstOrDefault();
            if (location != null)
            {
                ModelState.AddModelError("", "Location already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var locationMap = _mapper.Map<Location>(locationCreate);
            
            if (!_repository.CreateLocation(locationMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created!");
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateLocation([FromBody] LocationAddEditDto locationUpdate)
        {
            if (locationUpdate == null)
                return BadRequest(ModelState);

            if (!_repository.LocationExists(locationUpdate.Id))
                return BadRequest(ModelState);
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var locationMap = _mapper.Map<Location>(locationUpdate);

            if (!_repository.UpdateLocation(locationMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Updated!");
        }

        [HttpDelete("{locationId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteLocation(int locationId)
        {
            if (!_repository.LocationExists(locationId))
                return BadRequest(ModelState);
            
            var locationToDelete = _repository.GetLocation(locationId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (!_repository.DeleteLocation(locationToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}