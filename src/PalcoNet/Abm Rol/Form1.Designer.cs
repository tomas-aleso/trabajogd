namespace PalcoNet.Abm_Rol
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
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvRol = new System.Windows.Forms.DataGridView();
            this.dgvFuncionalidad = new System.Windows.Forms.DataGridView();
            this.btnEliFunc = new System.Windows.Forms.Button();
            this.cbFunc = new System.Windows.Forms.ComboBox();
            this.btnAgrFunc = new System.Windows.Forms.Button();
            this.txtEdicion = new System.Windows.Forms.TextBox();
            this.txtAgregar = new System.Windows.Forms.TextBox();
            this.btnHabilitar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionalidad)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(12, 181);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 210);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(12, 239);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvRol
            // 
            this.dgvRol.AllowUserToAddRows = false;
            this.dgvRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRol.Location = new System.Drawing.Point(12, 25);
            this.dgvRol.Name = "dgvRol";
            this.dgvRol.ReadOnly = true;
            this.dgvRol.Size = new System.Drawing.Size(243, 150);
            this.dgvRol.TabIndex = 4;
            this.dgvRol.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRol_CellClick);
            // 
            // dgvFuncionalidad
            // 
            this.dgvFuncionalidad.AllowUserToAddRows = false;
            this.dgvFuncionalidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFuncionalidad.Location = new System.Drawing.Point(269, 25);
            this.dgvFuncionalidad.Name = "dgvFuncionalidad";
            this.dgvFuncionalidad.ReadOnly = true;
            this.dgvFuncionalidad.Size = new System.Drawing.Size(240, 150);
            this.dgvFuncionalidad.TabIndex = 5;
            this.dgvFuncionalidad.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFuncionalidad_CellClick);
            // 
            // btnEliFunc
            // 
            this.btnEliFunc.Location = new System.Drawing.Point(515, 25);
            this.btnEliFunc.Name = "btnEliFunc";
            this.btnEliFunc.Size = new System.Drawing.Size(75, 23);
            this.btnEliFunc.TabIndex = 6;
            this.btnEliFunc.Text = "Eliminar";
            this.btnEliFunc.UseVisualStyleBackColor = true;
            this.btnEliFunc.Click += new System.EventHandler(this.btnEliFunc_Click);
            // 
            // cbFunc
            // 
            this.cbFunc.FormattingEnabled = true;
            this.cbFunc.Location = new System.Drawing.Point(388, 184);
            this.cbFunc.Name = "cbFunc";
            this.cbFunc.Size = new System.Drawing.Size(121, 21);
            this.cbFunc.TabIndex = 7;
            // 
            // btnAgrFunc
            // 
            this.btnAgrFunc.Location = new System.Drawing.Point(515, 184);
            this.btnAgrFunc.Name = "btnAgrFunc";
            this.btnAgrFunc.Size = new System.Drawing.Size(75, 23);
            this.btnAgrFunc.TabIndex = 8;
            this.btnAgrFunc.Text = "Agregar";
            this.btnAgrFunc.UseVisualStyleBackColor = true;
            this.btnAgrFunc.Click += new System.EventHandler(this.btnAgrFunc_Click);
            // 
            // txtEdicion
            // 
            this.txtEdicion.Location = new System.Drawing.Point(93, 181);
            this.txtEdicion.Name = "txtEdicion";
            this.txtEdicion.Size = new System.Drawing.Size(75, 20);
            this.txtEdicion.TabIndex = 9;
            // 
            // txtAgregar
            // 
            this.txtAgregar.Location = new System.Drawing.Point(93, 210);
            this.txtAgregar.Name = "txtAgregar";
            this.txtAgregar.Size = new System.Drawing.Size(74, 20);
            this.txtAgregar.TabIndex = 10;
            // 
            // btnHabilitar
            // 
            this.btnHabilitar.Location = new System.Drawing.Point(93, 239);
            this.btnHabilitar.Name = "btnHabilitar";
            this.btnHabilitar.Size = new System.Drawing.Size(75, 23);
            this.btnHabilitar.TabIndex = 11;
            this.btnHabilitar.Text = "Habilitar";
            this.btnHabilitar.UseVisualStyleBackColor = true;
            this.btnHabilitar.Click += new System.EventHandler(this.btnHabilitar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 269);
            this.Controls.Add(this.btnHabilitar);
            this.Controls.Add(this.txtAgregar);
            this.Controls.Add(this.txtEdicion);
            this.Controls.Add(this.btnAgrFunc);
            this.Controls.Add(this.cbFunc);
            this.Controls.Add(this.btnEliFunc);
            this.Controls.Add(this.dgvFuncionalidad);
            this.Controls.Add(this.dgvRol);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnEditar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionalidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvRol;
        private System.Windows.Forms.DataGridView dgvFuncionalidad;
        private System.Windows.Forms.Button btnEliFunc;
        private System.Windows.Forms.ComboBox cbFunc;
        private System.Windows.Forms.Button btnAgrFunc;
        private System.Windows.Forms.TextBox txtEdicion;
        private System.Windows.Forms.TextBox txtAgregar;
        private System.Windows.Forms.Button btnHabilitar;


    }
}