namespace AppCRUD.CP
{
    partial class FrmDetalleVentas
    {
        private System.ComponentModel.IContainer components = null;

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
            this.labelTitulo = new System.Windows.Forms.Label();
            this.groupBoxVenta = new System.Windows.Forms.GroupBox();
            this.labelIDVenta = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelIDVentaTitulo = new System.Windows.Forms.Label();
            this.labelFechaTitulo = new System.Windows.Forms.Label();
            this.labelTotalTitulo = new System.Windows.Forms.Label();

            this.groupBoxCliente = new System.Windows.Forms.GroupBox();
            this.labelClienteNombre = new System.Windows.Forms.Label();
            this.labelClienteDNI = new System.Windows.Forms.Label();
            this.labelClienteDireccion = new System.Windows.Forms.Label();
            this.labelClienteTelefono = new System.Windows.Forms.Label();
            this.labelClienteEmail = new System.Windows.Forms.Label();
            this.labelClienteNombreTitulo = new System.Windows.Forms.Label();
            this.labelClienteDNITitulo = new System.Windows.Forms.Label();
            this.labelClienteDireccionTitulo = new System.Windows.Forms.Label();
            this.labelClienteTelefonoTitulo = new System.Windows.Forms.Label();
            this.labelClienteEmailTitulo = new System.Windows.Forms.Label();

            this.dataGridViewDetalle = new System.Windows.Forms.DataGridView();

