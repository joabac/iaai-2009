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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_niveles = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.combo_profesorados = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.busca_apellido = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.radioButtonPorApellido = new System.Windows.Forms.RadioButton();
            this.radioButtonPorDni = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(232, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(497, 352);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.combo_niveles);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.combo_profesorados);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(489, 326);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Profesorados";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nivel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Profesorado";
            // 
            // combo_niveles
            // 
            this.combo_niveles.FormattingEnabled = true;
            this.combo_niveles.Location = new System.Drawing.Point(173, 26);
            this.combo_niveles.Name = "combo_niveles";
            this.combo_niveles.Size = new System.Drawing.Size(121, 21);
            this.combo_niveles.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(477, 263);
            this.dataGridView1.TabIndex = 1;
            // 
            // combo_profesorados
            // 
            this.combo_profesorados.FormattingEnabled = true;
            this.combo_profesorados.Location = new System.Drawing.Point(6, 26);
            this.combo_profesorados.Name = "combo_profesorados";
            this.combo_profesorados.Size = new System.Drawing.Size(161, 21);
            this.combo_profesorados.TabIndex = 0;
            this.combo_profesorados.SelectedIndexChanged += new System.EventHandler(this.lista_profesorados_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(489, 326);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cursos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(489, 326);
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "mañana",
            "tarde",
            "noche"});
            this.comboBox1.Location = new System.Drawing.Point(300, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(119, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.cargar);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Turno";
            // 
            // Inscripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 376);
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.ComboBox combo_profesorados;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_niveles;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}