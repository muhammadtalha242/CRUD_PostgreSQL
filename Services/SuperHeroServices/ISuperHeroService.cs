namespace CRUD_PostgreSQL.Services.SuperHeroServices
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetSuperHeros();
        SuperHero? GetSuperHero(int id);
        List<SuperHero>? AddSuperHero(SuperHero superHero);
        List<SuperHero>? UpdateSuperHero(int id, SuperHero superHero);
        List<SuperHero>? DeleteSuper(int id);

    }
}
