using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PL.Models;
using System.Net;
using System.Text.Json.Nodes;

namespace PL.Controllers
{
	public class MovieController : Controller
	{
		[HttpGet]
		public ActionResult Movie()//populares
		{
			Models.Movie movie = new Models.Movie();
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
				var responseTask = client.GetAsync("movie/popular?api_key=256b3beddca78091baffffb89a8036fa");
				responseTask.Wait();
				var respuesta = responseTask.Result;
				if (respuesta.IsSuccessStatusCode)
				{
					var readTask = respuesta.Content.ReadAsStringAsync();
					responseTask.Wait();
					movie.Movies = new List<object>();
					dynamic JsonObject = JObject.Parse(readTask.Result);

					foreach (var registro in JsonObject.results)
					{
						Models.Movie movieobj = new Models.Movie();
						movieobj.IdMovie = registro.id;
						movieobj.Nombre = registro.original_title;
						movieobj.Poster = "https://image.tmdb.org/t/p/w1280/" + registro.poster_path;
						movieobj.Descripcion = registro.overview;
						movie.Movies.Add(movieobj);
					}
				}
				else
				{
					return View(movie);
				}
			}
			return View(movie);
		}
		[HttpPost]
		public IActionResult AgregarFavorito(int idPelicula)
		{
			Models.Movie movie = new Models.Movie();
			movie.IdMovie = idPelicula;
			using (HttpClient client = new HttpClient())
			{
				var objetoAnonimo = new { mediaType="movie", mediaId=idPelicula, favorite= true};
				client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
				var responseTask = client.PostAsJsonAsync("account/609681/favorite?api_key=256b3beddca78091baffffb89a8036fa&session_id=22d73f7d23b3fb4d9181507cc77be7056c469dc9", objetoAnonimo);
				responseTask.Wait();
				var respuesta = responseTask.Result;
				if (respuesta.IsSuccessStatusCode)
				{
					var readTask = respuesta.Content.ReadAsAsync<Dictionary<string, object>>();
					readTask.Wait();
				}
				else
				{
				}
			}
			return View();
		}
	}
}
