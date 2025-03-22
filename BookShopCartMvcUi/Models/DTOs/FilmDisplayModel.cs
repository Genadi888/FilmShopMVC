namespace FilmShopMVC.Models.DTOs
{
    public class FilmDisplayModel
    {
        public IEnumerable<Film> Films { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string STerm { get; set; } ="";
        public int GenreId { get; set; } =0;
    }
}
