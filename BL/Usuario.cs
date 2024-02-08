using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BL
{
    public class Usuario
    {
        public static Dictionary<string, object>Add(ML.Usuario usuario) 
        {
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", exepcion }, { "Resultado", false } };

            try
            {
                using (DL.SgomezMovieContext context = new DL.SgomezMovieContext())
                {
                    int filasAfectadas = context.Database.ExecuteSqlRaw($"UsuarioAdd '{usuario.Nombre}', '{usuario.ApellidoPaterno}','{usuario.ApellidoMaterno}','{usuario.UserName}','{usuario.Email}',{usuario.Password}");

                    if(filasAfectadas > 0 )
                    {
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                    else
                    { 
                    }
                }
            }
            catch (Exception ex) 
            {
                diccionario["Resultado"] = false;
                diccionario["Exepcion"] = ex.Message;
            }
            return diccionario;
        }
        //public Dictionary<string, object> GetByEmail(ML.Usuario usuario)
        //{
        //    string exepcion = "";
        //    Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Usuario", null },{ "Exepcion", exepcion }, { "Resultado", false } };

        //    try
        //    {
        //        using ( DL.SgomezMovieContext context = new DL.SgomezMovieContext())
        //        {
        //            var objeto = context.Database.ExecuteSqlRaw($"GetByEmail {usuario.Email}");
        //        }
        //    }


        //    return diccionario;
        //}
    }
}
