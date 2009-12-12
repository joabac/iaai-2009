namespace iaai.cursos_materias
{
    /// <summary>
    /// Clase para cambio de turnos
    /// </summary>
    partial class Cambiar_Turno
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
            this.labelTurno = new System.Windows.Forms.Label();
            this.comboBox_turnos = new System.Windows.Forms.ComboBox();
            this.acept = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTurno
            // 
            this.labelTurno.AutoSize = true;
            this.labelTurno.Location = new System.Drawing.Point(12, 29);
            this.labelTurno.Name = "labelTurno";
            this.labelTurno.Size = new System.Drawing.Size(98, 13);
            this.labelTurno.TabIndex = 1;
            this.labelTurno.Text = "Turnos disponibles:";
            // 
            // comboBox_turnos
            // 
            this.comboBox_turnos.FormattingEnabled = true;
            this.comboBox_turnos.Location = new System.Drawing.Point(104, 26);
            this.comboBox_turnos.Name = "comboBox_turnos";
            this.comboBox_turnos.Size = new System.Drawing.Size(157, 21);
            this.comboBox_turnos.TabIndex = 2;
            // 
            // acept
            // 
            this.acept.Location = new System.Drawing.Point(116, 108);
            this.acept.Name = "acept";
            this.acept.Size = new System.Drawing.Size(75, 23);
            this.acept.TabIndex = 3;
            this.acept.Text = "Aceptar";
            this.acept.UseVisualStyleBackColor = true;
            this.acept.Click += new System.EventHandler(this.acept_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(197, 108);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "Cancelar";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // Cambiar_Turno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 143);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.acept);
            this.Controls.Add(this.comboBox_turnos);
            this.Controls.Add(this.labelTurno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Cambiar_Turno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Turno";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cambiar_Turno_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTurno;
        private System.Windows.Forms.ComboBox comboBox_turnos;
        private System.Windows.Forms.Button acept;
        private System.Windows.Forms.Button cancel;
    }
}