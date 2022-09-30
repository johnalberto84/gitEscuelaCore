using EscuelaCore.Entidades;
using gitEscuelaCore.Entidades;

namespace EscuelaCore.Entidades
{
    public class Curso: ObjetoEscuelaBase
    {


        public TipoJornada TipoJornada { get; set; }


        public List<Asignatura> Asignaturas{get;set;}

        public List<Alumno> Alumnos{get;set;}




        
    }
}