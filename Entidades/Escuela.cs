using System.Collections.Generic;
using EscuelaCore.Until;
using gitEscuelaCore.Entidades;

namespace EscuelaCore.Entidades
{
    public class Escuela: ObjetoEscuelaBase , ILugar
    {

        public int AnioCreacion { get; set; }


        public string Pais { get; set; }

        public string Ciudad { get; set; }

        public string Direccion { get; set; }

        public TipoEscuela TipoEscuela {get;set;}

        public List<Curso> Cursos { get; set; }

        public Escuela(string nombre,
                       int anio) => (Nombre , AnioCreacion)=(nombre,anio);

        public Escuela(string nombre,
                       int anio,
                       TipoEscuela tipo,
                       string pais = "",
                       string ciuddad = "")
        {
            (Nombre,AnioCreacion)=(nombre,anio);
            Pais=pais;
            Ciudad=ciuddad;

        }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}, Tipo:{TipoEscuela} {System.Environment.NewLine} Pais:{Pais}, Ciudad:{Ciudad}";
        }

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("...Limpiando Escula...");
            Console.Write($"Nombre Escuela:{Nombre}");
            foreach (var cur in Cursos)
            {
                cur.LimpiarLugar();
            }
            
            Printer.WriteTitle($"Escula:{Nombre} Limpia");
       
            Printer.Beep(1000,cantidad:3);
        }


    }

    public enum TipoEscuela
    {
        Preescola,
        
        Primaria,

        Secundaria
    }

    public enum TipoJornada
    {
        Mañana,

        Tarde,

        Noche
    }
}