﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iaai.metodos_comunes;
using iaai.responsable;

namespace iaai.alumno

{
    public partial class ModificarAlumno : Form
    {
        Alumno alumno_encontrado = new Alumno();
        private string error = "";
        IDictionary<string, object> datos = new Dictionary<string, object>();
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        Utiles metodo = new Utiles();

        private int responsable = -1;

        public ModificarAlumno()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Se modifican los datos personales de un alumno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void aceptar_Click(object sender, EventArgs e)
        {
            //valida que los datos ingresados no contengan errores
            if (validar())
            {
                //carga los datos ingresados en la variable "datos (IDictionary)"
                guardarDatos();


                Alumno alumno = new Alumno(datos);
                
                //si se pudieron modificar los datos del alumno
                if (db.modificarAlumno(alumno))
                {
                    MessageBox.Show("El alumno fué modificado con éxito.");
                    this.Close();

                }
                else
                    MessageBox.Show("Ocurrió un error en base de datos.");
            }
        }

        /// <summary>
        /// Carga los datos ingresados en la interfaz, en una variable IDictionary
        /// </summary>
        private void guardarDatos()
        {

            //cargo datos basicos del profesor
            datos["nombre"] = nombre.Text;
            datos["apellido"] = apellido.Text;
            datos["dni"] = dni.Text;
            datos["fecha_nac"] = (object)fecha_nacimiento.Text;

         
            if (telefono_carac.Text.Length > 0)
            {
                datos["telefono_carac"] = telefono_carac.Text;
            }
            else
            {
                datos["telefono_carac"] = null;
            }

            datos["telefono_numero"] = (object)telefono_numero.Text;


            datos["direccion"] = direccion.Text;

            if (escuela_nombre.Text.Length > 0)
            {
                datos["escuela_nombre"] = escuela_nombre.Text;
                datos["escuela_año"] = escuela_año.Text;
            }
            else
            {
                datos["escuela_nombre"] = null;
                datos["escuela_año"] = null;
            }

            if (responsable != -1)
            {
                datos["id_responsable"] = (object)responsable;
            }
            else
            {
                datos["id_responsable"] = null;
            }

        }

        /// <summary>
        /// Se validan los datos personales del alumno y se muestran los errores si existen
        /// </summary>
        /// <returns>true: si no tiene errores
        ///          false: si tiene errores
        /// </returns>
        private bool validar()
        {

            error = "";
            if (nombre.Text.Length == 0)
                error = error + "Ingrese el Nombre. \r\n";


            else
            {
                if (!metodo.validar_Nombre_App(nombre.Text))
                    error = error + "Formato de nombre no válido \r\n";
            }

            if (apellido.Text.Length == 0)
                error = error + "Ingrese el Apellido. \r\n";
            else
            {
                if (!metodo.validar_Nombre_App(apellido.Text))
                    error = error + "Formato de apellido no válido \r\n";
            }
        
            if (fecha_nacimiento.Text.Contains(' '))
                error = error + "Ingrese la fecha de nacimiento. \r\n";
            if (telefono_numero.Text.Length == 0)
                error = error + "Ingrese el teléfono. \r\n";
            if (direccion.Text.Length == 0)
                error = error + "Ingrese la dirección. \r\n";

            if (escuela_nombre.Text.Length > 0)
            {
                //si ingreso la escuela, controlo que ingrese el año de cursado
                if (escuela_año.Text.Length == 0)
                    error = error + "Ingrese el año de cursado. \r\n";
            }
            else if (escuela_año.Text.Length > 0)
            {
                error = error + "Ingrese el nombre de la escuela. \n";
            }

            bool validar = fecha_nacimiento.Text.Contains(' ');
            if (!validar)//si la fecha esta ingresada
            {
                {
                    //si menor de 21 años hay que controlar que se le haya asignado un responsable
                    if (Convert.ToDateTime(fecha_nacimiento.Text).AddYears(21) > DateTime.Today)
                    {
                        if (responsable == -1)
                        {
                            error = error + "Debe asignar un responsable. \n";
                        }
                    }
                }
            }

            if (error.Length > 0)
            {
                error = "Se han producido errores: \r\n" + error;
                MessageBox.Show(error);

            }

            if (error == "")
            {
                return true;

            }

            return false;


        }

        /// <summary>
        /// Busca el alumno, dado su DNI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button_buscar_Click(object sender, EventArgs e)
        {
            //si el dni es correcto
            if (metodo.ValidarDni(dni.Text))
            {
                //Busca el alumno en la base de datos
                alumno_encontrado = db.Buscar_Alumno(dni.Text);

                if (alumno_encontrado == null)
                    MessageBox.Show("El DNI no es de un alumno registrado en el Instituto");
                else
                {
                    //se habilitan los textBox
                    nombre.Enabled = true;
                    apellido.Enabled = true;
                    fecha_nacimiento.Enabled = true;
                    telefono_carac.Enabled = true;
                    telefono_numero.Enabled = true;
                    direccion.Enabled = true;
                    escuela_nombre.Enabled = true;
                    escuela_año.Enabled = true;
                    modificarResponsable.Enabled = true;

                    //se cargan los datos del alumno, en los textBox
                    nombre.Text = alumno_encontrado.getNombre();
                    apellido.Text = alumno_encontrado.getApellido();
                    fecha_nacimiento.Text = alumno_encontrado.getFecha_nac().ToString();
                    if (alumno_encontrado.getTelefono_carac() != 0)
                    {
                        telefono_carac.Text = alumno_encontrado.getTelefono_carac().ToString();
                    }
                    else
                    {
                        telefono_carac.Text = "";
                    }
                    telefono_numero.Text = alumno_encontrado.getTelefono_numero().ToString();
                    direccion.Text = alumno_encontrado.getDireccion();
                    escuela_nombre.Text = alumno_encontrado.getEscuela_nombre();
                    if (alumno_encontrado.getEscuela_año() != 0)
                    {
                        escuela_año.Text = (Convert.ToString(alumno_encontrado.getEscuela_año()));
                    }
                    else
                    {
                        escuela_año.Text = "";
                    }

                    //si el alumno es menor de 21 años actualizo el id del responsable en la variable auxiliar de la clase
                    if (Convert.ToDateTime(fecha_nacimiento.Text).AddYears(21) <= DateTime.Today)
                    {
                        responsable = -1;
                    }
                    else
                    {
                        responsable = alumno_encontrado.getId_responsable();
                    }
                    

                }

            }
            else
            {
                MessageBox.Show("El DNI ingresado es incorrecto");
            }
            
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modificarResponsable_Click(object sender, EventArgs e)
        {
            if (fecha_nacimiento.Text.Contains(' '))
            {
                MessageBox.Show("Ingrese la fecha de nacimiento");
            }
            else if (Convert.ToDateTime(fecha_nacimiento.Text).AddYears(21) < DateTime.Today)
            {
                MessageBox.Show("No se puede asignar un responsable \n a un alumno mayor de 21 años.");
            }
            else
            {
                AsignarResponsable modificarResponsable = new AsignarResponsable(alumno_encontrado.getId_responsable());
                modificarResponsable.Owner = this;
                this.SetVisibleCore(false);
                modificarResponsable.Show();
            }
        }

        public void asignarResponsable(int resp)
        {
            this.responsable = resp;
        }
        
    }
}
