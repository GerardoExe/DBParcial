namespace AppCRUD.CP
{
    partial class FrmClientes
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBoxNombreCompleto;
        private TextBox textBoxDNI;
        private TextBox textBoxDireccion;
        private TextBox textBoxTelefono;
        private TextBox textBoxEmail;
        private Button btnGuardarCliente;
        private Label labelNombre;
        private Label labelDNI;
        private Label labelDireccion;
        private Label labelTelefono;
        private Label labelEmail;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxNombreCompleto = new TextBox();
            textBoxDNI = new TextBox();
            textBoxDireccion = new TextBox();
            textBoxTelefono = new TextBox();
            textBoxEmail = new TextBox();
            btnGuardarCliente = new Button();
            labelNombre = new Label();
            labelDNI = new Label();
            labelDireccion = new Label();
            labelTelefono = new Label();
            labelEmail = new Label();
            SuspendLayout();
            // 
            // textBoxNombreCompleto
            // 
            textBoxNombreCompleto.Location = new Point(188, 30);
            textBoxNombreCompleto.Name = "textBoxNombreCompleto";
            textBoxNombreCompleto.Size = new Size(200, 27);
            textBoxNombreCompleto.TabIndex = 0;
            // 
            // textBoxDNI
            // 
            textBoxDNI.Location = new Point(188, 63);
            textBoxDNI.Name = "textBoxDNI";
            textBoxDNI.Size = new Size(200, 27);
            textBoxDNI.TabIndex = 1;
            // 
            // textBoxDireccion
            // 
            textBoxDireccion.Location = new Point(188, 110);
            textBoxDireccion.Name = "textBoxDireccion";
            textBoxDireccion.Size = new Size(200, 27);
            textBoxDireccion.TabIndex = 2;
            // 
            // textBoxTelefono
            // 
            textBoxTelefono.Location = new Point(188, 156);
            textBoxTelefono.Name = "textBoxTelefono";
            textBoxTelefono.Size = new Size(200, 27);
            textBoxTelefono.TabIndex = 3;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(188, 198);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(200, 27);
            textBoxEmail.TabIndex = 4;
            // 
            // btnGuardarCliente
            // 
            btnGuardarCliente.Location = new Point(209, 246);
            btnGuardarCliente.Name = "btnGuardarCliente";
            btnGuardarCliente.Size = new Size(79, 35);
            btnGuardarCliente.TabIndex = 5;
            btnGuardarCliente.Text = "Guardar";
            btnGuardarCliente.UseVisualStyleBackColor = true;
            btnGuardarCliente.Click += btnGuardarCliente_Click;
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(30, 30);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(137, 20);
            labelNombre.TabIndex = 6;
            labelNombre.Text = "Nombre Completo:";
            // 
            // labelDNI
            // 
            labelDNI.AutoSize = true;
            labelDNI.Location = new Point(41, 70);
            labelDNI.Name = "labelDNI";
            labelDNI.Size = new Size(38, 20);
            labelDNI.TabIndex = 7;
            labelDNI.Text = "DNI:";
            // 
            // labelDireccion
            // 
            labelDireccion.AutoSize = true;
            labelDireccion.Location = new Point(30, 113);
            labelDireccion.Name = "labelDireccion";
            labelDireccion.Size = new Size(75, 20);
            labelDireccion.TabIndex = 8;
            labelDireccion.Text = "Dirección:";
            // 
            // labelTelefono
            // 
            labelTelefono.AutoSize = true;
            labelTelefono.Location = new Point(30, 156);
            labelTelefono.Name = "labelTelefono";
            labelTelefono.Size = new Size(70, 20);
            labelTelefono.TabIndex = 9;
            labelTelefono.Text = "Teléfono:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(30, 198);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(49, 20);
            labelEmail.TabIndex = 10;
            labelEmail.Text = "Email:";
            // 
            // FrmClientes
            // 
            ClientSize = new Size(506, 305);
            Controls.Add(labelEmail);
            Controls.Add(labelTelefono);
            Controls.Add(labelDireccion);
            Controls.Add(labelDNI);
            Controls.Add(labelNombre);
            Controls.Add(btnGuardarCliente);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxTelefono);
            Controls.Add(textBoxDireccion);
            Controls.Add(textBoxDNI);
            Controls.Add(textBoxNombreCompleto);
            Name = "FrmClientes";
            Text = "Registro de Clientes";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
