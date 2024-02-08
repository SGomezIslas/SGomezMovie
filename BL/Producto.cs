using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class Producto
	{
        public static Dictionary<string, object> GetAll(ML.Producto producto)
        {
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", "" }, { "Resultado", false }, { "Producto", null } };
            try
            {
                using (DL.SgomezMovieContext context = new DL.SgomezMovieContext())
                {
                    //Entity Framework
                    //FromSqlRaw--joins
                    //var registrosLinq = context.Usuarios.ToList();
                    //LINQ

                    var registros = (from productoo in context.Productos
                                         //join Proveedor in context.Proveedors on productoo.IdProveedor equals Proveedor.IdProveedor
                                         //join Departamento in context.Departamentos on productoo.IdDepartamento equals Departamento.IdDepartamento
                                     select new
                                     {
                                         IdProducto = productoo.IdProducto,
                                         Nombre = productoo.Nombre,
                                         Precio = productoo.Precio,
                                         //IdProveedor = Proveedor.IdProveedor,
                                         //IdDepartamento = Departamento.IdDepartamento,
                                         Imagen = productoo.Imagen,

                                     }).ToList();
                    if (registros.Count > 0)
                    {
                        producto.Productos = new List<object>();
                        foreach (var prodNew in registros)
                        {
                            ML.Producto prod = new ML.Producto();
                            prod.IdProducto = prodNew.IdProducto;
                            prod.Nombre = prodNew.Nombre;
                            prod.Precio = (int)prodNew.Precio;
                            //prod.proveedor = new ML.Proveedor();
                            //prod.proveedor.IdProveedor = prodNew.IdProveedor;
                            //prod.departamento = new ML.Departamento();
                            //prod.departamento.IdDepartamento = prodNew.IdDepartamento;
                            prod.Imagen = prodNew.Imagen;

                            producto.Productos.Add(prod);
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Producto"] = producto;
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                diccionario["Exepcion"] = ex;
            }
            return diccionario;
        }
    }
}
