using _20230126;
using System.Data.SqlClient;

namespace Clase12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Producto> productos = ManejadorProducto.ObtenerProductos();


            Producto producto = new Producto();

            producto.Descripciones = "Pantalon Jean Negro";
            producto.Costo = 9000;
            producto.PrecioVenta = 12000;
            producto.Stock = 99;
            producto.IdUsuario = 2;

            if (ManejadorProducto.InsertarProducto(Producto) >= 1)
            {
                Console.WriteLine("Producto Insertado");

            } else
            { Console.WriteLine("No se pudo insertar el Prducto")}
        }
    }
 }