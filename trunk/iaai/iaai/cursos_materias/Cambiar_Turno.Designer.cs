namespace iaai.cursos_materias
{
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
            this.listBoxTurno = new System.Windows.Forms.ListBox();
            this.labelTurno = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxTurno
            // 
            this.listBoxTurno.FormattingEnabled = true;
            this.listBoxTurno.Location = new System.Drawing.Point(116, 29);
            this.listBoxTurno.Name = "listBoxTurno";
            this.listBoxTurno.Size = new System.Drawing.Size(120, 30);
            this.listBoxTurno.TabIndex = 0;
            this.listBoxTurno.SelectedIndexChanged += new System.EventHandler(this.listBoxTurno_SelectedIndexChanged);
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
            // Cambiar_Turno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 101);
            this.Controls.Add(this.labelTurno);
            this.Controls.Add(this.listBoxTurno);
            this.Name = "Cambiar_Turno";
            this.Text = "Cambiar Condición";
            this.Load += new System.EventHandler(this.Cambiar_Turno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTurno;
        private System.Windows.Forms.Label labelTurno;
    }
}