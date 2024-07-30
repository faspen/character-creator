using AutoMapper;
using CharacterCreator.Data;
using CharacterCreator.Dtos;
using CharacterCreator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : Controller
    {
        private readonly ICharacterRepository _repository;
        private readonly IMapper _mapper;
        public CharacterController(ICharacterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<CharacterDto>))]
        public IActionResult GetCharacters()
        {
            var characters = _repository.GetCharacters();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var charactersMap = _mapper.Map<List<CharacterDto>>(characters);
            return Ok(charactersMap);
        }

        [HttpGet("{characterId}")]
        [ProducesResponseType(200, Type = typeof(CharacterDto))]
        public IActionResult GetCharacter(int characterId)
        {
            var exists = _repository.CharacterExists(characterId);

            if (!exists)
                return NotFound();

            var character = _repository.GetCharacter(characterId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var characterMap = _mapper.Map<CharacterDto>(character);
            return Ok(characterMap);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCharacter([FromBody] CharacterAddEditDto characterCreate)
        {
            if (characterCreate == null)
                return BadRequest(ModelState);
            
            var character = _repository.GetCharacters()
                .Where(x => x.FirstName.Trim().ToLower() == characterCreate.FirstName.Trim().ToLower() && x.LastName.Trim().ToLower() == characterCreate.LastName.Trim().ToLower())
                .FirstOrDefault();
            if (character != null)
            {
                ModelState.AddModelError("", "Character already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var characterMap = _mapper.Map<Character>(characterCreate);
            
            if (!_repository.CreateCharacter(characterMap))
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
        public IActionResult UpdateCharacter([FromBody] CharacterAddEditDto characterUpdate)
        {
            if (characterUpdate == null)
                return BadRequest(ModelState);

            if (!_repository.CharacterExists(characterUpdate.Id))
                return BadRequest(ModelState);
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var characterMap = _mapper.Map<Character>(characterUpdate);

            if (!_repository.UpdateCharacter(characterMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Updated!");
        }

        [HttpDelete("{characterId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCharacter(int characterId)
        {
            if (!_repository.CharacterExists(characterId))
                return BadRequest(ModelState);
            
            var characterToDelete = _repository.GetCharacter(characterId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (!_repository.DeleteCharacter(characterToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}