using AutoMapper;
using CharacterCreator.Data;
using CharacterCreator.Dtos;
using CharacterCreator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CharacterCreator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationshipController : Controller
    {
        private readonly IRelationShipRepository _repository;
        private readonly IMapper _mapper;
        public RelationshipController(IRelationShipRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<RelationshipDto>))]
        public IActionResult GetRelationships()
        {
            var relationships = _repository.GetRelationships();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var relatinshipMap = _mapper.Map<List<RelationshipDto>>(relationships);
            return Ok(relatinshipMap);
        }

        [HttpGet("{relationshipId}")]
        [ProducesResponseType(200, Type = typeof(RelationshipDto))]
        public IActionResult GetRelationship(int relationshipId)
        {
            var exists = _repository.RelationshipExists(relationshipId);

            if (!exists)
                return NotFound();
            
            var relationship = _repository.GetRelationship(relationshipId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var relationshipMap = _mapper.Map<RelationshipDto>(relationship);
            return Ok(relationshipMap);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRelationship([FromBody] RelationshipAddEditDto relationshipCreate)
        {
            if (relationshipCreate == null)
                return BadRequest(ModelState);
            
            var relationship = _repository.GetRelationships()
                .Where(x => x.FirstCharacterId == relationshipCreate.FirstCharacterId && x.SecondCharacterId == relationshipCreate.SecondCharacterId)
                .FirstOrDefault();
            if (relationship != null)
            {
                ModelState.AddModelError("", "These characters already have a defined relationship!");
                return StatusCode(500, ModelState);
            }

            var relatinshipMap = _mapper.Map<Relationship>(relationshipCreate);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (!_repository.CreateRelationship(relatinshipMap))
            {
                ModelState.AddModelError("", "Something went wrong while creating.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created!");
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRelationship([FromBody] RelationshipAddEditDto relationshipUpdate)
        {
            if (relationshipUpdate == null)
                return BadRequest(ModelState);
            
            if (!_repository.RelationshipExists(relationshipUpdate.Id))
                return BadRequest(ModelState);
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var relationshipMap = _mapper.Map<Relationship>(relationshipUpdate);

            if (!_repository.UpdateRelationship(relationshipMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Updated!");
        }

        [HttpDelete("{relationshipId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRelationship(int relationshipId)
        {
            if (!_repository.RelationshipExists(relationshipId))
                return BadRequest(ModelState);
            
            var relationshipToDelete = _repository.GetRelationship(relationshipId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (!_repository.DeleteRelationship(relationshipToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}