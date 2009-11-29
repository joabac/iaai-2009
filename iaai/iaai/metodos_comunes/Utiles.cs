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
