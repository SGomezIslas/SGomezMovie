using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
	public class Producto
	{
        public Producto()
        {

        }
        public Producto(string nombre)
        {
            Nombre = nombre;
        }
        public int IdProducto {  get; set; }
		public string Nombre { get; set; }
		public int Precio {  get; set; }
		public byte[] Imagen { get; set; }
		public ML.Proveedor Proveedor { get; set; }
		public List<object> Productos { get; set; }


	}
}
