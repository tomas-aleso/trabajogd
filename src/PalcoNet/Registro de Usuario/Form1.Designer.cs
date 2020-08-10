namespace PalcoNet.Registro_de_Usuario
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
            this.btnAtras = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtusr = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.btnSig = new System.Windows.Forms.Button();
            this.rbtnClie = new System.Windows.Forms.RadioButton();
            this.rbtnEmp = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdniCuil = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(39, 219);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(75, 23);
            this.btnAtras.TabIndex = 4;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña";
            // 
            // txtusr
            // 
            this.txtusr.Location = new System.Drawing.Point(143, 27);
            this.txtusr.Name = "txtusr";
            this.txtusr.Size = new System.Drawing.Size(100, 20);
            this.txtusr.TabIndex = 0;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(143, 65);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(100, 20);
            this.txtpass.TabIndex = 1;
            // 
            // btnSig
            // 
            this.btnSig.Location = new System.Drawing.Point(168, 219);
            this.btnSig.Name = "btnSig";
            this.btnSig.Size = new System.Drawing.Size(75, 23);
            this.btnSig.TabIndex = 3;
            this.btnSig.Text = "Siguiente";
            this.btnSig.UseVisualStyleBackColor = true;
            this.btnSig.Click += new System.EventHandler(this.btnSig_Click);
            // 
            // rbtnClie
            // 
            this.rbtnClie.AutoSize = true;
            this.rbtnClie.Location = new System.Drawing.Point(39, 169);
            this.rbtnClie.Name = "rbtnClie";
            this.rbtnClie.Size = new System.Drawing.Size(57, 17);
            this.rbtnClie.TabIndex = 6;
            this.rbtnClie.TabStop = true;
            this.rbtnClie.Text = "Cliente";
            this.rbtnClie.UseVisualStyleBackColor = true;
            // 
            // rbtnEmp
            // 
            this.rbtnEmp.AutoSize = true;
            this.rbtnEmp.Location = new System.Drawing.Point(168, 169);
            this.rbtnEmp.Name = "rbtnEmp";
            this.rbtnEmp.Size = new System.Drawing.Size(66, 17);
            this.rbtnEmp.TabIndex = 7;
            this.rbtnEmp.TabStop = true;
            this.rbtnEmp.Text = "Empresa";
            this.rbtnEmp.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Documento/CUIT";
            // 
            // txtdniCuil
            // 
            this.txtdniCuil.Location = new System.Drawing.Point(143, 107);
            this.txtdniCuil.MaxLength = 14;
            this.txtdniCuil.Name = "txtdniCuil";
            this.txtdniCuil.Size = new System.Drawing.Size(100, 20);
            this.txtdniCuil.TabIndex = 2;
            this.txtdniCuil.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdniCuil_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtdniCuil);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbtnEmp);
            this.Controls.Add(this.rbtnClie);
            this.Controls.Add(this.btnSig);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtusr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAtras);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtusr;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Button btnSig;
        private System.Windows.Forms.RadioButton rbtnClie;
        private System.Windows.Forms.RadioButton rbtnEmp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdniCuil;
    }
}