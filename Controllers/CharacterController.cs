using dotnet_rpg_nd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace dotnet_rpg_nd.Controllers
{

    public class CharacterController: ControllerBase
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{Id=1,Name = "Sam"}
        };

        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get()
        {
            // return OK(Knight);
            return characters;
        }
        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id)
        {
            // return OK(Knight);
            return characters.FirstOrDefault(c => c.Id == id);
        }

        [HttpPost("AddCharacter")]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }
    }
}
