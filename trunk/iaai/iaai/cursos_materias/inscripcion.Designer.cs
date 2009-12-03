namespace iaai.cursos_materias
{
    partial class Inscripcion
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.busca_apellido = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.radioButtonPorApellido = new System.Windows.Forms.RadioButton();
            this.radioButtonPorDni = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(245, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(484, 323);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(476, 297);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Materias";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(709, 282);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cursos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(709, 282);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cursos Especiales";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Seleccione Alumno";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.busca_apellido);
            this.panel1.Location = new System.Drawing.Point(15, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 40);
            this.panel1.TabIndex = 58;
            // 
            // busca_apellido
            // 
            this.busca_apellido.FormattingEnabled = true;
            this.busca_apellido.Location = new System.Drawing.Point(4, 8);
            this.busca_apellido.Name = "busca_apellido";
            this.busca_apellido.Size = new System.Drawing.Size(181, 21);
            this.busca_apellido.TabIndex = 0;
            this.busca_apellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buscar);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 57;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBoxBuscar
            // 
            this.textBoxBuscar.Location = new System.Drawing.Point(19, 127);
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(100, 20);
            this.textBoxBuscar.TabIndex = 56;
            // 
            // radioButtonPorApellido
            // 
            this.radioButtonPorApellido.AutoSize = true;
            this.radioButtonPorApellido.Location = new System.Drawing.Point(19, 87);
            this.radioButtonPorApellido.Name = "radioButtonPorApellido";
            this.radioButtonPorApellido.Size = new System.Drawing.Size(81, 17);
            this.radioButtonPorApellido.TabIndex = 55;
            this.radioButtonPorApellido.TabStop = true;
            this.radioButtonPorApellido.Text = "Por Apellido";
            this.radioButtonPorApellido.UseVisualStyleBackColor = true;
            this.radioButtonPorApellido.CheckedChanged += new System.EventHandler(this.radioButtonPorApellido_CheckedChanged);
            // 
            // radioButtonPorDni
            // 
            this.radioButtonPorDni.AutoSize = true;
            this.radioButtonPorDni.Location = new System.Drawing.Point(19, 55);
            this.radioButtonPorDni.Name = "radioButtonPorDni";
            this.radioButtonPorDni.Size = new System.Drawing.Size(62, 17);
            this.radioButtonPorDni.TabIndex = 54;
            this.radioButtonPorDni.TabStop = true;
            this.radioButtonPorDni.Text = "por DNI";
            this.radioButtonPorDni.UseVisualStyleBackColor = true;
            this.radioButtonPorDni.CheckedChanged += new System.EventHandler(this.radioButtonPorDni_CheckedChanged);
            // 
            // Inscripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 347);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxBuscar);
            this.Controls.Add(this.radioButtonPorApellido);
            this.Controls.Add(this.radioButtonPorDni);
            this.Controls.Add(this.tabControl1);
            this.Name = "Inscripcion";
            this.Text = "Inscripcion";
            this.Load += new System.EventHandler(this.Inscripcion_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buscar);
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox busca_apellido;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxBuscar;
        private System.Windows.Forms.RadioButton radioButtonPorApellido;
        private System.Windows.Forms.RadioButton radioButtonPorDni;
    }
}