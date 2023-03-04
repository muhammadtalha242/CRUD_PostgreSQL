namespace CRUD_PostgreSQL.Services.SuperHeroServices
{
    public class SuperHeroService: ISuperHeroService
    {
        private static List<SuperHero> SuperHeros = new List<SuperHero> { new SuperHero { Id = 1, Name = "Spide Man", FirstName = "Peter", LastName = "Paker", Place = "New York" },
        new SuperHero { Id = 2, Name = "Spide Man1", FirstName = "Peter", LastName = "Paker", Place = "New York" },
        new SuperHero { Id = 3, Name = "Spide Man2", FirstName = "Peter", LastName = "Paker", Place = "New York" }};
        
        private readonly DataContext _context;

        public SuperHeroService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public List<SuperHero>? AddSuperHero(SuperHero superHero)
        {
               SuperHeros.Add(superHero);

            return SuperHeros;
        }

        public List<SuperHero>? DeleteSuper(int id)
        {
            var superHero = SuperHeros.Find(x => x.Id == id);
            if(superHero is null)
            {
                return null;
            }
            SuperHeros.Remove(superHero);
            return SuperHeros;

        }

        public SuperHero? GetSuperHero(int id)
        {
            var superHero = SuperHeros.Find(x => x.Id == id);
            if (superHero is null)
            {
                return null;
            }
            return superHero;
        }

        public async Task<List<SuperHero>> GetSuperHeros()
        {

            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;

        }

        public List<SuperHero>? UpdateSuperHero(int id, SuperHero superHero)
        {
            var _superHero = SuperHeros.Find(x => x.Id == id);
            if (superHero is null)
            {
                return null;
            }
            SuperHeros.Remove(_superHero);
            SuperHeros.Add(superHero);
            return SuperHeros;
        }
    }
}
