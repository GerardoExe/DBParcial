using System.Collections.Generic;
using MySql.Data.MySqlClient;
using CL;

namespace AppCRUD.DAL
{
    public class ArticuloDAL
    {
        private Conexion conexion = new Conexion();

        public List<Articulo> ObtenerTodos(int pagina, int tamanioPagina)
        {
            List<Articulo> lista = new List<Articulo>();
            var conn = conexion.ObtenerConexion();
            conn.Open();

            int offset = (pagina - 1) * tamanioPagina;
            string query = "SELECT * FROM Articulos LIMIT @limite OFFSET @offset";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@limite", tamanioPagina);
            cmd.Parameters.AddWithValue("@offset", offset);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Articulo
                {
                    ID_Articulo = reader.GetInt32("ID_Articulo"),
                    Nombre = reader.GetString("Nombre"),
                    Categoria = reader.GetString("Categoria"),
                    Precio = reader.GetDecimal("Precio"),
                    Stock = reader.GetInt32("Stock"),
                    Unidad = reader.GetString("Unidad")
                });
            }

            conn.Close();
            return lista;
        }

        public int ContarTotalArticulos()
        {
            var conn = conexion.ObtenerConexion();
            conn.Open();

            string query = "SELECT COUNT(*) FROM Articulos";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            int total = Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();
            return total;
        }

        public void Agregar(Articulo a)
        {
            var conn = conexion.ObtenerConexion();
            conn.Open();
            string query = "INSERT INTO Articulos (Nombre, Categoria, Precio, Stock, Unidad) VALUES (@Nombre, @Categoria, @Precio, @Stock, @Unidad)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nombre", a.Nombre);
            cmd.Parameters.AddWithValue("@Categoria", a.Categoria);
            cmd.Parameters.AddWithValue("@Precio", a.Precio);
            cmd.Parameters.AddWithValue("@Stock", a.Stock);
            cmd.Parameters.AddWithValue("@Unidad", a.Unidad);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Actualizar(Articulo a)
        {
            var conn = conexion.ObtenerConexion();
            conn.Open();
            string query = "UPDATE Articulos SET Nombre=@Nombre, Categoria=@Categoria, Precio=@Precio, Stock=@Stock, Unidad=@Unidad WHERE ID_Articulo=@ID";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nombre", a.Nombre);
            cmd.Parameters.AddWithValue("@Categoria", a.Categoria);
            cmd.Parameters.AddWithValue("@Precio", a.Precio);
            cmd.Parameters.AddWithValue("@Stock", a.Stock);
            cmd.Parameters.AddWithValue("@Unidad", a.Unidad);
            cmd.Parameters.AddWithValue("@ID", a.ID_Articulo);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Eliminar(int id)
        {
            var conn = conexion.ObtenerConexion();
            conn.Open();
            string query = "DELETE FROM Articulos WHERE ID_Articulo=@ID";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
