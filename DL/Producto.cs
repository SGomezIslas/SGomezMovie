using System;
using System.Collections.Generic;

namespace DL;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public int? Precio { get; set; }

    public int? IdProveedor { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }
}
