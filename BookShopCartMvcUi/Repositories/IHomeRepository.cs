namespace FilmShopMVC
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Film>> GetFilms(string sTerm ="", int genreId = 0);
        Task<IEnumerable<Genre>> Genres();
    }
}