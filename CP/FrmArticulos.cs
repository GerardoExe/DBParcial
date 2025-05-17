using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppCRUD.CP
{
    public partial class FrmArticulos : Form
    {
        private string connectionString = "server=localhost;database=mayoristadb;user=root;password=gerardodonelli;";

        public FrmArticulos()
        {
            InitializeComponent();
        }

        private void FrmArticulos_Load(object sender, EventArgs e)
        {
            CargarArticulos();
            comboBoxCategoria.Items.AddRange(new string[] { "Comestibles", "Librería", "Electrodomésticos" });
        }

        private void CargarArticulos()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM articulos";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewArticulos.DataSource = dt;

                // Ocultar la columna ID_Articulo
                if (dataGridViewArticulos.Columns.Contains("ID_Articulo"))
                    dataGridViewArticulos.Columns["ID_Articulo"].Visible = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO articulos (Nombre, Categoria, Precio, Stock, Unidad) VALUES (@nombre, @categoria, @precio, @stock, @unidad)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", textBoxNombre.Text);
                cmd.Parameters.AddWithValue("@categoria", comboBoxCategoria.Text);
                cmd.Parameters.AddWithValue("@precio", decimal.Parse(textBoxPrecio.Text));
                cmd.Parameters.AddWithValue("@stock", int.Parse(textBoxStock.Text));
                cmd.Parameters.AddWithValue("@unidad", textBoxUnidad.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Artículo agregado correctamente.");
                CargarArticulos();
                LimpiarCampos();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridViewArticulos.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridViewArticulos.CurrentRow.Cells["ID_Articulo"].Value);
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE articulos SET Nombre=@nombre, Categoria=@categoria, Precio=@precio, Stock=@stock, Unidad=@unidad WHERE ID_Articulo=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", textBoxNombre.Text);
                    cmd.Parameters.AddWithValue("@categoria", comboBoxCategoria.Text);
                    cmd.Parameters.AddWithValue("@precio", decimal.Parse(textBoxPrecio.Text));
                    cmd.Parameters.AddWithValue("@stock", int.Parse(textBoxStock.Text));
                    cmd.Parameters.AddWithValue("@unidad", textBoxUnidad.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Artículo actualizado.");
                    CargarArticulos();
                    LimpiarCampos();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewArticulos.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridViewArticulos.CurrentRow.Cells["ID_Articulo"].Value);
                DialogResult result = MessageBox.Show("¿Seguro que deseas eliminar este artículo?", "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM articulos WHERE ID_Articulo=@id";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Artículo eliminado.");
                        CargarArticulos();
                        LimpiarCampos();
                    }
                }
            }
        }

        private void dataGridViewArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewArticulos.Rows[e.RowIndex].Cells["ID_Articulo"].Value != null)
            {
                textBoxNombre.Text = dataGridViewArticulos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                comboBoxCategoria.Text = dataGridViewArticulos.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
                textBoxPrecio.Text = dataGridViewArticulos.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                textBoxStock.Text = dataGridViewArticulos.Rows[e.RowIndex].Cells["Stock"].Value.ToString();
                textBoxUnidad.Text = dataGridViewArticulos.Rows[e.RowIndex].Cells["Unidad"].Value.ToString();
            }
        }

        private void LimpiarCampos()
        {
            textBoxNombre.Clear();
            comboBoxCategoria.SelectedIndex = -1;
            textBoxPrecio.Clear();
            textBoxStock.Clear();
            textBoxUnidad.Clear();
        }

        
    }
}
