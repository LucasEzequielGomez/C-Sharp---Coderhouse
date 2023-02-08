using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230126
{
    internal static class ManejadorProducto
    {
        public static string cadenaConexion = "Data Source=LAPTOP-82KIARTT\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<Producto> ObtenerProductos()
        {
            List<Producto> Productos = new List<Producto>();
            using  (SqlConnection conn = new SqlConnection())
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto", conn);
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows())
                {

                    while (reader.Read())
                    {
                        Producto productoTemporal = new Producto();
                        productoTemporal.Id = reader.GetInt64(0);
                        productoTemporal.Descripciones = reader.GetString(1);
                        productoTemporal.Costo = reader.GetDecimal(2);
                        productoTemporal.PrecioVenta = reader.GetDecimal(3);
                        productoTemporal.Stock = reader.GetInt32(4);
                        productoTemporal.IdUsuario = reader.GetInt64(5);

                        Productos.Add(productoTemporal);

                    }
                }
                return Productos;
            }
        }

        public static Producto ObtenerProducto(string descripciones)
        {
            Producto producto = new Producto();

            using (SqlConnection conn = new SqlConnection())
            {
                //Primera opcion para crear un comando con parametros
                SqlCommand comando = new SqlCommand($"SELECT * FROM Producto WHERE Descripciones='{descripciones}' ", conn);

                //Segunda opcion para crear un comando con parametros
                SqlCommand comando2 = new SqlCommand("SELECT * FROM Producto WHERE Descripciones=@descripciones", conn);

                //Tercera opción
                comando2.Parameters.AddWithValue("@descripciones", descripciones);

                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    producto.Id = reader.GetInt64(0);
                    producto.Descripciones = reader.GetString(1);
                    producto.Costo = reader.GetDecimal(2);
                    producto.PrecioVenta = reader.GetDecimal(3);
                    producto.Stock = reader.GetInt32(4);
                    producto.IdUsuario = reader.GetInt64(5);

                }
            }
            return producto;

        }

        public static int InsertarProducto(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("INSERT INTO Producto(Descripciones, Costo, PrecioVenta, Stock, IdUsuario)" +
                    "VALUES(@descripciones, @costo, @precioVenta, @stock, @idUsuario)", conn);
                comando.Parameters.AddWithValue("@descripciones", producto.Descripciones);
                comando.Parameters.AddWithValue("@costo", producto.Costo);
                comando.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                comando.Parameters.AddWithValue("@stock", producto.Stock);
                comando.Parameters.AddWithValue("@idUsuario", producto.IdUsuario);

                conn.Open();
                return comando.ExecuteNonQuery();

            }
        }

        public static int DeleteProducto(int id)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("DELETE FROM Producto" +
                    "WHERE id=@id", conn);
                comando.Parameters.AddWithValue("@id", id);
                conn.Open();
                return comando.ExecuteNonQuery();

            }
        }

        public static int UpdateProducto(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("UPDATE Producto " +
                    "SET Descripciones=@descripciones," +
                    "Costo=@costo, PrecioVenta=@precioVenta," +
                    "Stock=@stock, IdUsuario=@idUsuario " +
                    "WHERE Id=@id", conn);
                comando.Parameters.AddWithValue("@id", producto.Id);
                comando.Parameters.AddWithValue("@descripciones", producto.Descripciones);
                comando.Parameters.AddWithValue("@costo", producto.Costo);
                comando.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                comando.Parameters.AddWithValue("@stock", producto.Stock);
                comando.Parameters.AddWithValue("@idUsuario", producto.IdUsuario);
                conn.Open();
                return comando.ExecuteNonQuery();
            }
        }

    }
}