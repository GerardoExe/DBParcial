namespace AppCRUD
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btncliente = new Button();
            btnVentas = new Button();
            btnArticulos = new Button();
            SuspendLayout();
            // 
            // btncliente
            // 
            btncliente.Location = new Point(165, 107);
            btncliente.Name = "btncliente";
            btncliente.Size = new Size(162, 66);
            btncliente.TabIndex = 0;
            btncliente.Text = "Cliente";
            btncliente.UseVisualStyleBackColor = true;
            btncliente.Click += btncliente_Click;
            // 
            // btnVentas
            // 
            btnVentas.Location = new Point(518, 107);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(172, 66);
            btnVentas.TabIndex = 1;
            btnVentas.Text = "Ventas";
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnArticulos
            // 
            btnArticulos.Location = new Point(319, 234);
            btnArticulos.Name = "btnArticulos";
            btnArticulos.Size = new Size(164, 64);
            btnArticulos.TabIndex = 2;
            btnArticulos.Text = "Articulos";
            btnArticulos.UseVisualStyleBackColor = true;
            btnArticulos.Click += btnArticulos_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnArticulos);
            Controls.Add(btnVentas);
            Controls.Add(btncliente);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btncliente;
        private Button btnVentas;
        private Button btnArticulos;
    }
}