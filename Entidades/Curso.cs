using EscuelaCore.Entidades;
using EscuelaCore.Until;
using gitEscuelaCore.Entidades;

namespace EscuelaCore.Entidades
{
    public class Curso: ObjetoEscuelaBase, ILugar
    {


        public TipoJornada TipoJornada { get; set; }

        public string Direccion { get; set; }



        public List<Asignatura> Asignaturas{get;set;}

        public List<Alumno> Alumnos{get;set;}

        public void LimpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("...Limpiando...");
            Console.Write($"Nombre Curso:{Nombre}");
        }
    }
}