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
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_inscribe = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboTurno = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_niveles = new System.Windows.Forms.ComboBox();
            this.dataGrid_Listado = new System.Windows.Forms.DataGridView();
            this.inscribe = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nombreMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profesor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_mat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_turno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.combo_profesorados = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonInscribir = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBoxNivel = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxArea = new System.Windows.Forms.ComboBox();
            this.checkedList_cursos = new System.Windows.Forms.CheckedListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkedList_cursosEsp = new System.Windows.Forms.CheckedListBox();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBoxArea_esp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.busca_apellido = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.radioButtonPorApellido = new System.Windows.Forms.RadioButton();
            this.radioButtonPorDni = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fecha_nacimiento = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dni = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.telefono_carac = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.telefono_numero = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.panel_datos = new System.Windows.Forms.Panel();
            this.alta = new System.Windows.Forms.Button();
            this.reporte_inscripcion = new System.Drawing.Printing.PrintDocument();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Listado)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_datos.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(259, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(579, 378);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.bt_cancel);
            this.tabPage1.Controls.Add(this.bt_inscribe);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.comboTurno);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.combo_niveles);
            this.tabPage1.Controls.Add(this.dataGrid_Listado);
            this.tabPage1.Controls.Add(this.combo_profesorados);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(571, 352);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Profesorados";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(145, 316);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 15);
            this.label15.TabIndex = 11;
            this.label15.Text = "No Inscripto";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Khaki;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(75, 316);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 15);
            this.label14.TabIndex = 10;
            this.label14.Text = "Condicional";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(20, 316);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 15);
            this.label13.TabIndex = 9;
            this.label13.Text = "Inscripto";
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(490, 316);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_cancel.TabIndex = 5;
            this.bt_cancel.Text = "Cancelar";
            this.bt_cancel.UseVisualStyleBackColor = true;
            // 
            // bt_inscribe
            // 
            this.bt_inscribe.Location = new System.Drawing.Point(409, 316);
            this.bt_inscribe.Name = "bt_inscribe";
            this.bt_inscribe.Size = new System.Drawing.Size(75, 23);
            this.bt_inscribe.TabIndex = 4;
            this.bt_inscribe.Text = "Inscribir";
            this.bt_inscribe.UseVisualStyleBackColor = true;
            this.bt_inscribe.Click += new System.EventHandler(this.bt_inscribe_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Turno";
            // 
            // comboTurno
            // 
            this.comboTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTurno.FormattingEnabled = true;
            this.comboTurno.Items.AddRange(new object[] {
            "mañana",
            "tarde",
            "noche"});
            this.comboTurno.Location = new System.Drawing.Point(300, 26);
            this.comboTurno.Name = "comboTurno";
            this.comboTurno.Size = new System.Drawing.Size(119, 21);
            this.comboTurno.TabIndex = 2;
            this.comboTurno.SelectedIndexChanged += new System.EventHandler(this.cargar_materias);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nivel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Profesorado";
            // 
            // combo_niveles
            // 
            this.combo_niveles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_niveles.FormattingEnabled = true;
            this.combo_niveles.Location = new System.Drawing.Point(173, 26);
            this.combo_niveles.Name = "combo_niveles";
            this.combo_niveles.Size = new System.Drawing.Size(121, 21);
            this.combo_niveles.TabIndex = 1;
            this.combo_niveles.SelectedIndexChanged += new System.EventHandler(this.combo_niveles_SelectedIndexChanged);
            // 
            // dataGrid_Listado
            // 
            this.dataGrid_Listado.AllowUserToAddRows = false;
            this.dataGrid_Listado.AllowUserToDeleteRows = false;
            this.dataGrid_Listado.AllowUserToResizeColumns = false;
            this.dataGrid_Listado.AllowUserToResizeRows = false;
            this.dataGrid_Listado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid_Listado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid_Listado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGrid_Listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_Listado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inscribe,
            this.nombreMat,
            this.profesor,
            this.id_mat,
            this.id_turno});
            this.dataGrid_Listado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGrid_Listado.Location = new System.Drawing.Point(6, 53);
            this.dataGrid_Listado.MultiSelect = false;
            this.dataGrid_Listado.Name = "dataGrid_Listado";
            this.dataGrid_Listado.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGrid_Listado.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGrid_Listado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGrid_Listado.Size = new System.Drawing.Size(559, 257);
            this.dataGrid_Listado.TabIndex = 3;
            // 
            // inscribe
            // 
            this.inscribe.FalseValue = "false";
            this.inscribe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.inscribe.HeaderText = "Seleccion";
            this.inscribe.Name = "inscribe";
            this.inscribe.TrueValue = "true";
            // 
            // nombreMat
            // 
            this.nombreMat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreMat.HeaderText = "Nombre Materia";
            this.nombreMat.Name = "nombreMat";
            this.nombreMat.ReadOnly = true;
            // 
            // profesor
            // 
            this.profesor.HeaderText = "Nombre Docente";
            this.profesor.Name = "profesor";
            this.profesor.ReadOnly = true;
            // 
            // id_mat
            // 
            this.id_mat.HeaderText = "ID materia";
            this.id_mat.Name = "id_mat";
            this.id_mat.ReadOnly = true;
            this.id_mat.Visible = false;
            // 
            // id_turno
            // 
            this.id_turno.HeaderText = "ID turno";
            this.id_turno.Name = "id_turno";
            this.id_turno.ReadOnly = true;
            this.id_turno.Visible = false;
            // 
            // combo_profesorados
            // 
            this.combo_profesorados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_profesorados.FormattingEnabled = true;
            this.combo_profesorados.Location = new System.Drawing.Point(6, 26);
            this.combo_profesorados.Name = "combo_profesorados";
            this.combo_profesorados.Size = new System.Drawing.Size(161, 21);
            this.combo_profesorados.TabIndex = 0;
            this.combo_profesorados.SelectedIndexChanged += new System.EventHandler(this.lista_profesorados_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.buttonInscribir);
            this.tabPage2.Controls.Add(this.buttonCancelar);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.comboBoxNivel);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.comboBoxArea);
            this.tabPage2.Controls.Add(this.checkedList_cursos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(571, 352);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cursos";
            // 
            // buttonInscribir
            // 
            this.buttonInscribir.Location = new System.Drawing.Point(400, 310);
            this.buttonInscribir.Name = "buttonInscribir";
            this.buttonInscribir.Size = new System.Drawing.Size(75, 23);
            this.buttonInscribir.TabIndex = 6;
            this.buttonInscribir.Text = "Inscribir";
            this.buttonInscribir.UseVisualStyleBackColor = true;
            this.buttonInscribir.Click += new System.EventHandler(this.buttonInscribir_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(490, 310);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 5;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 78);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Nivel";
            // 
            // comboBoxNivel
            // 
            this.comboBoxNivel.FormattingEnabled = true;
            this.comboBoxNivel.Location = new System.Drawing.Point(24, 91);
            this.comboBoxNivel.Name = "comboBoxNivel";
            this.comboBoxNivel.Size = new System.Drawing.Size(165, 21);
            this.comboBoxNivel.TabIndex = 3;
            this.comboBoxNivel.SelectionChangeCommitted += new System.EventHandler(this.cambia_nivel);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(21, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Area";
            // 
            // comboBoxArea
            // 
            this.comboBoxArea.FormattingEnabled = true;
            this.comboBoxArea.Location = new System.Drawing.Point(24, 40);
            this.comboBoxArea.Name = "comboBoxArea";
            this.comboBoxArea.Size = new System.Drawing.Size(165, 21);
            this.comboBoxArea.TabIndex = 1;
            this.comboBoxArea.SelectionChangeCommitted += new System.EventHandler(this.cambio_area);
            this.comboBoxArea.SelectedIndexChanged += new System.EventHandler(this.comboBoxArea_SelectedIndexChanged);
            // 
            // checkedList_cursos
            // 
            this.checkedList_cursos.FormattingEnabled = true;
            this.checkedList_cursos.Location = new System.Drawing.Point(202, 0);
            this.checkedList_cursos.Name = "checkedList_cursos";
            this.checkedList_cursos.Size = new System.Drawing.Size(373, 304);
            this.checkedList_cursos.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.checkedList_cursosEsp);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.comboBoxArea_esp);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(571, 352);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cursos Especiales";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(400, 310);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Inscribir";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(490, 310);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // checkedList_cursosEsp
            // 
            this.checkedList_cursosEsp.FormattingEnabled = true;
            this.checkedList_cursosEsp.Location = new System.Drawing.Point(202, 0);
            this.checkedList_cursosEsp.Name = "checkedList_cursosEsp";
            this.checkedList_cursosEsp.Size = new System.Drawing.Size(373, 304);
            this.checkedList_cursosEsp.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(21, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "Area";
            // 
            // comboBoxArea_esp
            // 
            this.comboBoxArea_esp.FormattingEnabled = true;
            this.comboBoxArea_esp.Location = new System.Drawing.Point(24, 40);
            this.comboBoxArea_esp.Name = "comboBoxArea_esp";
            this.comboBoxArea_esp.Size = new System.Drawing.Size(165, 21);
            this.comboBoxArea_esp.TabIndex = 0;
            this.comboBoxArea_esp.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Seleccione Alumno";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.busca_apellido);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 33);
            this.panel1.TabIndex = 5;
            // 
            // busca_apellido
            // 
            this.busca_apellido.FormattingEnabled = true;
            this.busca_apellido.Location = new System.Drawing.Point(4, 8);
            this.busca_apellido.Name = "busca_apellido";
            this.busca_apellido.Size = new System.Drawing.Size(203, 21);
            this.busca_apellido.TabIndex = 0;
            this.busca_apellido.Leave += new System.EventHandler(this.cargar_al_salir);
            this.busca_apellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buscar);
            this.busca_apellido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cargar);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxBuscar
            // 
            this.textBoxBuscar.Location = new System.Drawing.Point(16, 64);
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(100, 20);
            this.textBoxBuscar.TabIndex = 3;
            // 
            // radioButtonPorApellido
            // 
            this.radioButtonPorApellido.AutoSize = true;
            this.radioButtonPorApellido.Location = new System.Drawing.Point(119, 29);
            this.radioButtonPorApellido.Name = "radioButtonPorApellido";
            this.radioButtonPorApellido.Size = new System.Drawing.Size(81, 17);
            this.radioButtonPorApellido.TabIndex = 2;
            this.radioButtonPorApellido.TabStop = true;
            this.radioButtonPorApellido.Text = "Por Apellido";
            this.radioButtonPorApellido.UseVisualStyleBackColor = true;
            this.radioButtonPorApellido.CheckedChanged += new System.EventHandler(this.radioButtonPorApellido_CheckedChanged);
            // 
            // radioButtonPorDni
            // 
            this.radioButtonPorDni.AutoSize = true;
            this.radioButtonPorDni.Location = new System.Drawing.Point(12, 29);
            this.radioButtonPorDni.Name = "radioButtonPorDni";
            this.radioButtonPorDni.Size = new System.Drawing.Size(62, 17);
            this.radioButtonPorDni.TabIndex = 1;
            this.radioButtonPorDni.TabStop = true;
            this.radioButtonPorDni.Text = "por DNI";
            this.radioButtonPorDni.UseVisualStyleBackColor = true;
            this.radioButtonPorDni.CheckedChanged += new System.EventHandler(this.radioButtonPorDni_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 75;
            this.label9.Text = "Dirección";
            // 
            // direccion
            // 
            this.direccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.direccion.Location = new System.Drawing.Point(54, 142);
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            this.direccion.Size = new System.Drawing.Size(181, 20);
            this.direccion.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 74;
            this.label7.Text = "-";
            // 
            // fecha_nacimiento
            // 
            this.fecha_nacimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fecha_nacimiento.Location = new System.Drawing.Point(113, 90);
            this.fecha_nacimiento.Mask = "00/00/0000";
            this.fecha_nacimiento.Name = "fecha_nacimiento";
            this.fecha_nacimiento.ReadOnly = true;
            this.fecha_nacimiento.Size = new System.Drawing.Size(122, 20);
            this.fecha_nacimiento.TabIndex = 3;
            this.fecha_nacimiento.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 73;
            this.label6.Text = "Apellido";
            // 
            // apellido
            // 
            this.apellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.apellido.Location = new System.Drawing.Point(54, 39);
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            this.apellido.Size = new System.Drawing.Size(181, 20);
            this.apellido.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 72;
            this.label5.Text = "DNI";
            // 
            // dni
            // 
            this.dni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dni.Location = new System.Drawing.Point(54, 67);
            this.dni.Name = "dni";
            this.dni.ReadOnly = true;
            this.dni.Size = new System.Drawing.Size(181, 20);
            this.dni.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 71;
            this.label8.Text = "Fecha de Nacimiento";
            // 
            // telefono_carac
            // 
            this.telefono_carac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.telefono_carac.Location = new System.Drawing.Point(54, 116);
            this.telefono_carac.Name = "telefono_carac";
            this.telefono_carac.ReadOnly = true;
            this.telefono_carac.Size = new System.Drawing.Size(59, 20);
            this.telefono_carac.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 70;
            this.label10.Text = "Teléfono";
            // 
            // telefono_numero
            // 
            this.telefono_numero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.telefono_numero.Location = new System.Drawing.Point(135, 116);
            this.telefono_numero.Name = "telefono_numero";
            this.telefono_numero.ReadOnly = true;
            this.telefono_numero.Size = new System.Drawing.Size(100, 20);
            this.telefono_numero.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 69;
            this.label11.Text = "Nombre";
            // 
            // nombre
            // 
            this.nombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nombre.Location = new System.Drawing.Point(54, 13);
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Size = new System.Drawing.Size(181, 20);
            this.nombre.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 63;
            this.label12.Text = "e-mail";
            // 
            // email
            // 
            this.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email.Location = new System.Drawing.Point(54, 168);
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Size = new System.Drawing.Size(181, 20);
            this.email.TabIndex = 7;
            // 
            // panel_datos
            // 
            this.panel_datos.Controls.Add(this.label9);
            this.panel_datos.Controls.Add(this.direccion);
            this.panel_datos.Controls.Add(this.label7);
            this.panel_datos.Controls.Add(this.fecha_nacimiento);
            this.panel_datos.Controls.Add(this.label6);
            this.panel_datos.Controls.Add(this.apellido);
            this.panel_datos.Controls.Add(this.label5);
            this.panel_datos.Controls.Add(this.dni);
            this.panel_datos.Controls.Add(this.label8);
            this.panel_datos.Controls.Add(this.telefono_carac);
            this.panel_datos.Controls.Add(this.label10);
            this.panel_datos.Controls.Add(this.telefono_numero);
            this.panel_datos.Controls.Add(this.label11);
            this.panel_datos.Controls.Add(this.nombre);
            this.panel_datos.Controls.Add(this.label12);
            this.panel_datos.Controls.Add(this.email);
            this.panel_datos.Location = new System.Drawing.Point(6, 149);
            this.panel_datos.Name = "panel_datos";
            this.panel_datos.Size = new System.Drawing.Size(251, 205);
            this.panel_datos.TabIndex = 8;
            // 
            // alta
            // 
            this.alta.Location = new System.Drawing.Point(141, 97);
            this.alta.Name = "alta";
            this.alta.Size = new System.Drawing.Size(81, 23);
            this.alta.TabIndex = 6;
            this.alta.Text = "Alta Alumno";
            this.alta.UseVisualStyleBackColor = true;
            this.alta.Click += new System.EventHandler(this.alta_Click);
            // 
            // reporte_inscripcion
            // 
            this.reporte_inscripcion.DocumentName = "reporte";
            this.reporte_inscripcion.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.reporte_inscripcion_PrintPage);
            // 
            // Inscripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 397);
            this.Controls.Add(this.alta);
            this.Controls.Add(this.panel_datos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxBuscar);
            this.Controls.Add(this.radioButtonPorApellido);
            this.Controls.Add(this.radioButtonPorDni);
            this.Controls.Add(this.tabControl1);
            this.Name = "Inscripcion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inscripcion";
            this.Load += new System.EventHandler(this.Inscripcion_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buscar);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_Listado)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel_datos.ResumeLayout(false);
            this.panel_datos.PerformLayout();
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
        private System.Windows.Forms.DataGridView dataGrid_Listado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_niveles;
        private System.Windows.Forms.ComboBox comboTurno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.Button bt_inscribe;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox fecha_nacimiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dni;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox telefono_carac;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox telefono_numero;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Panel panel_datos;
        private System.Windows.Forms.Button alta;
        private System.Drawing.Printing.PrintDocument reporte_inscripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn inscribe;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreMat;
        private System.Windows.Forms.DataGridViewTextBoxColumn profesor;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_mat;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_turno;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckedListBox checkedList_cursos;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBoxNivel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBoxArea;
        private System.Windows.Forms.CheckedListBox checkedList_cursosEsp;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboBoxArea_esp;
        private System.Windows.Forms.Button buttonInscribir;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}