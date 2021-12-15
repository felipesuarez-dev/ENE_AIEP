namespace ENEAIEP
{
    partial class ListaRequerimientosEmpleado
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
            this.dgvListaE = new System.Windows.Forms.DataGridView();
            this.chbResueltos = new System.Windows.Forms.CheckBox();
            this.chbPendientes = new System.Windows.Forms.CheckBox();
            this.cmbPrioridadListaE = new System.Windows.Forms.ComboBox();
            this.cmbTipoRequerimientoListaE = new System.Windows.Forms.ComboBox();
            this.lblResueltos = new System.Windows.Forms.Label();
            this.lblPendientes = new System.Windows.Forms.Label();
            this.lblPrioridadLista = new System.Windows.Forms.Label();
            this.lblTipoRequerimientoLista = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuAct = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaE)).BeginInit();
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
            this.btnEliminarDeLista.TabIndex = 64;
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
            this.btnMarcarResuelto.TabIndex = 63;
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
            this.btnBuscarEnLista.TabIndex = 62;
            this.btnBuscarEnLista.Text = "Buscar";
            this.btnBuscarEnLista.UseVisualStyleBackColor = true;
            this.btnBuscarEnLista.Click += new System.EventHandler(this.btnBuscarEnLista_Click);
            // 
            // dgvListaE
            // 
            this.dgvListaE.AllowUserToAddRows = false;
            this.dgvListaE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaE.Location = new System.Drawing.Point(33, 247);
            this.dgvListaE.Name = "dgvListaE";
            this.dgvListaE.ReadOnly = true;
            this.dgvListaE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaE.Size = new System.Drawing.Size(649, 116);
            this.dgvListaE.TabIndex = 61;
            // 
            // chbResueltos
            // 
            this.chbResueltos.AutoSize = true;
            this.chbResueltos.Location = new System.Drawing.Point(386, 185);
            this.chbResueltos.Name = "chbResueltos";
            this.chbResueltos.Size = new System.Drawing.Size(15, 14);
            this.chbResueltos.TabIndex = 60;
            this.chbResueltos.UseVisualStyleBackColor = true;
            // 
            // chbPendientes
            // 
            this.chbPendientes.AutoSize = true;
            this.chbPendientes.Location = new System.Drawing.Point(151, 185);
            this.chbPendientes.Name = "chbPendientes";
            this.chbPendientes.Size = new System.Drawing.Size(15, 14);
            this.chbPendientes.TabIndex = 59;
            this.chbPendientes.UseVisualStyleBackColor = true;
            // 
            // cmbPrioridadListaE
            // 
            this.cmbPrioridadListaE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrioridadListaE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPrioridadListaE.FormattingEnabled = true;
            this.cmbPrioridadListaE.Items.AddRange(new object[] {
            "Alta",
            "Media",
            "Baja",
            "Todos"});
            this.cmbPrioridadListaE.Location = new System.Drawing.Point(185, 136);
            this.cmbPrioridadListaE.Name = "cmbPrioridadListaE";
            this.cmbPrioridadListaE.Size = new System.Drawing.Size(240, 24);
            this.cmbPrioridadListaE.TabIndex = 58;
            // 
            // cmbTipoRequerimientoListaE
            // 
            this.cmbTipoRequerimientoListaE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRequerimientoListaE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoRequerimientoListaE.FormattingEnabled = true;
            this.cmbTipoRequerimientoListaE.Items.AddRange(new object[] {
            "Base de Datos",
            "Sistemas",
            "Servidores",
            "Todos"});
            this.cmbTipoRequerimientoListaE.Location = new System.Drawing.Point(185, 92);
            this.cmbTipoRequerimientoListaE.Name = "cmbTipoRequerimientoListaE";
            this.cmbTipoRequerimientoListaE.Size = new System.Drawing.Size(240, 24);
            this.cmbTipoRequerimientoListaE.TabIndex = 57;
            this.cmbTipoRequerimientoListaE.SelectedIndexChanged += new System.EventHandler(this.cmbTipoRequerimientoListaE_SelectedIndexChanged);
            // 
            // lblResueltos
            // 
            this.lblResueltos.AutoSize = true;
            this.lblResueltos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResueltos.Location = new System.Drawing.Point(270, 185);
            this.lblResueltos.Name = "lblResueltos";
            this.lblResueltos.Size = new System.Drawing.Size(78, 16);
            this.lblResueltos.TabIndex = 56;
            this.lblResueltos.Text = "Resueltos";
            // 
            // lblPendientes
            // 
            this.lblPendientes.AutoSize = true;
            this.lblPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendientes.Location = new System.Drawing.Point(30, 186);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(86, 16);
            this.lblPendientes.TabIndex = 55;
            this.lblPendientes.Text = "Pendientes";
            // 
            // lblPrioridadLista
            // 
            this.lblPrioridadLista.AutoSize = true;
            this.lblPrioridadLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrioridadLista.Location = new System.Drawing.Point(30, 141);
            this.lblPrioridadLista.Name = "lblPrioridadLista";
            this.lblPrioridadLista.Size = new System.Drawing.Size(76, 16);
            this.lblPrioridadLista.TabIndex = 54;
            this.lblPrioridadLista.Text = "Prioridad:";
            // 
            // lblTipoRequerimientoLista
            // 
            this.lblTipoRequerimientoLista.AutoSize = true;
            this.lblTipoRequerimientoLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoRequerimientoLista.Location = new System.Drawing.Point(30, 97);
            this.lblTipoRequerimientoLista.Name = "lblTipoRequerimientoLista";
            this.lblTipoRequerimientoLista.Size = new System.Drawing.Size(149, 16);
            this.lblTipoRequerimientoLista.TabIndex = 53;
            this.lblTipoRequerimientoLista.Text = "Tipo Requerimiento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 24);
            this.label1.TabIndex = 52;
            this.label1.Text = "Lista de Requerimientos";
            // 
            // txtUsuAct
            // 
            this.txtUsuAct.Location = new System.Drawing.Point(477, 92);
            this.txtUsuAct.Name = "txtUsuAct";
            this.txtUsuAct.Size = new System.Drawing.Size(100, 20);
            this.txtUsuAct.TabIndex = 65;
            this.txtUsuAct.Visible = false;
            // 
            // ListaRequerimientosEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 455);
            this.Controls.Add(this.txtUsuAct);
            this.Controls.Add(this.btnEliminarDeLista);
            this.Controls.Add(this.btnMarcarResuelto);
            this.Controls.Add(this.btnBuscarEnLista);
            this.Controls.Add(this.dgvListaE);
            this.Controls.Add(this.chbResueltos);
            this.Controls.Add(this.chbPendientes);
            this.Controls.Add(this.cmbPrioridadListaE);
            this.Controls.Add(this.cmbTipoRequerimientoListaE);
            this.Controls.Add(this.lblResueltos);
            this.Controls.Add(this.lblPendientes);
            this.Controls.Add(this.lblPrioridadLista);
            this.Controls.Add(this.lblTipoRequerimientoLista);
            this.Controls.Add(this.label1);
            this.Name = "ListaRequerimientosEmpleado";
            this.Text = "ListaRequerimientosEmpleado";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminarDeLista;
        private System.Windows.Forms.Button btnMarcarResuelto;
        private System.Windows.Forms.Button btnBuscarEnLista;
        private System.Windows.Forms.DataGridView dgvListaE;
        private System.Windows.Forms.CheckBox chbResueltos;
        private System.Windows.Forms.CheckBox chbPendientes;
        private System.Windows.Forms.ComboBox cmbPrioridadListaE;
        private System.Windows.Forms.ComboBox cmbTipoRequerimientoListaE;
        private System.Windows.Forms.Label lblResueltos;
        private System.Windows.Forms.Label lblPendientes;
        private System.Windows.Forms.Label lblPrioridadLista;
        private System.Windows.Forms.Label lblTipoRequerimientoLista;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtUsuAct;
    }
}