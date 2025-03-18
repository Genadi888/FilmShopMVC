using FilmShopMVC.Models;
using FilmShopMVC.Models.DTOs;
using FilmShopMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FilmShopMVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IHomeRepository _homeRepository;
		public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
		{
			_homeRepository = homeRepository;
			_logger = logger;
		}

		public async Task<IActionResult> Index(string sterm = "", int genreId = 0)
		{
			IEnumerable<Film> films = await _homeRepository.GetBooks(sterm, genreId);
			IEnumerable<Genre> genres = await _homeRepository.Genres();
			FilmDisplayModel filmModel = new FilmDisplayModel
			{
				Films = films,
				Genres = genres,
				STerm = sterm,
				GenreId = genreId
			};
			return View(filmModel);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}