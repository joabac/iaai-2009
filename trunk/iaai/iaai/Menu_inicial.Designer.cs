

namespace iaai
{
    partial class Menu_inicial
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.estado = new System.Windows.Forms.StatusStrip();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.alumnosMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.altaAlumnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaAlumnoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarAlumnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarAlumnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarAlumnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaResponsableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarResponsableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarResponsableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarResponsableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inscripcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoSeguroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoAsistenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeCondicionalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profesoresMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMProfesoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaProfesorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarProfesorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarProfesorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaProfesorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeIAAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recuperarAlumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // estado
            // 
            this.estado.Location = new System.Drawing.Point(0, 550);
            this.estado.Name = "estado";
            this.estado.Size = new System.Drawing.Size(799, 22);
            this.estado.TabIndex = 4;
            this.estado.Text = "estado";
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.BackColor = System.Drawing.Color.Khaki;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alumnosMenu,
            this.profesoresMenu,
            this.ayudaToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(799, 24);
            this.menu.TabIndex = 1;
            this.menu.Tag = "Funciones del Sistema";
            this.menu.Text = "menu";
            // 
            // alumnosMenu
            // 
            this.alumnosMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaAlumnoToolStripMenuItem,
            this.altaResponsableToolStripMenuItem,
            this.inscripcionesToolStripMenuItem,
            this.listadoSeguroToolStripMenuItem,
            this.listadoAsistenciaToolStripMenuItem,
            this.listadoDeCondicionalesToolStripMenuItem,
            this.recuperarAlumnosToolStripMenuItem});
            this.alumnosMenu.Name = "alumnosMenu";
            this.alumnosMenu.Size = new System.Drawing.Size(67, 20);
            this.alumnosMenu.Text = "Alumnos";
            // 
            // altaAlumnoToolStripMenuItem
            // 
            this.altaAlumnoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaAlumnoToolStripMenuItem1,
            this.modificarAlumnoToolStripMenuItem,
            this.eliminarAlumnoToolStripMenuItem,
            this.consultarAlumnoToolStripMenuItem});
            this.altaAlumnoToolStripMenuItem.Name = "altaAlumnoToolStripMenuItem";
            this.altaAlumnoToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.altaAlumnoToolStripMenuItem.Text = "Gestión alumnos";
            // 
            // altaAlumnoToolStripMenuItem1
            // 
            this.altaAlumnoToolStripMenuItem1.Name = "altaAlumnoToolStripMenuItem1";
            this.altaAlumnoToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.altaAlumnoToolStripMenuItem1.Text = "Alta Alumno";
            this.altaAlumnoToolStripMenuItem1.Click += new System.EventHandler(this.altaAlumnoToolStripMenuItem1_Click);
            // 
            // modificarAlumnoToolStripMenuItem
            // 
            this.modificarAlumnoToolStripMenuItem.Name = "modificarAlumnoToolStripMenuItem";
            this.modificarAlumnoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.modificarAlumnoToolStripMenuItem.Text = "Modificar Alumno";
            this.modificarAlumnoToolStripMenuItem.Click += new System.EventHandler(this.modificarAlumnoToolStripMenuItem_Click);
            // 
            // eliminarAlumnoToolStripMenuItem
            // 
            this.eliminarAlumnoToolStripMenuItem.Name = "eliminarAlumnoToolStripMenuItem";
            this.eliminarAlumnoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.eliminarAlumnoToolStripMenuItem.Text = "Eliminar Alumno";
            this.eliminarAlumnoToolStripMenuItem.Click += new System.EventHandler(this.eliminarAlumnoToolStripMenuItem_Click);
            // 
            // consultarAlumnoToolStripMenuItem
            // 
            this.consultarAlumnoToolStripMenuItem.Name = "consultarAlumnoToolStripMenuItem";
            this.consultarAlumnoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.consultarAlumnoToolStripMenuItem.Text = "Consultar Alumno";
            this.consultarAlumnoToolStripMenuItem.Click += new System.EventHandler(this.consultarAlumnoToolStripMenuItem_Click);
            // 
            // altaResponsableToolStripMenuItem
            // 
            this.altaResponsableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarResponsableToolStripMenuItem,
            this.eliminarResponsableToolStripMenuItem,
            this.consultarResponsableToolStripMenuItem});
            this.altaResponsableToolStripMenuItem.Name = "altaResponsableToolStripMenuItem";
            this.altaResponsableToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.altaResponsableToolStripMenuItem.Text = "Gestión responsables";
            // 
            // modificarResponsableToolStripMenuItem
            // 
            this.modificarResponsableToolStripMenuItem.Name = "modificarResponsableToolStripMenuItem";
            this.modificarResponsableToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.modificarResponsableToolStripMenuItem.Text = "Modificar Responsable";
            this.modificarResponsableToolStripMenuItem.Click += new System.EventHandler(this.modificarResponsableToolStripMenuItem_Click);
            // 
            // eliminarResponsableToolStripMenuItem
            // 
            this.eliminarResponsableToolStripMenuItem.Name = "eliminarResponsableToolStripMenuItem";
            this.eliminarResponsableToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.eliminarResponsableToolStripMenuItem.Text = "Eliminar Responsable";
            this.eliminarResponsableToolStripMenuItem.Click += new System.EventHandler(this.eliminarResponsableToolStripMenuItem_Click);
            // 
            // consultarResponsableToolStripMenuItem
            // 
            this.consultarResponsableToolStripMenuItem.Name = "consultarResponsableToolStripMenuItem";
            this.consultarResponsableToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.consultarResponsableToolStripMenuItem.Text = "Consultar Responsable";
            this.consultarResponsableToolStripMenuItem.Click += new System.EventHandler(this.consultarResponsableToolStripMenuItem_Click);
            // 
            // inscripcionesToolStripMenuItem
            // 
            this.inscripcionesToolStripMenuItem.Name = "inscripcionesToolStripMenuItem";
            this.inscripcionesToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.inscripcionesToolStripMenuItem.Text = "Inscripciones";
            this.inscripcionesToolStripMenuItem.Click += new System.EventHandler(this.inscripcionesToolStripMenuItem_Click);
            // 
            // listadoSeguroToolStripMenuItem
            // 
            this.listadoSeguroToolStripMenuItem.Name = "listadoSeguroToolStripMenuItem";
            this.listadoSeguroToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.listadoSeguroToolStripMenuItem.Text = "Listado para seguro";
            this.listadoSeguroToolStripMenuItem.Click += new System.EventHandler(this.listadoSeguroToolStripMenuItem_Click);
            // 
            // listadoAsistenciaToolStripMenuItem
            // 
            this.listadoAsistenciaToolStripMenuItem.Name = "listadoAsistenciaToolStripMenuItem";
            this.listadoAsistenciaToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.listadoAsistenciaToolStripMenuItem.Text = "Listados para asistencia";
            this.listadoAsistenciaToolStripMenuItem.Click += new System.EventHandler(this.listadoAsistenciaToolStripMenuItem_Click);
            // 
            // listadoDeCondicionalesToolStripMenuItem
            // 
            this.listadoDeCondicionalesToolStripMenuItem.Name = "listadoDeCondicionalesToolStripMenuItem";
            this.listadoDeCondicionalesToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.listadoDeCondicionalesToolStripMenuItem.Text = "Listado de Condicionales";
            this.listadoDeCondicionalesToolStripMenuItem.Click += new System.EventHandler(this.listadoDeCondicionalesToolStripMenuItem_Click);
            // 
            // profesoresMenu
            // 
            this.profesoresMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMProfesoresToolStripMenuItem});
            this.profesoresMenu.Name = "profesoresMenu";
            this.profesoresMenu.Size = new System.Drawing.Size(74, 20);
            this.profesoresMenu.Text = "Profesores";
            // 
            // aBMProfesoresToolStripMenuItem
            // 
            this.aBMProfesoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaProfesorToolStripMenuItem,
            this.modificarProfesorToolStripMenuItem,
            this.eliminarProfesorToolStripMenuItem,
            this.consultaProfesorToolStripMenuItem});
            this.aBMProfesoresToolStripMenuItem.Name = "aBMProfesoresToolStripMenuItem";
            this.aBMProfesoresToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.aBMProfesoresToolStripMenuItem.Text = "Gestión profesores";
            // 
            // altaProfesorToolStripMenuItem
            // 
            this.altaProfesorToolStripMenuItem.Name = "altaProfesorToolStripMenuItem";
            this.altaProfesorToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.altaProfesorToolStripMenuItem.Text = "Alta Profesor";
            this.altaProfesorToolStripMenuItem.Click += new System.EventHandler(this.altaProfesorToolStripMenuItem_Click);
            // 
            // modificarProfesorToolStripMenuItem
            // 
            this.modificarProfesorToolStripMenuItem.Name = "modificarProfesorToolStripMenuItem";
            this.modificarProfesorToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.modificarProfesorToolStripMenuItem.Text = "Modificar Profesor";
            this.modificarProfesorToolStripMenuItem.Click += new System.EventHandler(this.ModificarProfesorToolStripMenuItem_Click);
            // 
            // eliminarProfesorToolStripMenuItem
            // 
            this.eliminarProfesorToolStripMenuItem.Name = "eliminarProfesorToolStripMenuItem";
            this.eliminarProfesorToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.eliminarProfesorToolStripMenuItem.Text = "Eliminar Profesor";
            this.eliminarProfesorToolStripMenuItem.Click += new System.EventHandler(this.eliminarProfesorToolStripMenuItem_Click);
            // 
            // consultaProfesorToolStripMenuItem
            // 
            this.consultaProfesorToolStripMenuItem.Name = "consultaProfesorToolStripMenuItem";
            this.consultaProfesorToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.consultaProfesorToolStripMenuItem.Text = "Consulta Profesor";
            this.consultaProfesorToolStripMenuItem.Click += new System.EventHandler(this.consultaProfesorToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ayudaToolStripMenuItem1,
            this.acercaDeIAAIToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // ayudaToolStripMenuItem1
            // 
            this.ayudaToolStripMenuItem1.Name = "ayudaToolStripMenuItem1";
            this.ayudaToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.ayudaToolStripMenuItem1.Text = "Referencia de Codigo";
            this.ayudaToolStripMenuItem1.Click += new System.EventHandler(this.ayudaToolStripMenuItem1_Click);
            // 
            // acercaDeIAAIToolStripMenuItem
            // 
            this.acercaDeIAAIToolStripMenuItem.Name = "acercaDeIAAIToolStripMenuItem";
            this.acercaDeIAAIToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.acercaDeIAAIToolStripMenuItem.Text = "Acerca de IAAI";
            this.acercaDeIAAIToolStripMenuItem.Click += new System.EventHandler(this.acercaDeIAAIToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // recuperarAlumnosToolStripMenuItem
            // 
            this.recuperarAlumnosToolStripMenuItem.Name = "recuperarAlumnosToolStripMenuItem";
            this.recuperarAlumnosToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.recuperarAlumnosToolStripMenuItem.Text = "Recuperar Alumnos";
            this.recuperarAlumnosToolStripMenuItem.Click += new System.EventHandler(this.recuperarAlumnosToolStripMenuItem_Click);
            // 
            // Menu_inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::iaai.Properties.Resources.Aethlet_Reprise_by_archanN;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(799, 572);
            this.Controls.Add(this.estado);
            this.Controls.Add(this.menu);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menu;
            this.Name = "Menu_inicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IAAI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_inicial_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip estado;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem alumnosMenu;
        private System.Windows.Forms.ToolStripMenuItem profesoresMenu;
        private System.Windows.Forms.ToolStripMenuItem altaAlumnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaResponsableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inscripcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMProfesoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem acercaDeIAAIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaAlumnoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modificarProfesorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaProfesorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarProfesorToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem listadoSeguroToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem consultaProfesorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarAlumnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarAlumnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarResponsableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarResponsableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoAsistenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarAlumnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarResponsableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeCondicionalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recuperarAlumnosToolStripMenuItem;




    }
}

