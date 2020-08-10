namespace PalcoNet
{
    partial class principal
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
            this.btnaceptar = new System.Windows.Forms.Button();
            this.btnlogout = new System.Windows.Forms.Button();
            this.cbfunc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCambiarPass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnaceptar
            // 
            this.btnaceptar.Location = new System.Drawing.Point(197, 194);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(75, 23);
            this.btnaceptar.TabIndex = 0;
            this.btnaceptar.Text = "Aceptar";
            this.btnaceptar.UseVisualStyleBackColor = true;
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // btnlogout
            // 
            this.btnlogout.Location = new System.Drawing.Point(12, 194);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(75, 23);
            this.btnlogout.TabIndex = 1;
            this.btnlogout.Text = "Logout";
            this.btnlogout.UseVisualStyleBackColor = true;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // cbfunc
            // 
            this.cbfunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbfunc.FormattingEnabled = true;
            this.cbfunc.Location = new System.Drawing.Point(60, 101);
            this.cbfunc.Name = "cbfunc";
            this.cbfunc.Size = new System.Drawing.Size(163, 21);
            this.cbfunc.TabIndex = 2;
            this.cbfunc.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Funcionalidad";
            // 
            // lblUsr
            // 
            this.lblUsr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUsr.Location = new System.Drawing.Point(86, 50);
            this.lblUsr.Name = "lblUsr";
            this.lblUsr.Size = new System.Drawing.Size(100, 23);
            this.lblUsr.TabIndex = 4;
            this.lblUsr.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "User";
            // 
            // btnCambiarPass
            // 
            this.btnCambiarPass.Location = new System.Drawing.Point(77, 150);
            this.btnCambiarPass.Name = "btnCambiarPass";
            this.btnCambiarPass.Size = new System.Drawing.Size(119, 23);
            this.btnCambiarPass.TabIndex = 6;
            this.btnCambiarPass.Text = "Cambiar Contraseña";
            this.btnCambiarPass.UseVisualStyleBackColor = true;
            this.btnCambiarPass.Click += new System.EventHandler(this.btnCambiarPass_Click);
            // 
            // principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 235);
            this.Controls.Add(this.btnCambiarPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblUsr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbfunc);
            this.Controls.Add(this.btnlogout);
            this.Controls.Add(this.btnaceptar);
            this.Name = "principal";
            this.Text = "principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.principal_FormClosed);
            this.Load += new System.EventHandler(this.principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnaceptar;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.ComboBox cbfunc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCambiarPass;
    }
}