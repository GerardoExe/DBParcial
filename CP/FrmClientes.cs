using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppCRUD.CP
{
    public partial class FrmClientes : Form
    {
        // Cadena de conexión a la base de datos MySQL
        private string connectionString = "server=localhost;database=mayoristadb;uid=root;pwd=gerardodonelli;";

        public FrmClientes()
        {
            InitializeComponent();
        }

        // Evento de clic en el botón de guardar cliente
        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            string nombreCompleto = textBoxNombreCompleto.Text;
            string dni = textBoxDNI.Text;
            string direccion = textBoxDireccion.Text;
            string telefono = textBoxTelefono.Text;
            string email = textBoxEmail.Text;

            // Validaciones básicas
            if (string.IsNullOrEmpty(nombreCompleto))
            {
                MessageBox.Show("El nombre completo es obligatorio.");
                return;
            }

            // Guardar cliente en la base de datos
            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    var cmd = new MySqlCommand("INSERT INTO Clientes (NombreCompleto, DNI, Direccion, Telefono, Email) VALUES (@nombre, @dni, @direccion, @telefono, @email)", conn);
                    cmd.Parameters.AddWithValue("@nombre", nombreCompleto);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cliente registrado correctamente.");
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el cliente: " + ex.Message);
                }
            }
        }

        // Limpiar los campos del formulario
        private void LimpiarCampos()
        {
            textBoxNombreCompleto.Clear();
            textBoxDNI.Clear();
            textBoxDireccion.Clear();
            textBoxTelefono.Clear();
            textBoxEmail.Clear();
        }
    }
}
