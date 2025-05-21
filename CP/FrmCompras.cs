using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppCRUD.CP
{
    public partial class FrmCompras : Form
    {
        private readonly string connectionString = "server=localhost;database=MayoristaDB;user=root;password=gerardodonelli;";
        private List<DetalleCompra> detalles = new List<DetalleCompra>();
        private DataTable dtArticulos;

        public FrmCompras()
        {
            InitializeComponent();
            CargarArticulos();
            CargarProveedores();
            textBoxFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");

            comboBoxArticulo.SelectedIndexChanged += ComboBoxArticulo_SelectedIndexChanged;
            checkBoxMostrarHistorial.CheckedChanged += CheckBoxMostrarHistorial_CheckedChanged;
            comboBoxProveedor.TextChanged += ComboBoxProveedor_TextChanged;
            dataGridViewDetalle.CellDoubleClick += DataGridViewDetalle_CellDoubleClick;
        }

        private void CargarArticulos()
        {
            dtArticulos = new DataTable();
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            using var cmd = new MySqlCommand("SELECT ID_Articulo, Nombre, Precio, Stock FROM Articulos", conn);
            using var da = new MySqlDataAdapter(cmd);
            da.Fill(dtArticulos);

            dtArticulos.PrimaryKey = new[] { dtArticulos.Columns["ID_Articulo"] };

            comboBoxArticulo.DisplayMember = "Nombre";
            comboBoxArticulo.ValueMember = "ID_Articulo";
            comboBoxArticulo.DataSource = dtArticulos;
            comboBoxArticulo.SelectedIndex = -1;
        }
        private void CargarProveedores()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT DISTINCT Proveedor FROM Compras WHERE Proveedor IS NOT NULL AND Proveedor <> ''";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                comboBoxProveedor.Items.Clear();
                while (reader.Read())
                {
                    comboBoxProveedor.Items.Add(reader.GetString("Proveedor"));
                }

                comboBoxProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBoxProveedor.AutoCompleteSource = AutoCompleteSource.ListItems;
                comboBoxProveedor.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }

        private void ComboBoxArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxArticulo.SelectedIndex == -1)
            {
                textBoxPrecioUnitario.Clear();
                return;
            }

            int idArt = Convert.ToInt32(comboBoxArticulo.SelectedValue);
            var row = dtArticulos.Rows.Find(idArt);
            textBoxPrecioUnitario.Text = row != null
                ? ((decimal)row["Precio"]).ToString("F2")
                : string.Empty;
        }

        private void BtnAgregarArticulo_Click(object sender, EventArgs e)
        {
            if (comboBoxArticulo.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un artículo.");
                return;
            }
            if (!int.TryParse(textBoxCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida.");
                return;
            }
            if (!decimal.TryParse(textBoxPrecioUnitario.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Precio inválido.");
                return;
            }

            string nombre = comboBoxArticulo.Text;
            var existente = detalles.Find(d => d.Articulo == nombre);
            if (existente != null)
            {
                existente.Cantidad += cantidad;
                existente.PrecioUnitario = precio;
            }
            else
            {
                detalles.Add(new DetalleCompra
                {
                    Articulo = nombre,
                    Cantidad = cantidad,
                    PrecioUnitario = precio
                });
            }

            MostrarModoCompra();
        }

        private void BtnEliminarArticulo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewDetalle.SelectedRows)
                if (row.DataBoundItem is DetalleCompra det)
                    detalles.Remove(det);
            MostrarModoCompra();
        }

        private void BtnGuardarCompra_Click(object sender, EventArgs e)
        {
            string proveedor = comboBoxProveedor.Text.Trim();
            if (string.IsNullOrEmpty(proveedor))
            {
                MessageBox.Show("Ingrese un proveedor.");
                return;
            }
            if (!detalles.Any())
            {
                MessageBox.Show("Agregue artículos.");
                return;
            }

            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            using var trans = conn.BeginTransaction();
            try
            {
                // 1) Insertar la compra
                var cmdCompra = new MySqlCommand(
                    "INSERT INTO Compras (Fecha, Proveedor, Total) VALUES (@f, @p, @t)",
                    conn, trans);
                cmdCompra.Parameters.AddWithValue("@f", DateTime.Now);
                cmdCompra.Parameters.AddWithValue("@p", proveedor);
                cmdCompra.Parameters.AddWithValue("@t", detalles.Sum(d => d.Subtotal));
                cmdCompra.ExecuteNonQuery();
                long idCompra = cmdCompra.LastInsertedId;

                // 2) Por cada detalle: insertar detalle y sumar stock
                foreach (var d in detalles)
                {
                    var filtro = $"Nombre = '{d.Articulo.Replace("'", "''")}'";
                    var filas = dtArticulos.Select(filtro);
                    if (filas.Length == 0)
                        throw new Exception($"Artículo '{d.Articulo}' no encontrado.");

                    int idArt = Convert.ToInt32(filas[0]["ID_Articulo"]);

                    // Insertar detalle
                    var cmdDet = new MySqlCommand(
                        @"INSERT INTO DetalleCompra
                          (ID_Compra, ID_Articulo, Cantidad, PrecioUnitario, Subtotal)
                          VALUES (@c,@a,@q,@p,@s)",
                        conn, trans);
                    cmdDet.Parameters.AddWithValue("@c", idCompra);
                    cmdDet.Parameters.AddWithValue("@a", idArt);
                    cmdDet.Parameters.AddWithValue("@q", d.Cantidad);
                    cmdDet.Parameters.AddWithValue("@p", d.PrecioUnitario);
                    cmdDet.Parameters.AddWithValue("@s", d.Subtotal);
                    cmdDet.ExecuteNonQuery();

                    // Actualizar stock sumando cantidad
                    var cmdStock = new MySqlCommand(
                        "UPDATE Articulos SET Stock = Stock + @c WHERE ID_Articulo = @a",
                        conn, trans);
                    cmdStock.Parameters.AddWithValue("@c", d.Cantidad);
                    cmdStock.Parameters.AddWithValue("@a", idArt);
                    cmdStock.ExecuteNonQuery();
                }

                trans.Commit();
                MessageBox.Show("Compra registrada y stock actualizado.");
                detalles.Clear();
                MostrarModoCompra();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Error al registrar la compra: " + ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            detalles.Clear();
            MostrarModoCompra();
        }

        private void ComboBoxProveedor_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxMostrarHistorial.Checked) MostrarHistorialCompras();
        }

        private void CheckBoxMostrarHistorial_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMostrarHistorial.Checked) MostrarHistorialCompras();
            else MostrarModoCompra();
        }

        private void MostrarHistorialCompras()
        {
            string proveedor = comboBoxProveedor.Text.Trim();
            if (string.IsNullOrEmpty(proveedor)) return;

            var dt = new DataTable();
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            var sql = @"
                SELECT c.ID_Compra, c.Fecha, a.Nombre AS Artículo,
                       dc.Cantidad, dc.PrecioUnitario, dc.Subtotal
                FROM Compras c
                JOIN DetalleCompra dc ON c.ID_Compra = dc.ID_Compra
                JOIN Articulos a ON dc.ID_Articulo = a.ID_Articulo
                WHERE c.Proveedor = @prov
                ORDER BY c.Fecha DESC";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@prov", proveedor);
            using var da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewDetalle.DataSource = dt;
            groupBoxAgregarArticulo.Enabled = false;
            btnAgregarArticulo.Enabled = false;
            btnEliminarArticulo.Enabled = false;
            btnGuardarCompra.Enabled = false;
        }

        private void MostrarModoCompra()
        {
            dataGridViewDetalle.DataSource = null;
            dataGridViewDetalle.DataSource = detalles;
            dataGridViewDetalle.AutoResizeColumns();
            textBoxTotal.Text = detalles.Sum(d => d.Subtotal).ToString("N2");
            groupBoxAgregarArticulo.Enabled = true;
            btnAgregarArticulo.Enabled = true;
            btnEliminarArticulo.Enabled = true;
            btnGuardarCompra.Enabled = true;
        }

        private void DataGridViewDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1) Ignorar clicks en encabezados
            if (e.RowIndex < 0) return;

            // 2) Intentar obtener la celda "ID_Compra"
            if (!dataGridViewDetalle.Columns.Contains("ID_Compra"))
            {
                MessageBox.Show("La columna 'ID_Compra' no existe en este modo.");
                return;
            }

            var cellValue = dataGridViewDetalle.Rows[e.RowIndex].Cells["ID_Compra"].Value;
            if (cellValue == null || !int.TryParse(cellValue.ToString(), out int idCompra))
            {
                MessageBox.Show("No se pudo leer el ID de la compra.");
                return;
            }

            // 3) Diagnóstico: confirma que estamos capturando el doble-click
            MessageBox.Show($"Abriendo detalle de la compra #{idCompra}", "DEBUG");

            // 4) Abrir el formulario de detalle pasando el idCompra
            using var detalleForm = new FrmDetalleCompras(idCompra);
            detalleForm.ShowDialog();
        }
    }

    public class DetalleCompra
    {
        public string Articulo { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
