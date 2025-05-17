namespace AppCRUD.CP
{
    partial class FrmArticulos
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPrecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxStock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxUnidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dataGridViewArticulos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            textBoxNombre = new TextBox();
            label2 = new Label();
            comboBoxCategoria = new ComboBox();
            label3 = new Label();
            textBoxPrecio = new TextBox();
            label4 = new Label();
            textBoxStock = new TextBox();
            label5 = new Label();
            textBoxUnidad = new TextBox();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            dataGridViewArticulos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArticulos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(126, 20);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(200, 27);
            textBoxNombre.TabIndex = 1;
            // 
            // label2
            // 
            label2.Location = new Point(20, 60);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 2;
            label2.Text = "Categoría:";
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCategoria.Location = new Point(126, 57);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(200, 28);
            comboBoxCategoria.TabIndex = 3;
            // 
            // label3
            // 
            label3.Location = new Point(20, 100);
            label3.Name = "label3";
            label3.Size = new Size(100, 23);
            label3.TabIndex = 4;
            label3.Text = "Precio:";
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.Location = new Point(126, 100);
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.Size = new Size(200, 27);
            textBoxPrecio.TabIndex = 5;
            // 
            // label4
            // 
            label4.Location = new Point(20, 140);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 6;
            label4.Text = "Stock:";
            // 
            // textBoxStock
            // 
            textBoxStock.Location = new Point(126, 140);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.Size = new Size(200, 27);
            textBoxStock.TabIndex = 7;
            // 
            // label5
            // 
            label5.Location = new Point(20, 180);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 8;
            label5.Text = "Unidad:";
            // 
            // textBoxUnidad
            // 
            textBoxUnidad.Location = new Point(126, 180);
            textBoxUnidad.Name = "textBoxUnidad";
            textBoxUnidad.Size = new Size(200, 27);
            textBoxUnidad.TabIndex = 9;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(375, 16);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 34);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(375, 59);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 29);
            btnActualizar.TabIndex = 11;
            btnActualizar.Text = "Actualizar";
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(375, 100);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 27);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dataGridViewArticulos
            // 
            dataGridViewArticulos.ColumnHeadersHeight = 29;
            dataGridViewArticulos.Location = new Point(20, 230);
            dataGridViewArticulos.MultiSelect = false;
            dataGridViewArticulos.Name = "dataGridViewArticulos";
            dataGridViewArticulos.ReadOnly = true;
            dataGridViewArticulos.RowHeadersWidth = 51;
            dataGridViewArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewArticulos.Size = new Size(540, 200);
            dataGridViewArticulos.TabIndex = 13;
            dataGridViewArticulos.CellClick += dataGridViewArticulos_CellClick;
            // 
            // FrmArticulos
            // 
            ClientSize = new Size(600, 460);
            Controls.Add(label1);
            Controls.Add(textBoxNombre);
            Controls.Add(label2);
            Controls.Add(comboBoxCategoria);
            Controls.Add(label3);
            Controls.Add(textBoxPrecio);
            Controls.Add(label4);
            Controls.Add(textBoxStock);
            Controls.Add(label5);
            Controls.Add(textBoxUnidad);
            Controls.Add(btnAgregar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(dataGridViewArticulos);
            Name = "FrmArticulos";
            Text = "Gestión de Artículos";
            Load += FrmArticulos_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewArticulos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
