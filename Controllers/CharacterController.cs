using dotnet_rpg_nd.Dtos.Character;
using dotnet_rpg_nd.Models;
using dotnet_rpg_nd.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace dotnet_rpg_nd.Controllers
{

    public class CharacterController: ControllerBase
    {
       /* private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{Id=1,Name = "Sam"}
        };*/

        public readonly ICharacterService _characterService; //field

        //constructor below and we have also injected our Icharacterservice into our controller
        public CharacterController(ICharacterService characterService)  
        {
            _characterService = characterService;
        }

        [HttpGet("GetAllCharacters")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            // return OK(Knight);
            return await _characterService.GetAllCharacters();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {
            // return OK(Knight);
            return await _characterService.GetCharacter(id);
        }

        [HttpPost("AddCharacter")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
           
            return await _characterService.AddCharacter(newCharacter);
        }

        [HttpPut("UpdateCharacter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("DeleteCharacter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


    }
}
