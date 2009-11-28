using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iaai.metodos_comunes
{
    class Utiles
    {

        public bool ValidarDni(string dni)
        {

            if (dni.Length < 8)
                return false;

            foreach (char c in dni) 
            {
                if (!char.IsDigit(c))
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
