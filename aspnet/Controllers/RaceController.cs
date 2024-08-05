using AutoMapper;
using CharacterCreator.Data;
using CharacterCreator.Dtos;
using CharacterCreator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : Controller
    {
        private readonly IRaceRepository _repository;
        private readonly IMapper _mapper;

        public RaceController(IRaceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<RaceDto>))]
        public IActionResult GetRaces()
        {
            var races = _repository.GetRaces();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var racesMap = _mapper.Map<List<RaceDto>>(races);
            return Ok(racesMap);
        }

        [HttpGet("{raceId}")]
        [ProducesResponseType(200, Type = typeof(RaceDto))]
        public IActionResult GetRace(int raceId)
        {
            var exists = _repository.RaceExists(raceId);

            if (!exists)
                return NotFound();
            
            var race = _repository.GetRace(raceId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var raceMap = _mapper.Map<RaceDto>(race);
            return Ok(raceMap);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRace([FromBody] RaceAddEditDto raceCreate)
        {
            if (raceCreate == null)
                return BadRequest(ModelState);
            
            var race = _repository.GetRaces()
                .Where(x => x.Name.Trim().ToLower() == raceCreate.Name.Trim().ToLower())
                .FirstOrDefault();
            if (race != null) {
                ModelState.AddModelError("", "Race already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var raceMap = _mapper.Map<Race>(raceCreate);

            if (!_repository.CreateRace(raceMap))
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
        public IActionResult UpdateRace([FromBody] RaceAddEditDto raceUpdate)
        {
            if (raceUpdate == null)
                return BadRequest(ModelState);
            if (!_repository.RaceExists(raceUpdate.Id))
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var raceMap = _mapper.Map<Race>(raceUpdate);

            if (!_repository.UpdateRace(raceMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Updated!");
        }

        [HttpDelete("{raceId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRace(int raceId)
        {
            if (!_repository.RaceExists(raceId))
                return BadRequest(ModelState);
            
            var raceToDelete = _repository.GetRace(raceId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_repository.DeleteRace(raceToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}