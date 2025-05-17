using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppCRUD.CP
{
    public partial class FrmDetalleVentas : Form
    {
        private string connectionString = "server=localhost;database=MayoristaDB;user=root;password=gerardodonelli;";
        private int idVenta;

        public FrmDetalleVentas(int idVenta)
        {
            InitializeComponent();
            this.idVenta = idVenta;
            CargarDatosVenta();
            CargarDetalleVenta();
        }

        private void CargarDatosVenta()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT V.ID_Venta, V.Fecha, V.Total, 
                           C.NombreCompleto, C.DNI, C.Direccion, C.Telefono, C.Email
                    FROM Ventas V
                    INNER JOIN Clientes C ON V.ID_Cliente = C.ID_Cliente
                    WHERE V.ID_Venta = @idVenta";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idVenta", idVenta);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    labelIDVenta.Text = reader["ID_Venta"].ToString();
                    labelFecha.Text = Convert.ToDateTime(reader["Fecha"]).ToString("yyyy-MM-dd HH:mm:ss");
                    labelTotal.Text = Convert.ToDecimal(reader["Total"]).ToString("F2");

                    labelClienteNombre.Text = reader["NombreCompleto"].ToString();
                    labelClienteDNI.Text = reader["DNI"].ToString();
                    labelClienteDireccion.Text = reader["Direccion"].ToString();
                    labelClienteTelefono.Text = reader["Telefono"].ToString();
                    labelClienteEmail.Text = reader["Email"].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró la venta especificada.");
                    this.Close();
                }
            }
        }

        private void CargarDetalleVenta()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT A.Nombre, DV.Cantidad, DV.PrecioUnitario, DV.Subtotal
                    FROM DetalleVenta DV
                    INNER JOIN Articulos A ON DV.ID_Articulo = A.ID_Articulo
                    WHERE DV.ID_Venta = @idVenta";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idVenta", idVenta);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dtDetalle = new DataTable();
                adapter.Fill(dtDetalle);

                dataGridViewDetalle.DataSource = dtDetalle;

                dataGridViewDetalle.Columns["Nombre"].HeaderText = "Artículo";
                dataGridViewDetalle.Columns["Cantidad"].HeaderText = "Cantidad";
                dataGridViewDetalle.Columns["PrecioUnitario"].HeaderText = "Precio Unitario";
                dataGridViewDetalle.Columns["Subtotal"].HeaderText = "Subtotal";

                // Opcional: hacer solo lectura el grid
                dataGridViewDetalle.ReadOnly = true;
                dataGridViewDetalle.AllowUserToAddRows = false;
                dataGridViewDetalle.AllowUserToDeleteRows = false;
                dataGridViewDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }
    }
}
