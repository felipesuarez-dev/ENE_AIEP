namespace ENEAIEP
{
    partial class ListaRequerimientosAdmin
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
            this.btnEliminarDeLista = new System.Windows.Forms.Button();
            this.btnMarcarResuelto = new System.Windows.Forms.Button();
            this.btnBuscarEnLista = new System.Windows.Forms.Button();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.chbResueltos = new System.Windows.Forms.CheckBox();
            this.chbPendientes = new System.Windows.Forms.CheckBox();
            this.cmbPrioridadLista = new System.Windows.Forms.ComboBox();
            this.cmbTipoRequerimientoLista = new System.Windows.Forms.ComboBox();
            this.lblResueltos = new System.Windows.Forms.Label();
            this.lblPendientes = new System.Windows.Forms.Label();
            this.lblPrioridadLista = new System.Windows.Forms.Label();
            this.lblTipoRequerimientoLista = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminarDeLista
            // 
            this.btnEliminarDeLista.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnEliminarDeLista.FlatAppearance.BorderSize = 0;
            this.btnEliminarDeLista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarDeLista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnEliminarDeLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDeLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarDeLista.Location = new System.Drawing.Point(359, 384);
            this.btnEliminarDeLista.Name = "btnEliminarDeLista";
            this.btnEliminarDeLista.Size = new System.Drawing.Size(241, 35);
            this.btnEliminarDeLista.TabIndex = 51;
            this.btnEliminarDeLista.Text = "Eliminar";
            this.btnEliminarDeLista.UseVisualStyleBackColor = false;
            this.btnEliminarDeLista.Click += new System.EventHandler(this.btnEliminarDeLista_Click);
            // 
            // btnMarcarResuelto
            // 
            this.btnMarcarResuelto.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnMarcarResuelto.FlatAppearance.BorderSize = 0;
            this.btnMarcarResuelto.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMarcarResuelto.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnMarcarResuelto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcarResuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarcarResuelto.Location = new System.Drawing.Point(33, 384);
            this.btnMarcarResuelto.Name = "btnMarcarResuelto";
            this.btnMarcarResuelto.Size = new System.Drawing.Size(293, 35);
            this.btnMarcarResuelto.TabIndex = 50;
            this.btnMarcarResuelto.Text = "Marcar como Resuelto";
            this.btnMarcarResuelto.UseVisualStyleBackColor = false;
            this.btnMarcarResuelto.Click += new System.EventHandler(this.btnMarcarResuelto_Click);
            // 
            // btnBuscarEnLista
            // 
            this.btnBuscarEnLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarEnLista.Location = new System.Drawing.Point(539, 158);
            this.btnBuscarEnLista.Name = "btnBuscarEnLista";
            this.btnBuscarEnLista.Size = new System.Drawing.Size(120, 41);
            this.btnBuscarEnLista.TabIndex = 49;
            this.btnBuscarEnLista.Text = "Buscar";
            this.btnBuscarEnLista.UseVisualStyleBackColor = true;
            this.btnBuscarEnLista.Click += new System.EventHandler(this.btnBuscarEnLista_Click);
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(33, 247);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.Size = new System.Drawing.Size(649, 116);
            this.dgvLista.TabIndex = 48;
            // 
            // chbResueltos
            // 
            this.chbResueltos.AutoSize = true;
            this.chbResueltos.Location = new System.Drawing.Point(386, 185);
            this.chbResueltos.Name = "chbResueltos";
            this.chbResueltos.Size = new System.Drawing.Size(15, 14);
            this.chbResueltos.TabIndex = 47;
            this.chbResueltos.UseVisualStyleBackColor = true;
            // 
            // chbPendientes
            // 
            this.chbPendientes.AutoSize = true;
            this.chbPendientes.Location = new System.Drawing.Point(151, 185);
            this.chbPendientes.Name = "chbPendientes";
            this.chbPendientes.Size = new System.Drawing.Size(15, 14);
            this.chbPendientes.TabIndex = 46;
            this.chbPendientes.UseVisualStyleBackColor = true;
            // 
            // cmbPrioridadLista
            // 
            this.cmbPrioridadLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrioridadLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPrioridadLista.FormattingEnabled = true;
            this.cmbPrioridadLista.Items.AddRange(new object[] {
            "Alta",
            "Media",
            "Baja",
            "Todos"});
            this.cmbPrioridadLista.Location = new System.Drawing.Point(185, 136);
            this.cmbPrioridadLista.Name = "cmbPrioridadLista";
            this.cmbPrioridadLista.Size = new System.Drawing.Size(240, 24);
            this.cmbPrioridadLista.TabIndex = 45;
            // 
            // cmbTipoRequerimientoLista
            // 
            this.cmbTipoRequerimientoLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRequerimientoLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoRequerimientoLista.FormattingEnabled = true;
            this.cmbTipoRequerimientoLista.Items.AddRange(new object[] {
            "Base de Datos",
            "Sistemas",
            "Servidores",
            "Todos"});
            this.cmbTipoRequerimientoLista.Location = new System.Drawing.Point(185, 92);
            this.cmbTipoRequerimientoLista.Name = "cmbTipoRequerimientoLista";
            this.cmbTipoRequerimientoLista.Size = new System.Drawing.Size(240, 24);
            this.cmbTipoRequerimientoLista.TabIndex = 44;
            // 
            // lblResueltos
            // 
            this.lblResueltos.AutoSize = true;
            this.lblResueltos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResueltos.Location = new System.Drawing.Point(270, 185);
            this.lblResueltos.Name = "lblResueltos";
            this.lblResueltos.Size = new System.Drawing.Size(78, 16);
            this.lblResueltos.TabIndex = 43;
            this.lblResueltos.Text = "Resueltos";
            // 
            // lblPendientes
            // 
            this.lblPendientes.AutoSize = true;
            this.lblPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendientes.Location = new System.Drawing.Point(30, 186);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(86, 16);
            this.lblPendientes.TabIndex = 42;
            this.lblPendientes.Text = "Pendientes";
            // 
            // lblPrioridadLista
            // 
            this.lblPrioridadLista.AutoSize = true;
            this.lblPrioridadLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrioridadLista.Location = new System.Drawing.Point(30, 141);
            this.lblPrioridadLista.Name = "lblPrioridadLista";
            this.lblPrioridadLista.Size = new System.Drawing.Size(76, 16);
            this.lblPrioridadLista.TabIndex = 41;
            this.lblPrioridadLista.Text = "Prioridad:";
            // 
            // lblTipoRequerimientoLista
            // 
            this.lblTipoRequerimientoLista.AutoSize = true;
            this.lblTipoRequerimientoLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoRequerimientoLista.Location = new System.Drawing.Point(30, 97);
            this.lblTipoRequerimientoLista.Name = "lblTipoRequerimientoLista";
            this.lblTipoRequerimientoLista.Size = new System.Drawing.Size(149, 16);
            this.lblTipoRequerimientoLista.TabIndex = 40;
            this.lblTipoRequerimientoLista.Text = "Tipo Requerimiento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 24);
            this.label1.TabIndex = 39;
            this.label1.Text = "Lista de Requerimientos";
            // 
            // ListaRequerimientosAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 455);
            this.Controls.Add(this.btnEliminarDeLista);
            this.Controls.Add(this.btnMarcarResuelto);
            this.Controls.Add(this.btnBuscarEnLista);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.chbResueltos);
            this.Controls.Add(this.chbPendientes);
            this.Controls.Add(this.cmbPrioridadLista);
            this.Controls.Add(this.cmbTipoRequerimientoLista);
            this.Controls.Add(this.lblResueltos);
            this.Controls.Add(this.lblPendientes);
            this.Controls.Add(this.lblPrioridadLista);
            this.Controls.Add(this.lblTipoRequerimientoLista);
            this.Controls.Add(this.label1);
            this.Name = "ListaRequerimientosAdmin";
            this.Text = "ListaRequerimientosAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminarDeLista;
        private System.Windows.Forms.Button btnMarcarResuelto;
        private System.Windows.Forms.Button btnBuscarEnLista;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.CheckBox chbResueltos;
        private System.Windows.Forms.CheckBox chbPendientes;
        private System.Windows.Forms.ComboBox cmbPrioridadLista;
        private System.Windows.Forms.ComboBox cmbTipoRequerimientoLista;
        private System.Windows.Forms.Label lblResueltos;
        private System.Windows.Forms.Label lblPendientes;
        private System.Windows.Forms.Label lblPrioridadLista;
        private System.Windows.Forms.Label lblTipoRequerimientoLista;
        private System.Windows.Forms.Label label1;
    }
}