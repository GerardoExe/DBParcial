namespace AppCRUD.CP
{
    partial class FrmDetalleCompras
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelIDCompra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelProveedorNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.DataGridView dataGridViewDetalle;

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
            this.label1 = new System.Windows.Forms.Label();
            this.labelIDCompra = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelProveedorNombre = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.dataGridViewDetalle = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // label1 - ID Compra
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Text = "ID Compra:";
            // 
            // labelIDCompra
            // 
            this.labelIDCompra.AutoSize = true;
            this.labelIDCompra.Location = new System.Drawing.Point(120, 20);
            this.labelIDCompra.Text = "-";
            // 
            // label2 - Fecha
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Text = "Fecha:";
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Location = new System.Drawing.Point(120, 50);
            this.labelFecha.Text = "-";
            // 
            // label3 - Proveedor
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 80);
            this.label3.Text = "Proveedor:";
            // 
            // labelProveedorNombre
            // 
            this.labelProveedorNombre.AutoSize = true;
            this.labelProveedorNombre.Location = new System.Drawing.Point(120, 80);
            this.labelProveedorNombre.Text = "-";
            // 
            // label4 - Total
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 110);
            this.label4.Text = "Total:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(120, 110);
            this.labelTotal.Text = "-";
            // 
            // dataGridViewDetalle
            // 
            this.dataGridViewDetalle.AllowUserToAddRows = false;
            this.dataGridViewDetalle.AllowUserToDeleteRows = false;
            this.dataGridViewDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetalle.Location = new System.Drawing.Point(20, 150);
            this.dataGridViewDetalle.Name = "dataGridViewDetalle";
            this.dataGridViewDetalle.ReadOnly = true;
            this.dataGridViewDetalle.RowHeadersWidth = 51;
            this.dataGridViewDetalle.RowTemplate.Height = 24;
            this.dataGridViewDetalle.Size = new System.Drawing.Size(740, 300);
            // 
            // FrmDetalleCompras
            // 
            this.ClientSize = new System.Drawing.Size(784, 481);
            this.Controls.Add(this.dataGridViewDetalle);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelProveedorNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelIDCompra);
            this.Controls.Add(this.label1);
            this.Name = "FrmDetalleCompras";
            this.Text = "Detalle de Compra";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
