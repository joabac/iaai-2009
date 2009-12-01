namespace iaai.profesor
{
    partial class Altaprofesor
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
            this.email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.aceptar = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(396, 66);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(100, 20);
            this.email.TabIndex = 7;
            this.email.TextChanged += new System.EventHandler(this.email_TextChanged);
            this.email.Leave += new System.EventHandler(this.validar_mail);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "e-mail";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(338, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Dirección";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(396, 38);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(137, 20);
            this.direccion.TabIndex = 6;
            this.direccion.TextChanged += new System.EventHandler(this.direccion_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(443, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "-";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // fecha_nacimiento
            // 
            this.fecha_nacimiento.Location = new System.Drawing.Point(137, 89);
            this.fecha_nacimiento.Mask = "00/00/0000";
            this.fecha_nacimiento.Name = "fecha_nacimiento";
            this.fecha_nacimiento.Size = new System.Drawing.Size(68, 20);
            this.fecha_nacimiento.TabIndex = 3;
            this.fecha_nacimiento.ValidatingType = typeof(System.DateTime);
            this.fecha_nacimiento.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.fecha_nacimiento_MaskInputRejected);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Apellido";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // apellido
            // 
            this.apellido.Location = new System.Drawing.Point(137, 38);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(137, 20);
            this.apellido.TabIndex = 1;
            this.apellido.TextChanged += new System.EventHandler(this.apellido_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "DNI";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // dni
            // 
            this.dni.Location = new System.Drawing.Point(137, 63);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(137, 20);
            this.dni.TabIndex = 2;
            this.dni.TextChanged += new System.EventHandler(this.dni_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Fecha de Nacimiento";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // telefono_carac
            // 
            this.telefono_carac.Location = new System.Drawing.Point(396, 12);
            this.telefono_carac.Name = "telefono_carac";
            this.telefono_carac.Size = new System.Drawing.Size(41, 20);
            this.telefono_carac.TabIndex = 4;
            this.telefono_carac.TextChanged += new System.EventHandler(this.telefono_carac_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Teléfono";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // telefono_numero
            // 
            this.telefono_numero.Location = new System.Drawing.Point(459, 12);
            this.telefono_numero.Name = "telefono_numero";
            this.telefono_numero.Size = new System.Drawing.Size(74, 20);
            this.telefono_numero.TabIndex = 5;
            this.telefono_numero.TextChanged += new System.EventHandler(this.telefono_numero_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(87, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Nombre";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(137, 12);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(137, 20);
            this.nombre.TabIndex = 0;
            this.nombre.TextChanged += new System.EventHandler(this.nombre_TextChanged);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(146, 158);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 8;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(362, 158);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Cancelar";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Altaprofesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 204);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.aceptar);
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.email);
            this.Name = "Altaprofesor";
            this.Text = "Alta Profesor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Button Cancel;
    }
}