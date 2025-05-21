namespace AppCRUD.CP
{
    partial class FrmVentas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.CheckBox checkBoxMostrarHistorial;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.TextBox textBoxFecha;
        private System.Windows.Forms.GroupBox groupBoxAgregarArticulo;
        private System.Windows.Forms.Label labelArticulo;
        private System.Windows.Forms.Label labelCantidad;
        private System.Windows.Forms.TextBox textBoxCantidad;
        private System.Windows.Forms.Label labelPrecioUnitario;
        private System.Windows.Forms.TextBox textBoxPrecioUnitario;
        private System.Windows.Forms.Button btnAgregarArticulo;
        private System.Windows.Forms.DataGridView dataGridViewDetalle;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Button btnEliminarArticulo;
        private System.Windows.Forms.Button btnGuardarVenta;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox textBoxBuscarArticulo;
        private System.Windows.Forms.Button btnPaginaAnterior;
        private System.Windows.Forms.Button btnPaginaSiguiente;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            labelCliente = new Label();
            comboBoxCliente = new ComboBox();
            checkBoxMostrarHistorial = new CheckBox();
            labelFecha = new Label();
            textBoxFecha = new TextBox();
            groupBoxAgregarArticulo = new GroupBox();
            btnPaginaAnterior = new Button();
            dataGridViewArticulos = new DataGridView();
            btnPaginaSiguiente = new Button();
            btnAgregarArticulo = new Button();
            textBoxBuscarArticulo = new TextBox();
            textBoxPrecioUnitario = new TextBox();
            labelPrecioUnitario = new Label();
            textBoxCantidad = new TextBox();
            labelCantidad = new Label();
            comboBoxArticulo = new ComboBox();
            labelArticulo = new Label();
            dataGridViewDetalle = new DataGridView();
            labelTotal = new Label();
            textBoxTotal = new TextBox();
            btnEliminarArticulo = new Button();
            btnGuardarVenta = new Button();
            btnCancelar = new Button();
            groupBoxAgregarArticulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArticulos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalle).BeginInit();
            SuspendLayout();
            // 
            // labelCliente
            // 
            labelCliente.AutoSize = true;
            labelCliente.Location = new Point(30, 25);
            labelCliente.Name = "labelCliente";
            labelCliente.Size = new Size(58, 20);
            labelCliente.TabIndex = 14;
            labelCliente.Text = "Cliente:";
            // 
            // comboBoxCliente
            // 
            comboBoxCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCliente.Location = new Point(90, 22);
            comboBoxCliente.Name = "comboBoxCliente";
            comboBoxCliente.Size = new Size(260, 28);
            comboBoxCliente.TabIndex = 13;
            // 
            // checkBoxMostrarHistorial
            // 
            checkBoxMostrarHistorial.AutoSize = true;
            checkBoxMostrarHistorial.Location = new Point(360, 25);
            checkBoxMostrarHistorial.Name = "checkBoxMostrarHistorial";
            checkBoxMostrarHistorial.Size = new Size(187, 24);
            checkBoxMostrarHistorial.TabIndex = 12;
            checkBoxMostrarHistorial.Text = "Mostrar historial cliente";
            checkBoxMostrarHistorial.CheckedChanged += checkBoxMostrarHistorial_CheckedChanged;
            // 
            // labelFecha
            // 
            labelFecha.AutoSize = true;
            labelFecha.Location = new Point(600, 25);
            labelFecha.Name = "labelFecha";
            labelFecha.Size = new Size(50, 20);
            labelFecha.TabIndex = 11;
            labelFecha.Text = "Fecha:";
            // 
            // textBoxFecha
            // 
            textBoxFecha.Location = new Point(660, 22);
            textBoxFecha.Name = "textBoxFecha";
            textBoxFecha.ReadOnly = true;
            textBoxFecha.Size = new Size(140, 27);
            textBoxFecha.TabIndex = 10;
            // 
            // groupBoxAgregarArticulo
            // 
            groupBoxAgregarArticulo.Controls.Add(btnPaginaAnterior);
            groupBoxAgregarArticulo.Controls.Add(dataGridViewArticulos);
            groupBoxAgregarArticulo.Controls.Add(btnPaginaSiguiente);
            groupBoxAgregarArticulo.Controls.Add(btnAgregarArticulo);
            groupBoxAgregarArticulo.Controls.Add(textBoxBuscarArticulo);
            groupBoxAgregarArticulo.Controls.Add(textBoxPrecioUnitario);
            groupBoxAgregarArticulo.Controls.Add(labelPrecioUnitario);
            groupBoxAgregarArticulo.Controls.Add(textBoxCantidad);
            groupBoxAgregarArticulo.Controls.Add(labelCantidad);
            groupBoxAgregarArticulo.Controls.Add(comboBoxArticulo);
            groupBoxAgregarArticulo.Controls.Add(labelArticulo);
            groupBoxAgregarArticulo.Location = new Point(40, 60);
            groupBoxAgregarArticulo.Name = "groupBoxAgregarArticulo";
            groupBoxAgregarArticulo.Size = new Size(780, 247);
            groupBoxAgregarArticulo.TabIndex = 9;
            groupBoxAgregarArticulo.TabStop = false;
            groupBoxAgregarArticulo.Text = "Agregar Artículo";
            // 
            // btnPaginaAnterior
            // 
            btnPaginaAnterior.Location = new Point(499, 99);
            btnPaginaAnterior.Name = "btnPaginaAnterior";
            btnPaginaAnterior.Size = new Size(30, 27);
            btnPaginaAnterior.TabIndex = 0;
            btnPaginaAnterior.Text = "–";
            // 
            // dataGridViewArticulos
            // 
            dataGridViewArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewArticulos.Location = new Point(20, 66);
            dataGridViewArticulos.Name = "dataGridViewArticulos";
            dataGridViewArticulos.RowHeadersWidth = 51;
            dataGridViewArticulos.Size = new Size(457, 175);
            dataGridViewArticulos.TabIndex = 7;
            // 
            // btnPaginaSiguiente
            // 
            btnPaginaSiguiente.Location = new Point(570, 99);
            btnPaginaSiguiente.Name = "btnPaginaSiguiente";
            btnPaginaSiguiente.Size = new Size(30, 27);
            btnPaginaSiguiente.TabIndex = 1;
            btnPaginaSiguiente.Text = "+";
            // 
            // btnAgregarArticulo
            // 
            btnAgregarArticulo.Location = new Point(690, 30);
            btnAgregarArticulo.Name = "btnAgregarArticulo";
            btnAgregarArticulo.Size = new Size(75, 30);
            btnAgregarArticulo.TabIndex = 0;
            btnAgregarArticulo.Text = "Agregar";
            btnAgregarArticulo.Click += btnAgregarArticulo_Click;
            // 
            // textBoxBuscarArticulo
            // 
            textBoxBuscarArticulo.Location = new Point(483, 66);
            textBoxBuscarArticulo.Name = "textBoxBuscarArticulo";
            textBoxBuscarArticulo.PlaceholderText = "Buscar artículo...";
            textBoxBuscarArticulo.Size = new Size(152, 27);
            textBoxBuscarArticulo.TabIndex = 2;
            textBoxBuscarArticulo.TextChanged += textBoxBuscarArticulo_TextChanged_1;
            // 
            // textBoxPrecioUnitario
            // 
            textBoxPrecioUnitario.Location = new Point(590, 32);
            textBoxPrecioUnitario.Name = "textBoxPrecioUnitario";
            textBoxPrecioUnitario.Size = new Size(90, 27);
            textBoxPrecioUnitario.TabIndex = 1;
            // 
            // labelPrecioUnitario
            // 
            labelPrecioUnitario.AutoSize = true;
            labelPrecioUnitario.Location = new Point(480, 35);
            labelPrecioUnitario.Name = "labelPrecioUnitario";
            labelPrecioUnitario.Size = new Size(110, 20);
            labelPrecioUnitario.TabIndex = 2;
            labelPrecioUnitario.Text = "Precio Unitario:";
            // 
            // textBoxCantidad
            // 
            textBoxCantidad.Location = new Point(385, 32);
            textBoxCantidad.Name = "textBoxCantidad";
            textBoxCantidad.Size = new Size(80, 27);
            textBoxCantidad.TabIndex = 3;
            // 
            // labelCantidad
            // 
            labelCantidad.AutoSize = true;
            labelCantidad.Location = new Point(310, 35);
            labelCantidad.Name = "labelCantidad";
            labelCantidad.Size = new Size(72, 20);
            labelCantidad.TabIndex = 4;
            labelCantidad.Text = "Cantidad:";
            // 
            // comboBoxArticulo
            // 
            comboBoxArticulo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxArticulo.Location = new Point(85, 32);
            comboBoxArticulo.Name = "comboBoxArticulo";
            comboBoxArticulo.Size = new Size(200, 28);
            comboBoxArticulo.TabIndex = 5;
            // 
            // labelArticulo
            // 
            labelArticulo.AutoSize = true;
            labelArticulo.Location = new Point(20, 35);
            labelArticulo.Name = "labelArticulo";
            labelArticulo.Size = new Size(64, 20);
            labelArticulo.TabIndex = 6;
            labelArticulo.Text = "Artículo:";
            // 
            // dataGridViewDetalle
            // 
            dataGridViewDetalle.AllowUserToAddRows = false;
            dataGridViewDetalle.AllowUserToDeleteRows = false;
            dataGridViewDetalle.ColumnHeadersHeight = 29;
            dataGridViewDetalle.Location = new Point(30, 328);
            dataGridViewDetalle.MultiSelect = false;
            dataGridViewDetalle.Name = "dataGridViewDetalle";
            dataGridViewDetalle.ReadOnly = true;
            dataGridViewDetalle.RowHeadersWidth = 51;
            dataGridViewDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDetalle.Size = new Size(780, 220);
            dataGridViewDetalle.TabIndex = 8;
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Location = new Point(610, 578);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(45, 20);
            labelTotal.TabIndex = 7;
            labelTotal.Text = "Total:";
            // 
            // textBoxTotal
            // 
            textBoxTotal.Location = new Point(670, 571);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.ReadOnly = true;
            textBoxTotal.Size = new Size(160, 27);
            textBoxTotal.TabIndex = 6;
            textBoxTotal.Text = "0.00";
            // 
            // btnEliminarArticulo
            // 
            btnEliminarArticulo.Location = new Point(22, 611);
            btnEliminarArticulo.Name = "btnEliminarArticulo";
            btnEliminarArticulo.Size = new Size(120, 30);
            btnEliminarArticulo.TabIndex = 5;
            btnEliminarArticulo.Text = "Eliminar Artículo";
            btnEliminarArticulo.Click += btnEliminarArticulo_Click;
            // 
            // btnGuardarVenta
            // 
            btnGuardarVenta.Location = new Point(584, 624);
            btnGuardarVenta.Name = "btnGuardarVenta";
            btnGuardarVenta.Size = new Size(120, 35);
            btnGuardarVenta.TabIndex = 4;
            btnGuardarVenta.Text = "Guardar Venta";
            btnGuardarVenta.Click += btnGuardarVenta_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(720, 624);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 35);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 679);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardarVenta);
            Controls.Add(btnEliminarArticulo);
            Controls.Add(textBoxTotal);
            Controls.Add(labelTotal);
            Controls.Add(dataGridViewDetalle);
            Controls.Add(groupBoxAgregarArticulo);
            Controls.Add(textBoxFecha);
            Controls.Add(labelFecha);
            Controls.Add(checkBoxMostrarHistorial);
            Controls.Add(comboBoxCliente);
            Controls.Add(labelCliente);
            Name = "FrmVentas";
            Text = "Registro de Ventas";
            groupBoxAgregarArticulo.ResumeLayout(false);
            groupBoxAgregarArticulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArticulos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private DataGridView dataGridViewArticulos;
        private ComboBox comboBoxArticulo;
    }
}
