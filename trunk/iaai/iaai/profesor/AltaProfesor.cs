using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iaai.metodos_comunes;

namespace iaai.profesor
{
    public partial class Altaprofesor : Form
    {

        private string error = "";
        IDictionary<string, object> datos = new Dictionary<string, object>();
        Data_base.Data_base db = new iaai.Data_base.Data_base();
        Utiles metodo = new Utiles();

        public Altaprofesor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Suma: "+ sumar(2, 2));
        }

        public int sumar(int a, int b) {

            return a + b;
        }

        private bool validar_email(string email)
        {
            bool estado_email = true;

            int i = 0;

            if (email.Length != 0)
            {
                if (email[i] == '@' || email[i] == '_' || email[i] == '-' || email[i] == '.')
                {
                    
                    estado_email = false;
                    
                }
                else
                {
                    for (int j = 0; j < email.Length - 1; j++)//verifico por caracteres especiales junto a un punto
                    {

                        if (((email[j] == '.' || email[j] == '_' || email[j] == '-') && (email[j + 1] == '.' || email[j + 1] == '@')))
                            estado_email = false;
                    }

                    if (estado_email == true)
                    {

                        while (email[i] != '@' && i < email.Length - 1)//verifico primera parte aaaa@
                        {
                            if (Char.IsDigit(email[i]) || Char.IsLetter(email[i]) ||
                                email[i] == '_' || email[i] == '-' || email[i] == '.')
                            {
                            }
                            else
                            {

                                
                                estado_email = false;
                                
                            }
                            i++;
                        }

                        if (email[i] == '@' && estado_email == true && email.Length - 1 > i)
                        { //verifico luego del arroba  @aaaa.

                            i++;

                            if (email[i] == '_' || email[i] == '-' || email[i] == '.')
                            { //primer caracter luego de arroba
                                
                                estado_email = false;
                                
                            }
                            else
                            { //verifico sean o digitos o letras o los caracteres permitidos

                                //desde el caracter 1 luego del arroba asta el primer punto
                                while (email[i] != '.' && i < email.Length - 1)//verifico primera parte aaaa@
                                {
                                    if (Char.IsDigit(email[i]) || Char.IsLetter(email[i]) ||
                                        email[i] == '_' || email[i] == '-' || email[i] == '.')
                                    {
                                    }
                                    else
                                    {
                                        
                                        estado_email = false;
                                        
                                    }
                                    i++;
                                }

                                if (email[i] == '.' && estado_email == true && email.Length - 1 > i)
                                { //todo lo demas

                                    i++;

                                    while (i < email.Length - 1)//verifico la ultima parte
                                    {

                                        if (email[i] == '_' || email[i] == '-')
                                        {
                                        
                                            estado_email = false;
                                            
                                        }

                                        else
                                        {
                                            if (Char.IsDigit(email[i]) || Char.IsLetter(email[i]) || email[i] == '.')
                                            {
                                            }
                                            else
                                            {
                                           
                                                estado_email = false;
                                                
                                            }
                                        }
                                        i++;
                                    }
                                    if (!Char.IsLetterOrDigit(email[i]))
                                    {
                                        
                                        estado_email = false;
                                        
                                    }
                                }
                                else
                                {
                    
                                    estado_email = false;
                                    
                                }

                            }

                        }
                        else
                        {
                    
                            estado_email = false;
                            
                        }
                    }
                    else
                    {
                    
                        estado_email = false;    
                    }

                }
            }
            else
            {
                
                estado_email = false;
                
            }
            return estado_email;
        }

        private void validar_mail(object sender, EventArgs e)
        {
            if (email.Text != "")
            {
                if (validar_email(email.Text) == false)
                {
                    MessageBox.Show("Formato de email no valido");
                    email.Focus();
                }
            }
            
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            error = "";
            if (nombre.Text.Length == 0)
                error = error + "Ingrese el Nombre. \r\n";
            if (apellido.Text.Length == 0)
                error = error + "Ingrese el Apellido. \r\n";
            if (dni.Text.Length == 0)
                error = error + "Ingrese el DNI. \r\n";
            if (fecha_nacimiento.Text.Contains(' '))
                error = error + "Ingrese la fecha de nacimiento. \r\n";
            if (telefono_numero.Text.Length == 0)
                error = error + "Ingrese el teléfono. \r\n";
            if (direccion.Text.Length == 0)
                error = error + "Ingrese la dirección. \r\n";



            

            bool validar = fecha_nacimiento.Text.Contains(' ');
            if (!validar)//si la fecha esta ingresada
            {
                //si menor de 21 años hay que controlar que se le haya asignado un responsable
                if (Convert.ToDateTime(fecha_nacimiento.Text).AddYears(21) > DateTime.Today)
                {
                    MessageBox.Show("El profesor debe ser mayor de Edad");
                    fecha_nacimiento.Focus();
                }
            }

            if (error.Length > 0)
            {
                error = "Se han producido errores: \r\n" + error;
                MessageBox.Show(error);
                
            }
            if (metodo.ValidarDni(dni.Text) == true )
            {
                    if (!db.BuscarDniProfesor(dni.Text)) {

                        error = "El profesor ya fue dado de alta en el sistema";
                        MessageBox.Show(error);
                    }
                                 
            }
            else
            {
                error = "El DNI ingresado no es valido";
                MessageBox.Show(error);
            }

            if (error == "") {
                guardarDatos();
            }
        }
        
        //TODO: comentar y especificar que guarda?
        private void guardarDatos()
        {
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
            
        }
    }

}
