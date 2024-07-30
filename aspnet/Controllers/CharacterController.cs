using CharacterCreator.Data;
using CharacterCreator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : Controller
    {
        private readonly ICharacterRepository _repository;
        public CharacterController(ICharacterRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Character>))]
        public IActionResult GetCharacters()
        {
            var characters = _repository.GetCharacters();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(characters);
        }
    }
}