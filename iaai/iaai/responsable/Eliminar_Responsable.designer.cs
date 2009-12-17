namespace iaai.responsable
{
    /// <summary>
    /// Clase de diseño para el Form de eliminacion de responsables
    /// </summary>
    partial class EliminarResponsable
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
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fecha_nacimiento = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.telefono_carac = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.telefono_numero = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.textBoxDni = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(247, 39);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 1;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(398, 207);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 2;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(497, 206);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 3;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(338, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 67;
            this.label9.Text = "Dirección";
            // 
            // direccion
            // 
            this.direccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.direccion.Location = new System.Drawing.Point(396, 135);
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            this.direccion.Size = new System.Drawing.Size(137, 20);
            this.direccion.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(443, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "-";
            // 
            // fecha_nacimiento
            // 
            this.fecha_nacimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fecha_nacimiento.Location = new System.Drawing.Point(146, 168);
            this.fecha_nacimiento.Mask = "00/00/0000";
            this.fecha_nacimiento.Name = "fecha_nacimiento";
            this.fecha_nacimiento.ReadOnly = true;
            this.fecha_nacimiento.Size = new System.Drawing.Size(68, 20);
            this.fecha_nacimiento.TabIndex = 57;
            this.fecha_nacimiento.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 65;
            this.label6.Text = "Apellido";
            // 
            // apellido
            // 
            this.apellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.apellido.Location = new System.Drawing.Point(146, 110);
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            this.apellido.Size = new System.Drawing.Size(137, 20);
            this.apellido.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Fecha de Nacimiento";
            // 
            // telefono_carac
            // 
            this.telefono_carac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.telefono_carac.Location = new System.Drawing.Point(396, 109);
            this.telefono_carac.Name = "telefono_carac";
            this.telefono_carac.ReadOnly = true;
            this.telefono_carac.Size = new System.Drawing.Size(41, 20);
            this.telefono_carac.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Teléfono";
            // 
            // telefono_numero
            // 
            this.telefono_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.telefono_numero.Location = new System.Drawing.Point(459, 109);
            this.telefono_numero.Name = "telefono_numero";
            this.telefono_numero.ReadOnly = true;
            this.telefono_numero.Size = new System.Drawing.Size(74, 20);
            this.telefono_numero.TabIndex = 59;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(96, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "Nombre";
            // 
            // nombre
            // 
            this.nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nombre.Location = new System.Drawing.Point(146, 138);
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Size = new System.Drawing.Size(137, 20);
            this.nombre.TabIndex = 54;
            // 
            // textBoxDni
            // 
            this.textBoxDni.Location = new System.Drawing.Point(127, 41);
            this.textBoxDni.Name = "textBoxDni";
            this.textBoxDni.Size = new System.Drawing.Size(100, 20);
            this.textBoxDni.TabIndex = 68;
            this.textBoxDni.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "e-mail";
            // 
            // email
            // 
            this.email.BackColor = System.Drawing.SystemColors.Control;
            this.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email.Location = new System.Drawing.Point(396, 161);
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Size = new System.Drawing.Size(137, 20);
            this.email.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Documento";
            // 
            // EliminarResponsable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 255);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.email);
            this.Controls.Add(this.textBoxDni);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.direccion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.fecha_nacimiento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.apellido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.telefono_carac);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.telefono_numero);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.buttonBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EliminarResponsable";
            this.Text = "Eliminar Responsable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox fecha_nacimiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox telefono_carac;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox telefono_numero;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.TextBox textBoxDni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label1;
    }
}