            this.groupBoxVenta.SuspendLayout();
            this.groupBoxCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalle)).BeginInit();

            this.SuspendLayout();

            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.Location = new System.Drawing.Point(20, 10);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(230, 30);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Detalle de la Venta";
            // 
            // groupBoxVenta
            // 
            this.groupBoxVenta.Controls.Add(this.labelIDVenta);
            this.groupBoxVenta.Controls.Add(this.labelFecha);
            this.groupBoxVenta.Controls.Add(this.labelTotal);
            this.groupBoxVenta.Controls.Add(this.labelIDVentaTitulo);
            this.groupBoxVenta.Controls.Add(this.labelFechaTitulo);
            this.groupBoxVenta.Controls.Add(this.labelTotalTitulo);
            this.groupBoxVenta.Location = new System.Drawing.Point(25, 50);
            this.groupBoxVenta.Name = "groupBoxVenta";
            this.groupBoxVenta.Size = new System.Drawing.Size(500, 90);
            this.groupBoxVenta.TabIndex = 1;
            this.groupBoxVenta.TabStop = false;
            this.groupBoxVenta.Text = "Datos de la Venta";
            // 
            // labelIDVentaTitulo
            // 
            this.labelIDVentaTitulo.AutoSize = true;
            this.labelIDVentaTitulo.Location = new System.Drawing.Point(15, 30);
            this.labelIDVentaTitulo.Name = "labelIDVentaTitulo";
            this.labelIDVentaTitulo.Size = new System.Drawing.Size(63, 15);
            this.labelIDVentaTitulo.TabIndex = 0;
            this.labelIDVentaTitulo.Text = "ID Venta:";
            // 
            // labelIDVenta
            // 
            this.labelIDVenta.AutoSize = true;
            this.labelIDVenta.Location = new System.Drawing.Point(110, 30);
            this.labelIDVenta.Name = "labelIDVenta";
            this.labelIDVenta.Size = new System.Drawing.Size(38, 15);
            this.labelIDVenta.TabIndex = 1;
            this.labelIDVenta.Text = "label1";
            // 
            // labelFechaTitulo
            // 
            this.labelFechaTitulo.AutoSize = true;
            this.labelFechaTitulo.Location = new System.Drawing.Point(15, 55);
            this.labelFechaTitulo.Name = "labelFechaTitulo";
            this.labelFechaTitulo.Size = new System.Drawing.Size(43, 15);
            this.labelFechaTitulo.TabIndex = 2;
            this.labelFechaTitulo.Text = "Fecha:";
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Location = new System.Drawing.Point(110, 55);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(38, 15);
            this.labelFecha.TabIndex = 3;
            this.labelFecha.Text = "label2";
            // 
            // labelTotalTitulo
            // 
            this.labelTotalTitulo.AutoSize = true;
            this.labelTotalTitulo.Location = new System.Drawing.Point(300, 30);
            this.labelTotalTitulo.Name = "labelTotalTitulo";
            this.labelTotalTitulo.Size = new System.Drawing.Size(34, 15);
            this.labelTotalTitulo.TabIndex = 4;
            this.labelTotalTitulo.Text = "Total:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(380, 30);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(38, 15);
            this.labelTotal.TabIndex = 5;
            this.labelTotal.Text = "label3";
            // 
            // groupBoxCliente
            // 
            this.groupBoxCliente.Controls.Add(this.labelClienteNombre);
            this.groupBoxCliente.Controls.Add(this.labelClienteDNI);
            this.groupBoxCliente.Controls.Add(this.labelClienteDireccion);
            this.groupBoxCliente.Controls.Add(this.labelClienteTelefono);
            this.groupBoxCliente.Controls.Add(this.labelClienteEmail);
            this.groupBoxCliente.Controls.Add(this.labelClienteNombreTitulo);
            this.groupBoxCliente.Controls.Add(this.labelClienteDNITitulo);
            this.groupBoxCliente.Controls.Add(this.labelClienteDireccionTitulo);
            this.groupBoxCliente.Controls.Add(this.labelClienteTelefonoTitulo);
            this.groupBoxCliente.Controls.Add(this.labelClienteEmailTitulo);
            this.groupBoxCliente.Location = new System.Drawing.Point(25, 150);
            this.groupBoxCliente.Name = "groupBoxCliente";
            this.groupBoxCliente.Size = new System.Drawing.Size(500, 150);
            this.groupBoxCliente.TabIndex = 2;
            this.groupBoxCliente.TabStop = false;
            this.groupBoxCliente.Text = "Datos del Cliente";
            // 
            // labelClienteNombreTitulo
            // 
            this.labelClienteNombreTitulo.AutoSize = true;
            this.labelClienteNombreTitulo.Location = new System.Drawing.Point(15, 25);
            this.labelClienteNombreTitulo.Name = "labelClienteNombreTitulo";
            this.labelClienteNombreTitulo.Size = new System.Drawing.Size(54, 15);
            this.labelClienteNombreTitulo.TabIndex = 0;
            this.labelClienteNombreTitulo.Text = "Nombre:";
            // 
            // labelClienteNombre
            // 
            this.labelClienteNombre.AutoSize = true;
            this.labelClienteNombre.Location = new System.Drawing.Point(120, 25);
            this.labelClienteNombre.Name = "labelClienteNombre";
            this.labelClienteNombre.Size = new System.Drawing.Size(38, 15);
            this.labelClienteNombre.TabIndex = 1;
            this.labelClienteNombre.Text = "label1";
            // 
            // labelClienteDNITitulo
            // 
            this.labelClienteDNITitulo.AutoSize = true;
            this.labelClienteDNITitulo.Location = new System.Drawing.Point(15, 50);
            this.labelClienteDNITitulo.Name = "labelClienteDNITitulo";
            this.labelClienteDNITitulo.Size = new System.Drawing.Size(29, 15);
            this.labelClienteDNITitulo.TabIndex = 2;
            this.labelClienteDNITitulo.Text = "DNI:";
            // 
            // labelClienteDNI
            // 
            this.labelClienteDNI.AutoSize = true;
            this.labelClienteDNI.Location = new System.Drawing.Point(120, 50);
            this.labelClienteDNI.Name = "labelClienteDNI";
            this.labelClienteDNI.Size = new System.Drawing.Size(38, 15);
            this.labelClienteDNI.TabIndex = 3;
            this.labelClienteDNI.Text = "label2";
            // 
            // labelClienteDireccionTitulo
            // 
            this.labelClienteDireccionTitulo.AutoSize = true;
            this.labelClienteDireccionTitulo.Location = new System.Drawing.Point(15, 75);
            this.labelClienteDireccionTitulo.Name = "labelClienteDireccionTitulo";
            this.labelClienteDireccionTitulo.Size = new System.Drawing.Size(60, 15);
            this.labelClienteDireccionTitulo.TabIndex = 4;
            this.labelClienteDireccionTitulo.Text = "Dirección:";
            // 
            // labelClienteDireccion
            // 
            this.labelClienteDireccion.AutoSize = true;
            this.labelClienteDireccion.Location = new System.Drawing.Point(120, 75);
            this.labelClienteDireccion.Name = "labelClienteDireccion";
            this.labelClienteDireccion.Size = new System.Drawing.Size(38, 15);
            this.labelClienteDireccion.TabIndex = 5;
            this.labelClienteDireccion.Text = "label3";
            // 
            // labelClienteTelefonoTitulo
            // 
            this.labelClienteTelefonoTitulo.AutoSize = true;
            this.labelClienteTelefonoTitulo.Location = new System.Drawing.Point(15, 100);
            this.labelClienteTelefonoTitulo.Name = "labelClienteTelefonoTitulo";
            this.labelClienteTelefonoTitulo.Size = new System.Drawing.Size(56, 15);
            this.labelClienteTelefonoTitulo.TabIndex = 6;
            this.labelClienteTelefonoTitulo.Text = "Teléfono:";
            // 
            // labelClienteTelefono
            // 
            this.labelClienteTelefono.AutoSize = true;
            this.labelClienteTelefono.Location = new System.Drawing.Point(120, 100);
            this.labelClienteTelefono.Name = "labelClienteTelefono";
            this.labelClienteTelefono.Size = new System.Drawing.Size(38, 15);
            this.labelClienteTelefono.TabIndex = 7;
            this.labelClienteTelefono.Text = "label4";
            // 
            // labelClienteEmailTitulo
            // 
            this.labelClienteEmailTitulo.AutoSize = true;
            this.labelClienteEmailTitulo.Location = new System.Drawing.Point(15, 125);
            this.labelClienteEmailTitulo.Name = "labelClienteEmailTitulo";
            this.labelClienteEmailTitulo.Size = new System.Drawing.Size(39, 15);
            this.labelClienteEmailTitulo.TabIndex = 8;
            this.labelClienteEmailTitulo.Text = "Email:";
            // 
            // labelClienteEmail
            // 
            this.labelClienteEmail.AutoSize = true;
            this.labelClienteEmail.Location = new System.Drawing.Point(120, 125);
            this.labelClienteEmail.Name = "labelClienteEmail";
            this.labelClienteEmail.Size = new System.Drawing.Size(38, 15);
            this.labelClienteEmail.TabIndex = 9;
            this.labelClienteEmail.Text = "label5";
            // 
            // dataGridViewDetalle
            // 
            this.dataGridViewDetalle.AllowUserToAddRows = false;
            this.dataGridViewDetalle.AllowUserToDeleteRows = false;
            this.dataGridViewDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetalle.Location = new System.Drawing.Point(25, 320);
            this.dataGridViewDetalle.Name = "dataGridViewDetalle";
            this.dataGridViewDetalle.ReadOnly = true;
            this.dataGridViewDetalle.RowHeadersVisible = false;
            this.dataGridViewDetalle.RowTemplate.Height = 25;
            this.dataGridViewDetalle.Size = new System.Drawing.Size(500, 200);
            this.dataGridViewDetalle.TabIndex = 3;

            // 
            // FrmDetalleVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 550);
            this.Controls.Add(this.dataGridViewDetalle);
            this.Controls.Add(this.groupBoxCliente);
            this.Controls.Add(this.groupBoxVenta);
            this.Controls.Add(this.labelTitulo);
            this.Name = "FrmDetalleVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de Venta";

            this.groupBoxVenta.ResumeLayout(false);
            this.groupBoxVenta.PerformLayout();
            this.groupBoxCliente.ResumeLayout(false);
            this.groupBoxCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalle)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelTitulo;

        private System.Windows.Forms.GroupBox groupBoxVenta;
        private System.Windows.Forms.Label labelIDVenta;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelIDVentaTitulo;
        private System.Windows.Forms.Label labelFechaTitulo;
        private System.Windows.Forms.Label labelTotalTitulo;

        private System.Windows.Forms.GroupBox groupBoxCliente;
        private System.Windows.Forms.Label labelClienteNombre;
        private System.Windows.Forms.Label labelClienteDNI;
        private System.Windows.Forms.Label labelClienteDireccion;
        private System.Windows.Forms.Label labelClienteTelefono;
        private System.Windows.Forms.Label labelClienteEmail;
        private System.Windows.Forms.Label labelClienteNombreTitulo;
        private System.Windows.Forms.Label labelClienteDNITitulo;
        private System.Windows.Forms.Label labelClienteDireccionTitulo;
        private System.Windows.Forms.Label labelClienteTelefonoTitulo;
        private System.Windows.Forms.Label labelClienteEmailTitulo;

        private System.Windows.Forms.DataGridView dataGridViewDetalle;
    }
}
