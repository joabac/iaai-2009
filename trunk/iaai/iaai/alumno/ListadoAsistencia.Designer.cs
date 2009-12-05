﻿using System.Collections.Generic;
namespace iaai.alumno
{
    partial class ListadoAsistencia
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
            this.imprimir = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.previa = new System.Windows.Forms.Button();
            this.MyPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.curso = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.combo_niveles = new System.Windows.Forms.ComboBox();
            this.combo_profesorados = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cursoE = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.seleccionCurso = new System.Windows.Forms.RadioButton();
            this.seleccionCursoE = new System.Windows.Forms.RadioButton();
            this.seleccionMateria = new System.Windows.Forms.RadioButton();
            this.curso_nivel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.generar = new System.Windows.Forms.Button();
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
            this.dni});
            this.lista.Location = new System.Drawing.Point(186, 220);
            this.lista.MultiSelect = false;
            this.lista.Name = "lista";
            this.lista.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.lista.Size = new System.Drawing.Size(344, 477);
            this.lista.TabIndex = 0;
            // 
            // nombre
            // 
            this.nombre.Frozen = true;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // apellido
            // 
            this.apellido.Frozen = true;
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            this.apellido.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dni
            // 
            this.dni.Frozen = true;
            this.dni.HeaderText = "Dni";
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            this.dni.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // imprimir
            // 
            this.imprimir.Location = new System.Drawing.Point(323, 738);
            this.imprimir.Name = "imprimir";
            this.imprimir.Size = new System.Drawing.Size(75, 23);
            this.imprimir.TabIndex = 1;
            this.imprimir.Text = "Imprimir";
            this.imprimir.UseVisualStyleBackColor = true;
            this.imprimir.Click += new System.EventHandler(this.imprimir_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(477, 738);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 2;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // previa
            // 
            this.previa.Location = new System.Drawing.Point(169, 738);
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
            // curso
            // 
            this.curso.Enabled = false;
            this.curso.FormattingEnabled = true;
            this.curso.Location = new System.Drawing.Point(177, 40);
            this.curso.Name = "curso";
            this.curso.Size = new System.Drawing.Size(161, 21);
            this.curso.TabIndex = 4;
            this.curso.SelectionChangeCommitted += new System.EventHandler(this.curso_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Curso";
            // 
            // comboTurno
            // 
            this.comboTurno.Enabled = false;
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Items.AddRange(new object[] {
            "mañana",
            "tarde",
            "noche"});
            this.comboTurno.Location = new System.Drawing.Point(471, 136);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(119, 21);
            this.comboTurno.TabIndex = 8;
            // 
            // combo_niveles
            // 
            this.combo_niveles.Enabled = false;
            this.combo_niveles.FormattingEnabled = true;
            this.combo_niveles.Location = new System.Drawing.Point(344, 136);
            this.combo_niveles.Name = "combo_niveles";
            this.combo_niveles.Size = new System.Drawing.Size(121, 21);
            this.combo_niveles.TabIndex = 7;
            // 
            // combo_profesorados
            // 
            this.combo_profesorados.Enabled = false;
            this.combo_profesorados.FormattingEnabled = true;
            this.combo_profesorados.Location = new System.Drawing.Point(177, 136);
            this.combo_profesorados.Name = "combo_profesorados";
            this.combo_profesorados.Size = new System.Drawing.Size(161, 21);
            this.combo_profesorados.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(468, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Turno";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nivel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Profesorado";
            // 
            // cursoE
            // 
            this.cursoE.Enabled = false;
            this.cursoE.FormattingEnabled = true;
            this.cursoE.Location = new System.Drawing.Point(177, 89);
            this.cursoE.Name = "cursoE";
            this.cursoE.Size = new System.Drawing.Size(161, 21);
            this.cursoE.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Curso Especial";
            // 
            // seleccionCurso
            // 
            this.seleccionCurso.AutoSize = true;
            this.seleccionCurso.Location = new System.Drawing.Point(157, 43);
            this.seleccionCurso.Name = "seleccionCurso";
            this.seleccionCurso.Size = new System.Drawing.Size(14, 13);
            this.seleccionCurso.TabIndex = 14;
            this.seleccionCurso.TabStop = true;
            this.seleccionCurso.UseVisualStyleBackColor = true;
            this.seleccionCurso.CheckedChanged += new System.EventHandler(this.seleccionCurso_CheckedChanged);
            // 
            // seleccionCursoE
            // 
            this.seleccionCursoE.AutoSize = true;
            this.seleccionCursoE.Location = new System.Drawing.Point(157, 92);
            this.seleccionCursoE.Name = "seleccionCursoE";
            this.seleccionCursoE.Size = new System.Drawing.Size(14, 13);
            this.seleccionCursoE.TabIndex = 15;
            this.seleccionCursoE.TabStop = true;
            this.seleccionCursoE.UseVisualStyleBackColor = true;
            this.seleccionCursoE.CheckedChanged += new System.EventHandler(this.seleccionCursoE_CheckedChanged);
            // 
            // seleccionMateria
            // 
            this.seleccionMateria.AutoSize = true;
            this.seleccionMateria.Location = new System.Drawing.Point(157, 139);
            this.seleccionMateria.Name = "seleccionMateria";
            this.seleccionMateria.Size = new System.Drawing.Size(14, 13);
            this.seleccionMateria.TabIndex = 16;
            this.seleccionMateria.TabStop = true;
            this.seleccionMateria.UseVisualStyleBackColor = true;
            this.seleccionMateria.CheckedChanged += new System.EventHandler(this.seleccionMateria_CheckedChanged);
            // 
            // curso_nivel
            // 
            this.curso_nivel.Enabled = false;
            this.curso_nivel.FormattingEnabled = true;
            this.curso_nivel.Location = new System.Drawing.Point(344, 40);
            this.curso_nivel.Name = "curso_nivel";
            this.curso_nivel.Size = new System.Drawing.Size(121, 21);
            this.curso_nivel.TabIndex = 17;
            this.curso_nivel.SelectionChangeCommitted += new System.EventHandler(this.curso_nivel_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(341, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Nivel";
            // 
            // generar
            // 
            this.generar.Location = new System.Drawing.Point(474, 175);
            this.generar.Name = "generar";
            this.generar.Size = new System.Drawing.Size(115, 23);
            this.generar.TabIndex = 19;
            this.generar.Text = "Generar Listado";
            this.generar.UseVisualStyleBackColor = true;
            this.generar.Click += new System.EventHandler(this.generar_Click);
            // 
            // ListadoAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 784);
            this.Controls.Add(this.generar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.curso_nivel);
            this.Controls.Add(this.seleccionMateria);
            this.Controls.Add(this.seleccionCursoE);
            this.Controls.Add(this.seleccionCurso);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cursoE);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboTurno);
            this.Controls.Add(this.combo_niveles);
            this.Controls.Add(this.combo_profesorados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.curso);
            this.Controls.Add(this.previa);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.imprimir);
            this.Controls.Add(this.lista);
            this.Name = "ListadoAsistencia";
            this.Text = "Listado de Asistencia";
            ((System.ComponentModel.ISupportInitialize)(this.lista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.DataGridView lista;
        private System.Windows.Forms.Button imprimir;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button previa;
        private System.Drawing.Printing.PrintDocument MyPrintDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn dni;
        private System.Windows.Forms.ComboBox curso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboTurno;
        private System.Windows.Forms.ComboBox combo_niveles;
        private System.Windows.Forms.ComboBox combo_profesorados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cursoE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton seleccionCurso;
        private System.Windows.Forms.RadioButton seleccionCursoE;
        private System.Windows.Forms.RadioButton seleccionMateria;
        private System.Windows.Forms.ComboBox curso_nivel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button generar;

    }
}