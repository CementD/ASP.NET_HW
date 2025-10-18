using hw1310.Models;
using Microsoft.AspNetCore.Mvc;

namespace hw1310.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComputerGamesController : ControllerBase
    {
        private static List<ComputerGame> _games = new List<ComputerGame>
        {
            new ComputerGame { Id = 1, Name = "The Witcher 3", Genre = "RPG", Price = 39.99m },
            new ComputerGame { Id = 2, Name = "Minecraft", Genre = "Sandbox", Price = 19.99m },
            new ComputerGame { Id = 3, Name = "Cyberpunk 2077", Genre = "Action RPG", Price = 59.99m }
        };

        [HttpGet]
        public ActionResult<IEnumerable<ComputerGame>> GetAll()
        {
            return Ok(_games);
        }

        [HttpGet("{id}")]
        public ActionResult<ComputerGame> GetById(int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null)
                return NotFound(new { Message = $"Game with ID {id} not found" });
            return Ok(game);
        }

        [HttpPost]
        public ActionResult<ComputerGame> Create([FromBody] ComputerGame newGame)
        {
            newGame.Id = _games.Max(g => g.Id) + 1;
            _games.Add(newGame);
            return CreatedAtAction(nameof(GetById), new { id = newGame.Id }, newGame);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ComputerGame updatedGame)
        {
            var existingGame = _games.FirstOrDefault(g => g.Id == id);
            if (existingGame == null)
                return NotFound(new { Message = $"Game with ID {id} not found" });

            existingGame.Name = updatedGame.Name;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Price = updatedGame.Price;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null)
                return NotFound(new { Message = $"Game with ID {id} not found" });

            _games.Remove(game);
            return NoContent();
        }
    }
}
