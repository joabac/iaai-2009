namespace iaai.responsable
{
    partial class Consulta_Responsable
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
            this.radioButtonPorDni = new System.Windows.Forms.RadioButton();
            this.radioButtonPorApellido = new System.Windows.Forms.RadioButton();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fecha_nacimiento = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dni = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.telefono_carac = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.telefono_numero = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.busca_apellido = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonPorDni
            // 
            this.radioButtonPorDni.AutoSize = true;
            this.radioButtonPorDni.Location = new System.Drawing.Point(66, 40);
            this.radioButtonPorDni.Name = "radioButtonPorDni";
            this.radioButtonPorDni.Size = new System.Drawing.Size(62, 17);
            this.radioButtonPorDni.TabIndex = 0;
            this.radioButtonPorDni.TabStop = true;
            this.radioButtonPorDni.Text = "por DNI";
            this.radioButtonPorDni.UseVisualStyleBackColor = true;
            this.radioButtonPorDni.CheckedChanged += new System.EventHandler(this.radioButtonPorDni_CheckedChanged);
            // 
            // radioButtonPorApellido
            // 
            this.radioButtonPorApellido.AutoSize = true;
            this.radioButtonPorApellido.Location = new System.Drawing.Point(66, 72);
            this.radioButtonPorApellido.Name = "radioButtonPorApellido";
            this.radioButtonPorApellido.Size = new System.Drawing.Size(81, 17);
            this.radioButtonPorApellido.TabIndex = 1;
            this.radioButtonPorApellido.TabStop = true;
            this.radioButtonPorApellido.Text = "Por Apellido";
            this.radioButtonPorApellido.UseVisualStyleBackColor = true;
            this.radioButtonPorApellido.CheckedChanged += new System.EventHandler(this.radioButtonPorApellido_CheckedChanged);
            // 
            // textBoxBuscar
            // 
            this.textBoxBuscar.Location = new System.Drawing.Point(66, 112);
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(100, 20);
            this.textBoxBuscar.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(347, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "Dirección";
            // 
            // direccion
            // 
            this.direccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.direccion.Location = new System.Drawing.Point(405, 166);
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            this.direccion.Size = new System.Drawing.Size(181, 20);
            this.direccion.TabIndex = 43;
            this.direccion.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(473, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "-";
            // 
            // fecha_nacimiento
            // 
            this.fecha_nacimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fecha_nacimiento.Location = new System.Drawing.Point(405, 114);
            this.fecha_nacimiento.Mask = "00/00/0000";
            this.fecha_nacimiento.Name = "fecha_nacimiento";
            this.fecha_nacimiento.ReadOnly = true;
            this.fecha_nacimiento.Size = new System.Drawing.Size(65, 20);
            this.fecha_nacimiento.TabIndex = 40;
            this.fecha_nacimiento.TabStop = false;
            this.fecha_nacimiento.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(355, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Apellido";
            // 
            // apellido
            // 
            this.apellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.apellido.Location = new System.Drawing.Point(405, 36);
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            this.apellido.Size = new System.Drawing.Size(181, 20);
            this.apellido.TabIndex = 37;
            this.apellido.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(373, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "DNI";
            // 
            // dni
            // 
            this.dni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dni.Location = new System.Drawing.Point(405, 88);
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            this.dni.Size = new System.Drawing.Size(181, 20);
            this.dni.TabIndex = 38;
            this.dni.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(291, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Fecha de Nacimiento";
            // 
            // telefono_carac
            // 
            this.telefono_carac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.telefono_carac.Location = new System.Drawing.Point(405, 140);
            this.telefono_carac.Name = "telefono_carac";
            this.telefono_carac.ReadOnly = true;
            this.telefono_carac.Size = new System.Drawing.Size(67, 20);
            this.telefono_carac.TabIndex = 41;
            this.telefono_carac.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Teléfono";
            // 
            // telefono_numero
            // 
            this.telefono_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.telefono_numero.Location = new System.Drawing.Point(486, 140);
            this.telefono_numero.Name = "telefono_numero";
            this.telefono_numero.ReadOnly = true;
            this.telefono_numero.Size = new System.Drawing.Size(100, 20);
            this.telefono_numero.TabIndex = 42;
            this.telefono_numero.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(355, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Nombre";
            // 
            // nombre
            // 
            this.nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nombre.Location = new System.Drawing.Point(405, 62);
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Size = new System.Drawing.Size(181, 20);
            this.nombre.TabIndex = 36;
            this.nombre.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.busca_apellido);
            this.panel1.Location = new System.Drawing.Point(62, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 40);
            this.panel1.TabIndex = 4;
            // 
            // busca_apellido
            // 
            this.busca_apellido.FormattingEnabled = true;
            this.busca_apellido.Location = new System.Drawing.Point(4, 8);
            this.busca_apellido.Name = "busca_apellido";
            this.busca_apellido.Size = new System.Drawing.Size(181, 21);
            this.busca_apellido.TabIndex = 0;
            this.busca_apellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buscar);
            this.busca_apellido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cargar);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Seleccione Criterio de Busqueda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "e-mail";
            // 
            // email
            // 
            this.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email.Location = new System.Drawing.Point(405, 192);
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Size = new System.Drawing.Size(181, 20);
            this.email.TabIndex = 55;
            this.email.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(511, 229);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Consulta_Responsable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 264);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.direccion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.fecha_nacimiento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.apellido);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dni);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.telefono_carac);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.telefono_numero);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxBuscar);
            this.Controls.Add(this.radioButtonPorApellido);
            this.Controls.Add(this.radioButtonPorDni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Consulta_Responsable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Responsable";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonPorDni;
        private System.Windows.Forms.RadioButton radioButtonPorApellido;
        private System.Windows.Forms.TextBox textBoxBuscar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox fecha_nacimiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox telefono_carac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox telefono_numero;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox busca_apellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Button button2;
    }
}