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
        int paginaActual = 0;
        int tamanioPagina = 4;

        public FrmVentas()
        {
            InitializeComponent();
            CargarClientes();
            CargarArticulos();
            textBoxFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");

            textBoxBuscarArticulo.TextChanged += textBoxBuscarArticulo_TextChanged;
            comboBoxCliente.SelectedIndexChanged += ComboBoxCliente_SelectedIndexChanged;
            checkBoxMostrarHistorial.CheckedChanged += checkBoxMostrarHistorial_CheckedChanged;
            comboBoxArticulo.SelectedIndexChanged += ComboBoxArticulo_SelectedIndexChanged;
            dataGridViewDetalle.CellDoubleClick += dataGridViewDetalle_CellDoubleClick;

            dataGridViewArticulos.CellClick += dataGridViewArticulos_CellClick;
            comboBoxArticulo.SelectedIndexChanged += ComboBoxArticulo_SelectedIndexChanged;

            btnPaginaAnterior.Click += btnPagAnterior_Click;
            btnPaginaSiguiente.Click += btnPagSiguiente_Click;
            btnAgregarArticulo.Click += btnAgregarArticulo_Click;
            btnEliminarArticulo.Click += btnEliminarArticulo_Click;
            btnGuardarVenta.Click += btnGuardarVenta_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private void CargarClientes()
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            using var cmd = new MySqlCommand("SELECT ID_Cliente, NombreCompleto FROM Clientes", conn);
            using var da = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            comboBoxCliente.DisplayMember = "NombreCompleto";
            comboBoxCliente.ValueMember = "ID_Cliente";
            comboBoxCliente.DataSource = dt;
            comboBoxCliente.SelectedIndex = -1;
        }

        private void CargarArticulos(string filtro = "")
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string condicionFiltro = string.IsNullOrWhiteSpace(filtro)
                ? ""
                : "WHERE LOWER(Nombre) LIKE @filtro";

            string sql = $@"
        SELECT ID_Articulo, Nombre, Precio, Stock
        FROM Articulos
        {condicionFiltro}
ORDER BY ID_Articulo
        LIMIT @limit OFFSET @offset";

            using var cmd = new MySqlCommand(sql, conn);
            if (!string.IsNullOrWhiteSpace(filtro))
                cmd.Parameters.AddWithValue("@filtro", "%" + filtro.ToLower() + "%");

            cmd.Parameters.AddWithValue("@limit", tamanioPagina);
            cmd.Parameters.AddWithValue("@offset", paginaActual * tamanioPagina);

            using var da = new MySqlDataAdapter(cmd);
            dtArticulos = new DataTable();
            da.Fill(dtArticulos);

            // Definir clave primaria para que Rows.Find funcione
            dtArticulos.PrimaryKey = new DataColumn[] { dtArticulos.Columns["ID_Articulo"] };

            dataGridViewArticulos.DataSource = dtArticulos;

            dataGridViewArticulos.Columns["ID_Articulo"].Visible = true;
            dataGridViewArticulos.Columns["Nombre"].Width = 200;
            dataGridViewArticulos.Columns["Precio"].DefaultCellStyle.Format = "C2";
            dataGridViewArticulos.Columns["Stock"].Width = 80;

            if (dtArticulos.Rows.Count == 0 && paginaActual > 0)
            {
                paginaActual--;
                CargarArticulos(filtro);
            }
            comboBoxArticulo.DataSource = dtArticulos.Copy(); // ← importante usar Copy()
            comboBoxArticulo.DisplayMember = "Nombre";
            comboBoxArticulo.ValueMember = "ID_Articulo";
            comboBoxArticulo.SelectedIndex = -1; // Ninguno seleccionado por defecto
        }


        private void btnPagAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 0)
            {
                paginaActual--;
                CargarArticulos(textBoxBuscarArticulo.Text.Trim());
            }
        }

        private void btnPagSiguiente_Click(object sender, EventArgs e)
        {
            paginaActual++;
            CargarArticulos(textBoxBuscarArticulo.Text.Trim());

            // if (dtArticulos.Rows.Count == 0 && paginaActual > 0)
            // {
            // paginaActual--;
            //CargarArticulos(textBoxBuscarArticulo.Text.Trim());
            //}
        }

        private void textBoxBuscarArticulo_TextChanged(object sender, EventArgs e)
        {
            paginaActual = 0;
            CargarArticulos(textBoxBuscarArticulo.Text.Trim());
        }

        private void ComboBoxArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxArticulo.SelectedIndex == -1) return;

            int idArt = Convert.ToInt32(comboBoxArticulo.SelectedValue);
            var row = dtArticulos.Rows.Find(idArt);
            textBoxPrecioUnitario.Text = row != null ? ((decimal)row["Precio"]).ToString("F2") : string.Empty;
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
                existente.Cantidad = cantidad;
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
                var cmdVenta = new MySqlCommand(
                    "INSERT INTO Ventas (Fecha, ID_Cliente, Total) VALUES (@f, @c, @t)", conn, trans);
                cmdVenta.Parameters.AddWithValue("@f", DateTime.Now);
                cmdVenta.Parameters.AddWithValue("@c", comboBoxCliente.SelectedValue);
                cmdVenta.Parameters.AddWithValue("@t", detalles.Sum(d => d.Subtotal));
                cmdVenta.ExecuteNonQuery();
                long idVenta = cmdVenta.LastInsertedId;

                foreach (var d in detalles)
                {
                    var filtro = $"Nombre = '{d.Articulo.Replace("'", "''")}'";
                    var filas = dtArticulos.Select(filtro);
                    if (filas.Length == 0)
                        throw new Exception($"Artículo '{d.Articulo}' no encontrado.");

                    int idArt = Convert.ToInt32(filas[0]["ID_Articulo"]);
                    int stockDb = Convert.ToInt32(filas[0]["Stock"]);

                    if (d.Cantidad > stockDb)
                        throw new Exception($"Stock insuficiente para '{d.Articulo}'. Disponible: {stockDb}.");

                    var cmdDet = new MySqlCommand(
                        @"INSERT INTO DetalleVenta (ID_Venta, ID_Articulo, Cantidad, PrecioUnitario, Subtotal)
                          VALUES (@v,@a,@q,@p,@s)", conn, trans);
                    cmdDet.Parameters.AddWithValue("@v", idVenta);
                    cmdDet.Parameters.AddWithValue("@a", idArt);
                    cmdDet.Parameters.AddWithValue("@q", d.Cantidad);
                    cmdDet.Parameters.AddWithValue("@p", d.PrecioUnitario);
                    cmdDet.Parameters.AddWithValue("@s", d.Subtotal);
                    cmdDet.ExecuteNonQuery();

                    var cmdStock = new MySqlCommand(
                        "UPDATE Articulos SET Stock = Stock - @c WHERE ID_Articulo = @a", conn, trans);
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
            using var conn = new MySqlConnection(connectionString);
            conn.Open();
            string sql = @"
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
            var dt = new DataTable();
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
        private void dataGridViewArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                // Obtener ID del artículo de la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridViewArticulos.Rows[e.RowIndex];
                if (filaSeleccionada.Cells["ID_Articulo"].Value != null)
                {
                    int idArticulo = Convert.ToInt32(filaSeleccionada.Cells["ID_Articulo"].Value);

                    // Seleccionarlo en el comboBox
                    comboBoxArticulo.SelectedValue = idArticulo;
                }
            }


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

        private void textBoxBuscarArticulo_TextChanged_1(object sender, EventArgs e)
        {

        }
    }

    public class DetalleVenta
    {
        public string Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
