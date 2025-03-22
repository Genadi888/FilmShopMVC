﻿
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace FilmShopMVC.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Genre>> Genres()
        {
            return await _db.Genres.ToListAsync();
        }
        public async Task<IEnumerable<Film>> GetFilms(string sTerm="", int genreId=0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Film> films = await (from film in _db.Films
                         join genre in _db.Genres
                         on film.GenreId equals genre.Id
                         join stock in _db.Stocks
                         on film.Id equals stock.FilmId
                         into book_stocks
                         from bookWithStock in book_stocks.DefaultIfEmpty()
                         where string.IsNullOrWhiteSpace(sTerm) || (film!= null && film.FilmName.ToLower().StartsWith(sTerm)) 
                         select new Film()
                         {
                             Id = film.Id,
                             Image = film.Image,
                             DirectorName = film.DirectorName,
                             FilmName = film.FilmName,
                             GenreId = film.GenreId,
                             Price = film.Price,
                             GenreName = genre.GenreName,
							 Quantity = bookWithStock == null ? 0 : bookWithStock.Quantity
						 }
                         ).ToListAsync();
            if (genreId > 0)
            {
                films = films.Where(a => a.GenreId == genreId).ToList();
            }
            return films;
        }
        
    }
}
