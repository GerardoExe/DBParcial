using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppCRUD.CP
{
    public partial class FrmVentas : Form
    {
        private readonly string connectionString = "server=localhost;database=MayoristaDB;user=root;password=gerardodonelli;";
        private List<DetalleVenta> detalles = new List<DetalleVenta>();
        private DataTable dtArticulos;

        public FrmVentas()
        {
            InitializeComponent();
            CargarClientes();
            CargarArticulos();  // ahora incluye Stock
            textBoxFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");

            comboBoxCliente.SelectedIndexChanged += ComboBoxCliente_SelectedIndexChanged;
            checkBoxMostrarHistorial.CheckedChanged += checkBoxMostrarHistorial_CheckedChanged;
            comboBoxArticulo.SelectedIndexChanged += ComboBoxArticulo_SelectedIndexChanged;
            dataGridViewDetalle.CellDoubleClick += dataGridViewDetalle_CellDoubleClick; // suscribimos el doble‐click
        }

        private void CargarClientes()
        {
            var dt = new DataTable();
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            using var cmd = new MySqlCommand("SELECT ID_Cliente, NombreCompleto FROM Clientes", conn);
            using var da = new MySqlDataAdapter(cmd);
            da.Fill(dt);

            comboBoxCliente.DisplayMember = "NombreCompleto";
            comboBoxCliente.ValueMember = "ID_Cliente";
            comboBoxCliente.DataSource = dt;
            comboBoxCliente.SelectedIndex = -1;
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

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
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
                detalles.Add(new DetalleVenta
                {
                    Articulo = nombre,
                    Cantidad = cantidad,
                    PrecioUnitario = precio
                });
            }

            MostrarModoVenta();
        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewDetalle.SelectedRows)
                if (row.DataBoundItem is DetalleVenta det)
                    detalles.Remove(det);
            MostrarModoVenta();
        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (comboBoxCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente.");
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
                // 1) Insertar la venta
                var cmdVenta = new MySqlCommand(
                    "INSERT INTO Ventas (Fecha, ID_Cliente, Total) VALUES (@f, @c, @t)",
                    conn, trans);
                cmdVenta.Parameters.AddWithValue("@f", DateTime.Now);
                cmdVenta.Parameters.AddWithValue("@c", comboBoxCliente.SelectedValue);
                cmdVenta.Parameters.AddWithValue("@t", detalles.Sum(d => d.Subtotal));
                cmdVenta.ExecuteNonQuery();
                long idVenta = cmdVenta.LastInsertedId;

                // 2) Por cada detalle: verificar stock, insertar detalle y restar stock
                foreach (var d in detalles)
                {
                    // Obtener ID y stock
                    var filtro = $"Nombre = '{d.Articulo.Replace("'", "''")}'";
                    var filas = dtArticulos.Select(filtro);
                    if (filas.Length == 0)
                        throw new Exception($"Artículo '{d.Articulo}' no encontrado.");

                    int idArt = Convert.ToInt32(filas[0]["ID_Articulo"]);
                    int stockDb = Convert.ToInt32(filas[0]["Stock"]);

                    if (d.Cantidad > stockDb)
                        throw new Exception($"Stock insuficiente para '{d.Articulo}'. Disponible: {stockDb}.");

                    // Insertar detalle
                    var cmdDet = new MySqlCommand(
                        @"INSERT INTO DetalleVenta
                          (ID_Venta, ID_Articulo, Cantidad, PrecioUnitario, Subtotal)
                          VALUES (@v,@a,@q,@p,@s)",
                        conn, trans);
                    cmdDet.Parameters.AddWithValue("@v", idVenta);
                    cmdDet.Parameters.AddWithValue("@a", idArt);
                    cmdDet.Parameters.AddWithValue("@q", d.Cantidad);
                    cmdDet.Parameters.AddWithValue("@p", d.PrecioUnitario);
                    cmdDet.Parameters.AddWithValue("@s", d.Subtotal);
                    cmdDet.ExecuteNonQuery();

                    // Actualizar stock
                    var cmdStock = new MySqlCommand(
                        "UPDATE Articulos SET Stock = Stock - @c WHERE ID_Articulo = @a",
                        conn, trans);
                    cmdStock.Parameters.AddWithValue("@c", d.Cantidad);
                    cmdStock.Parameters.AddWithValue("@a", idArt);
                    cmdStock.ExecuteNonQuery();
                }

                trans.Commit();
                MessageBox.Show("Venta registrada y stock actualizado.");
                detalles.Clear();
                MostrarModoVenta();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show("Error al registrar la venta: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            detalles.Clear();
            MostrarModoVenta();
        }

        private void ComboBoxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBoxMostrarHistorial.Checked) MostrarHistorialCompras();
        }

        private void checkBoxMostrarHistorial_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMostrarHistorial.Checked) MostrarHistorialCompras();
            else MostrarModoVenta();
        }

        private void MostrarHistorialCompras()
        {
            if (comboBoxCliente.SelectedIndex == -1) return;
            int idCli = Convert.ToInt32(comboBoxCliente.SelectedValue);
            var dt = new DataTable();
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            var sql = @"
                SELECT v.ID_Venta, v.Fecha, a.Nombre AS Artículo,
                       dv.Cantidad, dv.PrecioUnitario, dv.Subtotal
                FROM Ventas v
                JOIN DetalleVenta dv ON v.ID_Venta = dv.ID_Venta
                JOIN Articulos a ON dv.ID_Articulo = a.ID_Articulo
                WHERE v.ID_Cliente = @cli
                ORDER BY v.Fecha DESC";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@cli", idCli);
            using var da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewDetalle.DataSource = dt;
            groupBoxAgregarArticulo.Enabled = false;
            btnAgregarArticulo.Enabled = false;
            btnEliminarArticulo.Enabled = false;
            btnGuardarVenta.Enabled = false;
        }

        private void MostrarModoVenta()
        {
            dataGridViewDetalle.DataSource = null;
            dataGridViewDetalle.DataSource = detalles;
            dataGridViewDetalle.AutoResizeColumns();
            textBoxTotal.Text = detalles.Sum(d => d.Subtotal).ToString("N2");
            groupBoxAgregarArticulo.Enabled = true;
            btnAgregarArticulo.Enabled = true;
            btnEliminarArticulo.Enabled = true;
            btnGuardarVenta.Enabled = true;
        }

       


private void dataGridViewDetalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            // 1) Ignorar clicks en encabezados
            if (e.RowIndex < 0) return;

            // 2) Intentar obtener la celda "ID_Venta"
            if (!dataGridViewDetalle.Columns.Contains("ID_Venta"))
            {
                MessageBox.Show("La columna 'ID_Venta' no existe en este modo.");
                return;
            }

            var cellValue = dataGridViewDetalle.Rows[e.RowIndex].Cells["ID_Venta"].Value;
            if (cellValue == null || !int.TryParse(cellValue.ToString(), out int idVenta))
            {
                MessageBox.Show("No se pudo leer el ID de la venta.");
                return;
            }

            // 3) Diagnóstico: confirma que estamos capturando el doble-click
            MessageBox.Show($"Abriendo detalle de la venta #{idVenta}", "DEBUG");

            // 4) Abrir el formulario de detalle pasando el idVenta
            using var detalleForm = new FrmDetalleVentas(idVenta);
            detalleForm.ShowDialog();
        }

    }

    public class DetalleVenta
    {
        public string Articulo { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
