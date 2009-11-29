using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iaai.metodos_comunes
{
    class Utiles
    {


        /// <summary>
        /// Valida la estructura de un DNI para los formatos aceptados como validos (xxxxxxxxF o xxxxxxxxM)  (xxxxxxxx).
        /// </summary>
        /// <param name="dni">string DNI</param>
        /// <returns>true: si es valido 
        /// false: si no es valido
        /// </returns>
        /// 
        public bool ValidarDni(string dni)
        {

            if (dni.Length > 9)
                return false;
            else
            {
                if (dni.Length < 8)
                    return false;
            }

            if (dni.Length == 9 ){
                if (dni[8] != 'F' && dni[8] != 'M')
                    return false;
                
            }
            
            
            for(int i=0;i<8; i++) 
            {
                    if (!char.IsDigit(dni[i]))
                        return false;
            }

            return true;
        }

        /// <summary>
        /// Valida estructura de correo electronico
        /// </summary>
        /// <param name="email">String con email a validar</param>
        /// <returns>true o false en funcion del resultado obtenido</returns>
        public bool validar_email(string email)
        {
            if (email == "")
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
            return true;
        }
        

        struct prueba
        {
            string cadena;
            bool esperado;

            public prueba(string val, bool valor)
            {
                cadena = val;
                esperado = valor;
            }

            public string get_cadena()
            {

                return cadena;
            }

            public bool get_esperado()
            {
                return esperado;
            }
        }
    }
}
