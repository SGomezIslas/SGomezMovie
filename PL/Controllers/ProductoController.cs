using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
	public class ProductoController : Controller
	{
        public IActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto("");
            Dictionary<string, object> result = BL.Producto.GetAll(producto);
            producto = (ML.Producto)result["Producto"];
            return View(producto);
        }
        public byte[] ConvertToBytes(IFormFile foto)
        {
            using var fileStream = foto.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }
        public IActionResult Index()
		{
			return View();
		}
	}
}
