using EscuelaCore.Entidades;

namespace EscuelaCore.Entidades
{
    public class Curso
    {

       

        public string UniqueId{get; private set;}
    
        public string Nombre { get; set; }

        public TipoJornada TipoJornada { get; set; }

        public Curso()=> UniqueId=Guid.NewGuid().ToString();

        public List<Asignatura> Asignaturas{get;set;}

        public List<Alumno> Alumnos{get;set;}




        
    }
}