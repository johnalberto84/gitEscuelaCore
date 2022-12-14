using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace EscuelaCore.Until
{
    public static class Printer
    {
        public static void DrawLine(int tam=10)
        {
            
             var linea = "".PadLeft(tam,'=');
             WriteLine(linea);
            
        }

        public static void PresioneEnter()
        {
            
             
             WriteLine("Presione Enter para continuar");
            
        }

        public static void WriteTitle( string titulo)
        {
            DrawLine(titulo.Length+4);
            WriteLine($"|{titulo}|");
            DrawLine(titulo.Length+4);


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