

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
            this.altaResponsableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inscripcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profesoresMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMProfesoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeIAAIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaResponsableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // estado
            // 
            this.estado.Location = new System.Drawing.Point(0, 348);
            this.estado.Name = "estado";
            this.estado.Size = new System.Drawing.Size(651, 22);
            this.estado.TabIndex = 4;
            this.estado.Text = "estado";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alumnosMenu,
            this.profesoresMenu,
            this.ayudaToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(651, 24);
            this.menu.TabIndex = 5;
            this.menu.Tag = "Funciones del Sistema";
            this.menu.Text = "menu";
            // 
            // alumnosMenu
            // 
            this.alumnosMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaAlumnoToolStripMenuItem,
            this.altaResponsableToolStripMenuItem,
            this.inscripcionesToolStripMenuItem});
            this.alumnosMenu.Name = "alumnosMenu";
            this.alumnosMenu.Size = new System.Drawing.Size(67, 20);
            this.alumnosMenu.Text = "Alumnos";
            // 
            // altaAlumnoToolStripMenuItem
            // 
            this.altaAlumnoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaAlumnoToolStripMenuItem1});
            this.altaAlumnoToolStripMenuItem.Name = "altaAlumnoToolStripMenuItem";
            this.altaAlumnoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.altaAlumnoToolStripMenuItem.Text = "ABM Alumno";
            // 
            // altaAlumnoToolStripMenuItem1
            // 
            this.altaAlumnoToolStripMenuItem1.Name = "altaAlumnoToolStripMenuItem1";
            this.altaAlumnoToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.altaAlumnoToolStripMenuItem1.Text = "Alta Alumno";
            this.altaAlumnoToolStripMenuItem1.Click += new System.EventHandler(this.altaAlumnoToolStripMenuItem1_Click);
            // 
            // altaResponsableToolStripMenuItem
            // 
            this.altaResponsableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaResponsableToolStripMenuItem1});
            this.altaResponsableToolStripMenuItem.Name = "altaResponsableToolStripMenuItem";
            this.altaResponsableToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.altaResponsableToolStripMenuItem.Text = "ABM Responsable";
            // 
            // inscripcionesToolStripMenuItem
            // 
            this.inscripcionesToolStripMenuItem.Name = "inscripcionesToolStripMenuItem";
            this.inscripcionesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.inscripcionesToolStripMenuItem.Text = "Inscripciones";
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
            this.aBMProfesoresToolStripMenuItem.Name = "aBMProfesoresToolStripMenuItem";
            this.aBMProfesoresToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.aBMProfesoresToolStripMenuItem.Text = "ABM Profesores";
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
            this.ayudaToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.ayudaToolStripMenuItem1.Text = "Ayuda";
            // 
            // acercaDeIAAIToolStripMenuItem
            // 
            this.acercaDeIAAIToolStripMenuItem.Name = "acercaDeIAAIToolStripMenuItem";
            this.acercaDeIAAIToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.acercaDeIAAIToolStripMenuItem.Text = "Acerca de IAAI";
            this.acercaDeIAAIToolStripMenuItem.Click += new System.EventHandler(this.acercaDeIAAIToolStripMenuItem_Click);
            // 
            // altaResponsableToolStripMenuItem1
            // 
            this.altaResponsableToolStripMenuItem1.Name = "altaResponsableToolStripMenuItem1";
            this.altaResponsableToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.altaResponsableToolStripMenuItem1.Text = "Alta Responsable";
            this.altaResponsableToolStripMenuItem1.Click += new System.EventHandler(this.altaResponsableToolStripMenuItem1_Click);
            // 
            // Menu_inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 370);
            this.Controls.Add(this.estado);
            this.Controls.Add(this.menu);
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
        private System.Windows.Forms.ToolStripMenuItem altaResponsableToolStripMenuItem1;



    }
}

