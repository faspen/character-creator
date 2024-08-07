using AutoMapper;
using CharacterCreator.Data;
using CharacterCreator.Dtos;
using CharacterCreator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactionController : Controller
    {
        private readonly IFactionRepository _repository;
        private readonly IMapper _mapper;
        
        public FactionController(IFactionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<FactionDto>))]
        public IActionResult GetFactions()
        {
            var factions = _repository.GetFactions();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var factionsMap = _mapper.Map<List<FactionDto>>(factions);
            return Ok(factionsMap);
        }

        [HttpGet("{factionId}")]
        [ProducesResponseType(200, Type = typeof(FactionDto))]
        public IActionResult GetFaction(int factionId)
        {
            var exists = _repository.FactionExists(factionId);

            if (!exists)
                return NotFound();

            var faction = _repository.GetFaction(factionId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var factionMap = _mapper.Map<FactionDto>(faction);
            return Ok(factionMap);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateFaction([FromBody] FactionAddEditDto factionCreate)
        {
            if (factionCreate == null)
                return BadRequest(ModelState);
            
            var faction = _repository.GetFactions()
                .Where(x => x.Name.Trim().ToLower() == factionCreate.Name.Trim().ToLower())
                .FirstOrDefault();
            if (faction != null)
            {
                ModelState.AddModelError("", "Faction already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var factionMap = _mapper.Map<Faction>(factionCreate);
            
            if (!_repository.CreateFaction(factionMap))
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
        public IActionResult UpdateFaction([FromBody] FactionAddEditDto factionUpdate)
        {
            if (factionUpdate == null)
                return BadRequest(ModelState);

            if (!_repository.FactionExists(factionUpdate.Id))
                return BadRequest(ModelState);
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var factionMap = _mapper.Map<Faction>(factionUpdate);

            if (!_repository.UpdateFaction(factionMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Updated!");
        }

        [HttpDelete("{factionId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteFaction(int factionId)
        {
            if (!_repository.FactionExists(factionId))
                return BadRequest(ModelState);
            
            var factionToDelete = _repository.GetFaction(factionId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (!_repository.DeleteFaction(factionToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}