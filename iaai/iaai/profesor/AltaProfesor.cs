using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iaai.profesor
{
    public partial class Altaprofesor : Form
    {
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
    }

}
