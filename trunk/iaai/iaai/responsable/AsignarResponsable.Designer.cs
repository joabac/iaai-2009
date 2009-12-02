namespace iaai.responsable
{
    partial class AsignarResponsable
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dniBusqueda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.apellidoBusqueda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nombreBusqueda = new System.Windows.Forms.TextBox();
            this.tablaResultado = new System.Windows.Forms.DataGridView();
            this.aceptar = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.nuevo = new System.Windows.Forms.Button();
            this.id_responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asignar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaResultado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buscar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dniBusqueda);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.apellidoBusqueda);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nombreBusqueda);
            this.groupBox1.Location = new System.Drawing.Point(87, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar responsable";
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(393, 71);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(75, 23);
            this.buscar.TabIndex = 6;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dni";
            // 
            // dniBusqueda
            // 
            this.dniBusqueda.Location = new System.Drawing.Point(368, 29);
            this.dniBusqueda.Name = "dniBusqueda";
            this.dniBusqueda.Size = new System.Drawing.Size(100, 20);
            this.dniBusqueda.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Apellido";
            // 
            // apellidoBusqueda
            // 
            this.apellidoBusqueda.Location = new System.Drawing.Point(225, 29);
            this.apellidoBusqueda.Name = "apellidoBusqueda";
            this.apellidoBusqueda.Size = new System.Drawing.Size(100, 20);
            this.apellidoBusqueda.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // nombreBusqueda
            // 
            this.nombreBusqueda.Location = new System.Drawing.Point(64, 29);
            this.nombreBusqueda.Name = "nombreBusqueda";
            this.nombreBusqueda.Size = new System.Drawing.Size(100, 20);
            this.nombreBusqueda.TabIndex = 0;
            // 
            // tablaResultado
            // 
            this.tablaResultado.AllowUserToAddRows = false;
            this.tablaResultado.AllowUserToDeleteRows = false;
            this.tablaResultado.AllowUserToResizeColumns = false;
            this.tablaResultado.AllowUserToResizeRows = false;
            this.tablaResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_responsable,
            this.nombre,
            this.apellido,
            this.dni,
            this.telefono,
            this.direccion,
            this.asignar});
            this.tablaResultado.Location = new System.Drawing.Point(12, 134);
            this.tablaResultado.Name = "tablaResultado";
            this.tablaResultado.Size = new System.Drawing.Size(633, 148);
            this.tablaResultado.TabIndex = 1;
            this.tablaResultado.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid1_CellValueChanged);
            this.tablaResultado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaResultado_CellClick);
            this.tablaResultado.CurrentCellDirtyStateChanged += new System.EventHandler(this.tablaResultado_CurrentCellDirtyStateChanged);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(216, 325);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 2;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(372, 325);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 3;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // nuevo
            // 
            this.nuevo.Location = new System.Drawing.Point(570, 288);
            this.nuevo.Name = "nuevo";
            this.nuevo.Size = new System.Drawing.Size(75, 23);
            this.nuevo.TabIndex = 4;
            this.nuevo.Text = "Nuevo";
            this.nuevo.UseVisualStyleBackColor = true;
            this.nuevo.Click += new System.EventHandler(this.nuevo_Click);
            // 
            // id_responsable
            // 
            this.id_responsable.Frozen = true;
            this.id_responsable.HeaderText = "";
            this.id_responsable.Name = "id_responsable";
            this.id_responsable.ReadOnly = true;
            this.id_responsable.Visible = false;
            // 
            // nombre
            // 
            this.nombre.Frozen = true;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // apellido
            // 
            this.apellido.Frozen = true;
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            // 
            // dni
            // 
            this.dni.Frozen = true;
            this.dni.HeaderText = "Dni";
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            // 
            // telefono
            // 
            this.telefono.Frozen = true;
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // direccion
            // 
            this.direccion.Frozen = true;
            this.direccion.HeaderText = "Dirección";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            // 
            // asignar
            // 
            this.asignar.Frozen = true;
            this.asignar.HeaderText = "Responsable";
            this.asignar.Name = "asignar";
            // 
            // AsignarResponsable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 365);
            this.Controls.Add(this.nuevo);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.tablaResultado);
            this.Controls.Add(this.groupBox1);
            this.Name = "AsignarResponsable";
            this.Text = "Asignar Responsable";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaResultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox apellidoBusqueda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombreBusqueda;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dniBusqueda;
        private System.Windows.Forms.DataGridView tablaResultado;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button nuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_responsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn asignar;
    }
}