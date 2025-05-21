using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppCRUD.CP
{
    public partial class FrmClientes : Form
    {
        private string connectionString = "server=localhost;database=mayoristadb;uid=root;pwd=gerardodonelli;";

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            string nombreCompleto = textBoxNombreCompleto.Text;
            string dni = textBoxDNI.Text;
            string direccion = textBoxDireccion.Text;
            string telefono = textBoxTelefono.Text;
            string email = textBoxEmail.Text;

            // Validaciones
            if (string.IsNullOrWhiteSpace(nombreCompleto))
            {
                MessageBox.Show("El nombre completo es obligatorio.");
                return;
            }

            if (!EsDniValido(dni))
            {
                MessageBox.Show("El DNI debe contener solo números y tener entre 7 y 8 dígitos.");
                return;
            }

            if (!EsEmailValido(email))
            {
                MessageBox.Show("El correo electrónico no tiene un formato válido.");
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

        // Función para validar el formato de un correo electrónico
        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Función para validar el DNI (7 u 8 dígitos numéricos)
        private bool EsDniValido(string dni)
        {
            return Regex.IsMatch(dni, @"^\d{7,8}$");
        }

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
