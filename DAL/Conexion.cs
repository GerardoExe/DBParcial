using MySql.Data.MySqlClient;

namespace AppCRUD.DAL
{
    public class Conexion
    {
        private MySqlConnection conexion;

        private string cadenaConexion = "Server=localhost;Database=mayorista;Uid=root;Pwd=gerardodonelli;";

        public MySqlConnection ObtenerConexion()
        {
            if (conexion == null)
                conexion = new MySqlConnection(cadenaConexion);

            return conexion;
        }
    }
}
