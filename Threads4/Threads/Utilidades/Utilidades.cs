using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Utilidades
{
    class Utilidades
    {

        public static string ultimosnum(string linea)
        {
            int g = linea.Length - 1;
            string cant = "";
            int i = 0;
            while (int.TryParse(linea[g].ToString(),out i) == false)
            {
                g = g - 1;
            }
            while (int.TryParse(linea[g].ToString(), out i) == true | linea[g] == '.')
            {
                cant = linea[g] + cant;
                g = g - 1;
            }
            return cant;
        }
        public static decimal extraerRake(string linea)
        {
            string cant = "";
            if (linea != null)
            {
                int g = linea.Length - 1;

                int i = 0;
                while (linea[g].ToString() == "€")
                {
                    g = g - 1;
                }
                while (int.TryParse(linea[g].ToString(), out i) == true | linea[g] == '.')
                {
                    cant = linea[g] + cant;
                    g = g - 1;
                }
            }
            try
            {
                return Convert.ToDecimal(cant.Replace(".", ","));
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public static string extraercartassumary(string str)
        {
            string cartas = "";
            int u = 0;
            while (str[u] != '[')
            {

                u = u + 1;
            }
            while (str[u] != ']')
            {
                int i = 0;
                if (str[u] == 'A' | str[u] == 'T' | str[u] == 'J' | str[u] == 'Q' | str[u] == 'K' | int.TryParse(str[u].ToString(),out i) == true | str[u] == 'c' | str[u] == 's' | str[u] == 'h' | str[u] == 'd')
                {
                    cartas = cartas + str[u];
                }
                u = u + 1;
            }
            return cartas;
        }
    }
}
