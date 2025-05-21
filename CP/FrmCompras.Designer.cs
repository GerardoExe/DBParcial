namespace AppCRUD.CP
{
    partial class FrmCompras
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            label1 = new Label();
            comboBoxProveedor = new ComboBox();
            label2 = new Label();
            textBoxFecha = new TextBox();
            groupBoxAgregarArticulo = new GroupBox();
            label3 = new Label();
            comboBoxArticulo = new ComboBox();
            label4 = new Label();
            textBoxCantidad = new TextBox();
            label5 = new Label();
            textBoxPrecioUnitario = new TextBox();
            btnAgregarArticulo = new Button();
            btnEliminarArticulo = new Button();
            dataGridViewDetalle = new DataGridView();
            label6 = new Label();
            textBoxTotal = new TextBox();
            btnGuardarCompra = new Button();
            btnCancelar = new Button();
            checkBoxMostrarHistorial = new CheckBox();
            groupBoxAgregarArticulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalle).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 22);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "Proveedor:";
            // 
            // comboBoxProveedor
            // 
            comboBoxProveedor.FormattingEnabled = true;
            comboBoxProveedor.Location = new Point(90, 19);
            comboBoxProveedor.Name = "comboBoxProveedor";
            comboBoxProveedor.Size = new Size(200, 28);
            comboBoxProveedor.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(320, 22);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 2;
            label2.Text = "Fecha:";
            // 
            // textBoxFecha
            // 
            textBoxFecha.Enabled = false;
            textBoxFecha.Location = new Point(370, 19);
            textBoxFecha.Name = "textBoxFecha";
            textBoxFecha.Size = new Size(100, 27);
            textBoxFecha.TabIndex = 3;
            // 
            // groupBoxAgregarArticulo
            // 
            groupBoxAgregarArticulo.Controls.Add(label3);
            groupBoxAgregarArticulo.Controls.Add(comboBoxArticulo);
            groupBoxAgregarArticulo.Controls.Add(label4);
            groupBoxAgregarArticulo.Controls.Add(textBoxCantidad);
            groupBoxAgregarArticulo.Controls.Add(label5);
            groupBoxAgregarArticulo.Controls.Add(textBoxPrecioUnitario);
            groupBoxAgregarArticulo.Controls.Add(btnAgregarArticulo);
            groupBoxAgregarArticulo.Location = new Point(22, 60);
            groupBoxAgregarArticulo.Name = "groupBoxAgregarArticulo";
            groupBoxAgregarArticulo.Size = new Size(672, 90);
            groupBoxAgregarArticulo.TabIndex = 4;
            groupBoxAgregarArticulo.TabStop = false;
            groupBoxAgregarArticulo.Text = "Agregar artículo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 26);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 0;
            label3.Text = "Artículo:";
            // 
            // comboBoxArticulo
            // 
            comboBoxArticulo.FormattingEnabled = true;
            comboBoxArticulo.Location = new Point(84, 23);
            comboBoxArticulo.Name = "comboBoxArticulo";
            comboBoxArticulo.Size = new Size(150, 28);
            comboBoxArticulo.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(240, 26);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 2;
            label4.Text = "Cantidad:";
            // 
            // textBoxCantidad
            // 
            textBoxCantidad.Location = new Point(318, 23);
            textBoxCantidad.Name = "textBoxCantidad";
            textBoxCantidad.Size = new Size(72, 27);
            textBoxCantidad.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(396, 26);
            label5.Name = "label5";
            label5.Size = new Size(108, 20);
            label5.TabIndex = 4;
            label5.Text = "Precio unitario:";
            // 
            // textBoxPrecioUnitario
            // 
            textBoxPrecioUnitario.Location = new Point(510, 23);
            textBoxPrecioUnitario.Name = "textBoxPrecioUnitario";
            textBoxPrecioUnitario.Size = new Size(90, 27);
            textBoxPrecioUnitario.TabIndex = 5;
            // 
            // btnAgregarArticulo
            // 
            btnAgregarArticulo.Location = new Point(250, 59);
            btnAgregarArticulo.Name = "btnAgregarArticulo";
            btnAgregarArticulo.Size = new Size(110, 25);
            btnAgregarArticulo.TabIndex = 6;
            btnAgregarArticulo.Text = "Agregar";
            btnAgregarArticulo.UseVisualStyleBackColor = true;
            btnAgregarArticulo.Click += BtnAgregarArticulo_Click;
            // 
            // btnEliminarArticulo
            // 
            btnEliminarArticulo.Location = new Point(700, 81);
            btnEliminarArticulo.Name = "btnEliminarArticulo";
            btnEliminarArticulo.Size = new Size(100, 25);
            btnEliminarArticulo.TabIndex = 5;
            btnEliminarArticulo.Text = "Eliminar artículo";
            btnEliminarArticulo.UseVisualStyleBackColor = true;
            btnEliminarArticulo.Click += BtnEliminarArticulo_Click;
            // 
            // dataGridViewDetalle
            // 
            dataGridViewDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDetalle.Location = new Point(22, 160);
            dataGridViewDetalle.Name = "dataGridViewDetalle";
            dataGridViewDetalle.RowHeadersWidth = 51;
            dataGridViewDetalle.RowTemplate.Height = 25;
            dataGridViewDetalle.Size = new Size(600, 200);
            dataGridViewDetalle.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(490, 370);
            label6.Name = "label6";
            label6.Size = new Size(45, 20);
            label6.TabIndex = 7;
            label6.Text = "Total:";
            // 
            // textBoxTotal
            // 
            textBoxTotal.Enabled = false;
            textBoxTotal.Location = new Point(532, 367);
            textBoxTotal.Name = "textBoxTotal";
            textBoxTotal.Size = new Size(90, 27);
            textBoxTotal.TabIndex = 8;
            // 
            // btnGuardarCompra
            // 
            btnGuardarCompra.Location = new Point(639, 181);
            btnGuardarCompra.Name = "btnGuardarCompra";
            btnGuardarCompra.Size = new Size(100, 30);
            btnGuardarCompra.TabIndex = 9;
            btnGuardarCompra.Text = "Guardar";
            btnGuardarCompra.UseVisualStyleBackColor = true;
            btnGuardarCompra.Click += BtnGuardarCompra_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(639, 234);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 30);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += BtnCancelar_Click;
            // 
            // checkBoxMostrarHistorial
            // 
            checkBoxMostrarHistorial.AutoSize = true;
            checkBoxMostrarHistorial.Location = new Point(541, 21);
            checkBoxMostrarHistorial.Name = "checkBoxMostrarHistorial";
            checkBoxMostrarHistorial.Size = new Size(139, 24);
            checkBoxMostrarHistorial.TabIndex = 11;
            checkBoxMostrarHistorial.Text = "Mostrar historial";
            checkBoxMostrarHistorial.UseVisualStyleBackColor = true;
            // 
            // FrmCompras
            // 
            ClientSize = new Size(866, 472);
            Controls.Add(checkBoxMostrarHistorial);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardarCompra);
            Controls.Add(textBoxTotal);
            Controls.Add(label6);
            Controls.Add(dataGridViewDetalle);
            Controls.Add(btnEliminarArticulo);
            Controls.Add(groupBoxAgregarArticulo);
            Controls.Add(textBoxFecha);
            Controls.Add(label2);
            Controls.Add(comboBoxProveedor);
            Controls.Add(label1);
            Name = "FrmCompras";
            Text = "Registro de Compras";
            groupBoxAgregarArticulo.ResumeLayout(false);
            groupBoxAgregarArticulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFecha;
        private System.Windows.Forms.GroupBox groupBoxAgregarArticulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxArticulo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPrecioUnitario;
        private System.Windows.Forms.Button btnAgregarArticulo;
        private System.Windows.Forms.Button btnEliminarArticulo;
        private System.Windows.Forms.DataGridView dataGridViewDetalle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Button btnGuardarCompra;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox checkBoxMostrarHistorial;
    }
}
