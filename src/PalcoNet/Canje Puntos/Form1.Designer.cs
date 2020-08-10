namespace PalcoNet.Canje_Puntos
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
            this.txtPuntos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.rbCompra = new System.Windows.Forms.RadioButton();
            this.rbAuri = new System.Windows.Forms.RadioButton();
            this.rbViaje = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtPuntos
            // 
            this.txtPuntos.Location = new System.Drawing.Point(133, 39);
            this.txtPuntos.Name = "txtPuntos";
            this.txtPuntos.ReadOnly = true;
            this.txtPuntos.Size = new System.Drawing.Size(100, 20);
            this.txtPuntos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Puntos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Premios";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "500 puntos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "1000 puntos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "1500 puntos";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(111, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Canjear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbCompra
            // 
            this.rbCompra.AutoSize = true;
            this.rbCompra.Location = new System.Drawing.Point(148, 134);
            this.rbCompra.Name = "rbCompra";
            this.rbCompra.Size = new System.Drawing.Size(106, 17);
            this.rbCompra.TabIndex = 12;
            this.rbCompra.TabStop = true;
            this.rbCompra.Text = "Compra por $500";
            this.rbCompra.UseVisualStyleBackColor = true;
            // 
            // rbAuri
            // 
            this.rbAuri.AutoSize = true;
            this.rbAuri.Location = new System.Drawing.Point(148, 157);
            this.rbAuri.Name = "rbAuri";
            this.rbAuri.Size = new System.Drawing.Size(122, 17);
            this.rbAuri.TabIndex = 13;
            this.rbAuri.TabStop = true;
            this.rbAuri.Text = "Auricular Sennheiser";
            this.rbAuri.UseVisualStyleBackColor = true;
            // 
            // rbViaje
            // 
            this.rbViaje.AutoSize = true;
            this.rbViaje.Location = new System.Drawing.Point(148, 180);
            this.rbViaje.Name = "rbViaje";
            this.rbViaje.Size = new System.Drawing.Size(132, 17);
            this.rbViaje.TabIndex = 14;
            this.rbViaje.TabStop = true;
            this.rbViaje.Text = "Viaje de fin de semana";
            this.rbViaje.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 271);
            this.Controls.Add(this.rbViaje);
            this.Controls.Add(this.rbAuri);
            this.Controls.Add(this.rbCompra);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPuntos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPuntos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbCompra;
        private System.Windows.Forms.RadioButton rbAuri;
        private System.Windows.Forms.RadioButton rbViaje;
    }
}