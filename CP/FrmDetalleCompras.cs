using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppCRUD.CP
{
    public partial class FrmDetalleCompras : Form
    {
        private string connectionString = "server=localhost;database=MayoristaDB;user=root;password=gerardodonelli;";
        private int idCompra;

        public FrmDetalleCompras(int idCompra)
        {
            InitializeComponent();
            this.idCompra = idCompra;
            CargarDatosCompra();
            CargarDetalleCompra();
        }

        private void CargarDatosCompra()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT ID_Compra, Fecha, Proveedor, Total
                    FROM Compras
                    WHERE ID_Compra = @idCompra";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idCompra", idCompra);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    labelIDCompra.Text = reader["ID_Compra"].ToString();
                    labelFecha.Text = Convert.ToDateTime(reader["Fecha"]).ToString("yyyy-MM-dd HH:mm:ss");
                    labelTotal.Text = Convert.ToDecimal(reader["Total"]).ToString("F2");
                    labelProveedorNombre.Text = reader["Proveedor"].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró la compra especificada.");
                    this.Close();
                }
            }
        }

        private void CargarDetalleCompra()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT A.Nombre, DC.Cantidad, DC.PrecioUnitario, DC.Subtotal
                    FROM DetalleCompra DC
                    INNER JOIN Articulos A ON DC.ID_Articulo = A.ID_Articulo
                    WHERE DC.ID_Compra = @idCompra";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idCompra", idCompra);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dtDetalle = new DataTable();
                adapter.Fill(dtDetalle);

                dataGridViewDetalle.DataSource = dtDetalle;

                dataGridViewDetalle.Columns["Nombre"].HeaderText = "Artículo";
                dataGridViewDetalle.Columns["Cantidad"].HeaderText = "Cantidad";
                dataGridViewDetalle.Columns["PrecioUnitario"].HeaderText = "Precio Unitario";
                dataGridViewDetalle.Columns["Subtotal"].HeaderText = "Subtotal";

                dataGridViewDetalle.ReadOnly = true;
                dataGridViewDetalle.AllowUserToAddRows = false;
                dataGridViewDetalle.AllowUserToDeleteRows = false;
                dataGridViewDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }
    }
}
