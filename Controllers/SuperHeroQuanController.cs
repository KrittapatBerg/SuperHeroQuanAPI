using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroQuanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroQuanController : ControllerBase
    {
        private static List<SuperHeroQuan> heroes = new List<SuperHeroQuan>
            {
                new SuperHeroQuan {
                    Id = 1,
                    Name = "Black Panther",
                    FirstName = "King T'Challa",
                    LastName = "-",
                    Location = "Wakanda"
                },

                new SuperHeroQuan
                {
                    Id = 2,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Location = "Queens, NY"
                },

                new SuperHeroQuan
                {
                    Id = 3,
                    Name = "Captain America",
                    FirstName = "Steve",
                    LastName = "Rogers",
                    Location = "Brooklyn, NY"
                }

            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroQuan>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<SuperHeroQuan>> Get(int Id)
        {
            var hero = heroes.Find(h => h.Id == Id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHeroQuan>>> AddHero(SuperHeroQuan hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHeroQuan>>> UpdateHero(SuperHeroQuan request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
                return BadRequest("Hero not found.");
            
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Location = request.Location;

            return Ok(hero); 
        }

        [HttpDelete]
        public async Task<ActionResult<List<SuperHeroQuan>>> Delete(int Id)
        {
            var hero = heroes.Find(h => h.Id == Id);
            if (hero == null)
                return BadRequest("Hero not found.");
            
            heroes.Remove(hero);
            return Ok(heroes);
        }
    }
}
