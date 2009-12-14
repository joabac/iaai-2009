namespace iaai.alumno
{
    partial class ListadoSeguro
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
            this.lista = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_nac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imprimir = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.previa = new System.Windows.Forms.Button();
            this.MyPrintDocument = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.lista)).BeginInit();
            this.SuspendLayout();
            // 
            // lista
            // 
            this.lista.AllowUserToAddRows = false;
            this.lista.AllowUserToDeleteRows = false;
            this.lista.AllowUserToResizeColumns = false;
            this.lista.AllowUserToResizeRows = false;
            this.lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.apellido,
            this.dni,
            this.fecha_nac,
            this.telefono,
            this.direccion});
            this.lista.Location = new System.Drawing.Point(37, 38);
            this.lista.MultiSelect = false;
            this.lista.Name = "lista";
            this.lista.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lista.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lista.Size = new System.Drawing.Size(643, 416);
            this.lista.TabIndex = 0;
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
            // fecha_nac
            // 
            this.fecha_nac.Frozen = true;
            this.fecha_nac.HeaderText = "Fecha Nacimiento";
            this.fecha_nac.Name = "fecha_nac";
            this.fecha_nac.ReadOnly = true;
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
            this.direccion.HeaderText = "Direccion";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            // 
            // imprimir
            // 
            this.imprimir.Location = new System.Drawing.Point(321, 483);
            this.imprimir.Name = "imprimir";
            this.imprimir.Size = new System.Drawing.Size(75, 23);
            this.imprimir.TabIndex = 1;
            this.imprimir.Text = "Imprimir";
            this.imprimir.UseVisualStyleBackColor = true;
            this.imprimir.Click += new System.EventHandler(this.imprimir_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(475, 483);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 2;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // previa
            // 
            this.previa.Location = new System.Drawing.Point(167, 483);
            this.previa.Name = "previa";
            this.previa.Size = new System.Drawing.Size(75, 23);
            this.previa.TabIndex = 3;
            this.previa.Text = "Vista Previa";
            this.previa.UseVisualStyleBackColor = true;
            this.previa.Click += new System.EventHandler(this.previa_Click);
            // 
            // MyPrintDocument
            // 
            this.MyPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.MyPrintDocument_PrintPage);
            // 
            // ListadoSeguro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 525);
            this.Controls.Add(this.previa);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.imprimir);
            this.Controls.Add(this.lista);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ListadoSeguro";
            this.Text = "Listado para Seguro";
            ((System.ComponentModel.ISupportInitialize)(this.lista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView lista;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_nac;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.Button imprimir;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button previa;
        private System.Drawing.Printing.PrintDocument MyPrintDocument;
    }
}