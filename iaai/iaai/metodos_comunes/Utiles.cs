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
            if (email != "")
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


        /// <summary>
        /// Valida caracteres validos para el nombre y apellido
        /// </summary>
        /// <example>
        /// andres gomez
        /// juan.gonzales
        /// 
        /// </example>
        /// <param name="cadena">Nombre o apellido a validar</param>
        /// <returns>
        /// true: si es valido
        /// false: si no es valido
        ///</returns>
        public bool validar_Nombre_App(String cadena)
        {
            if (cadena == "")
                return false;

            bool valido = true;

            foreach (char c in cadena)
            {
                if (Char.IsLetter(c)  || char.IsWhiteSpace(c) || c == '.' || c==96 || c=='\'' )
                {
                    valido = true;
                }
                else
                    return false;

                
            }

            return valido;
        }

        /// <summary>
        /// Valida caracteres validos para el año de cursado
        /// </summary>
        /// <returns>
        /// true: si es valido
        /// false: si no es valido
        ///</returns>
        public bool validar_Escuela_Año(String cadena)
        {
            if (cadena == "")
                return false;

            bool valido = true;

            foreach (char c in cadena)
            {
                if (Char.IsDigit(c) || c == '°')
                {
                    valido = true;
                }
                else
                    return false;


            }

            return valido;
        }


        /// <summary>
        /// Valida caracteres validos para campo direccion Permitidos ( ) . º [a-z] [A-Z] [0-9]
        /// </summary>
        /// <example>
        /// Urquiza 3225
        /// D'agostino 325 7º B
        /// Avda. San Martin 3452
        /// San juan 3225 (Pasillo) dto. 2º
        /// </example>
        /// <param name="cadena">Direccion a validar en formato String</param>
        /// <returns>
        /// true: si es valido  
        /// false: si no es valido 
        /// </returns>
        public bool validar_Direccion(String cadena)
        {

            bool valido = true;



            foreach (char c in cadena)
            {
                if (Char.IsLetter(c) || Char.IsDigit(c) || char.IsWhiteSpace(c) || c == '.' || 
                    c == 96 || c== 'º' || c == '(' || c== ')' || c== 39)
                {
                    valido = true;
                }
                else
                    return false;


            }

            return valido;
        }


        /// <summary>
        /// Valida caracteres validos para campo telefono 7 x [0-9]
        /// </summary>
        /// <param name="cadena">telefono a validar en formato String</param>
        /// <returns>
        /// true: si es valido  
        /// false: si no es valido 
        /// </returns>
        public bool validar_Telefono(String cadena)
        {

            bool valido = true;

            if (cadena.Length > 9 || cadena.Length < 5)
                return false;

            foreach (char c in cadena)
            {
                if (Char.IsDigit(c))
                {
                    valido = true;
                }
                else
                    return false;


            }

            return valido;
        }

        /// <summary>
        /// Valida caracteres validos para campo caracteristica 5 x [0-9]
        /// </summary>
        /// <param name="cadena">caracteristica a validar en formato String</param>
        /// <returns>
        /// true: si es valido  
        /// false: si no es valido 
        /// </returns>
        public bool validar_Caracteristica(String cadena)
        {

            bool valido = true;

            if (cadena.Length > 5 || cadena.Length < 3)
                return false;

            foreach (char c in cadena)
            {
                if (Char.IsDigit(c))
                {
                    valido = true;
                }
                else
                    return false;


            }

            return valido;
        }

        /// <summary>
        /// Valida fecha de nacimiento y verifica si la fecha representa a un mayor de edad o a un menor
        /// </summary>
        /// <param name="cadena">fecha validar en formato String</param>
        /// <returns>
        /// -1: si no es valida  
        /// 0: si es menor de 21
        /// 1: si es valida
        /// </returns>
        public int validar_Fecha_Nacimiento(String cadena)
        {

            bool valido= true;
            
            int pos = 0; 

                for (int i = pos; i < 2; i++ )  
                {
                    if (char.IsDigit(cadena[i]))
                    {
                        valido = true;
                    }
                    else return -1;

                    pos = i;
                }
                
                pos += 1;
                
                if(cadena[pos] != '/')
                    return -1;  // encontro caracter no valido

                //validado hasta XX/

                pos += 1;

                for (int j= pos; j < 5; j++)
                {
                    if (char.IsDigit(cadena[j]))
                    {
                        valido = true;
                    }
                    else return -1;

                    pos = j;
                }

                pos += 1;
                if (cadena[pos] != '/')
                    return -1;  // encontro caracter no valido

                //validado hasta XX/XX/

                pos += 1;
                for (int s = pos; s < 10; s++)
                {
                    if (char.IsDigit(cadena[s]))
                    {
                        valido = true;
                    }
                    else return -1;
                }

                //validado hasta XX/XX/XXXX
            
            if (valido) //si el formato es valido
            {
                try
                {
                    DateTime fecha_Naciemiento = Convert.ToDateTime(cadena); //convierto a date time

                    if (fecha_Naciemiento.AddYears(21) > DateTime.Now) //controlo por mayoria de edad
                        return 0; // si menor  de edad pero fecha correcta retorno 0
                    else
                        return 1; //si fecha correcta y mayor de edad retorno 1
                }
#pragma warning disable
                catch (FormatException exc_form) {

                    return -1;
                }
#pragma warning enable
            }
            else
                return -1;
        }

    }

    
}
