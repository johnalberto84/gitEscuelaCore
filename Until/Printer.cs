using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace EscuelaCore.Until
{
    public static class Printer
    {
        public static void DibujarLinea(int tam=10)
        {
            
             var linea = "".PadLeft(tam,'=');
             WriteLine(linea);
            
        }

        public static void WriteTitle( string titulo)
        {
            DibujarLinea(titulo.Length+4);
            WriteLine($"|{titulo}|");
            DibujarLinea(titulo.Length+4);


        }

        public static void Beep (int hz =2000, int tiempo =500 , int cantidad=1)
        {
            while (cantidad-- > 0 )
            {
                Console.Beep(hz, tiempo);
                
            }

        }

    }
}