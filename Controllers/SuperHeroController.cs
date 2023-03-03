using CRUD_PostgreSQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_PostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> SuperHeros = new List<SuperHero> { new SuperHero { Id = 1, Name = "Spide Man", FirstName = "Peter", LastName = "Paker", Place = "New York" },
        new SuperHero { Id = 2, Name = "Spide Man1", FirstName = "Peter", LastName = "Paker", Place = "New York" },
        new SuperHero { Id = 3, Name = "Spide Man2", FirstName = "Peter", LastName = "Paker", Place = "New York" }};

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeros()
        {
            return Ok(SuperHeros);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHero(int id)
        {

            var superHero = SuperHeros.Find(x => x.Id == id);
            if (superHero == null)
            {
                return NotFound("Resource not found");
            }
            return Ok(superHero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddSuperHero(SuperHero superHero)
        {
            SuperHeros.Add(superHero);
            return Ok(SuperHeros);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateSuperHero(int id,SuperHero superHero)
        {
            var _superHero = SuperHeros.Find(x => x.Id == id);
            SuperHeros.Remove(_superHero);
            SuperHeros.Add(superHero);
            return Ok(SuperHeros);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuper (int id)
        {
            var superHero = SuperHeros.Find(x => x.Id == id);
            SuperHeros.Remove(superHero);
            return Ok(SuperHeros);
        }

    }
}
