using CRUD_PostgreSQL.Services.SuperHeroServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_PostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _SuperHeroService;

        public SuperHeroController(ISuperHeroService superHeroService) 
        {
            _SuperHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeros()
        {
            var superHeros = await _SuperHeroService.GetSuperHeros();
            if(superHeros is null) { NotFound("No Result Found"); }
            return Ok(superHeros);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHero(int id)
        {

            var superHero = _SuperHeroService.GetSuperHero(id);
            if (superHero == null)
            {
                return NotFound("Resource not found");
            }
            return Ok(superHero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddSuperHero(SuperHero superHero)
        {
            var superHeroService = _SuperHeroService.AddSuperHero(superHero);
            return Ok(superHeroService);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateSuperHero(int id,SuperHero superHero)
        {
            var superHeros = _SuperHeroService.UpdateSuperHero(id, superHero);
            if (superHeros == null)
            {
                return NotFound("Resource not found");
            }
            return Ok(superHeros);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero (int id)
        {
            var superHeros = _SuperHeroService.DeleteSuper(id);
            if(superHeros is null)
            {
                return NotFound("Resource not found");
            }
            return Ok(superHeros);
        }

    }
}
