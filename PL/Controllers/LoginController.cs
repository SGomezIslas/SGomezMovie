using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
	public class LoginController : Controller
	{
		public ActionResult Form(ML.Usuario usuario)
		{
				Dictionary<string, object> result = BL.Usuario.Add(usuario);

				bool resultado = (bool)result["Resultado"];
				if (resultado)
				{
					ViewBag.Mensaje = "El Usuario ha sido insertado";
					return PartialView("Modal");
				}
				else
				{
					string exepcion = (string)result["Exepcion"];
					ViewBag.Mensaje = "El Usuario no se pudo registrar " + exepcion;
					return PartialView("Modal");
				}
				return View(usuario);
			
		}
		public IActionResult Login()
		{
			return View();
		}
	}
}
