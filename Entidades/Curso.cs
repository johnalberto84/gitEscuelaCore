using EscuelaCore.Entidades;

namespace EscuelaCore.Entidades
{
    public class Curso
    {

        public string UniqueId{get; private set;}
    
        public string Nombre { get; set; }

        public TipoJornada TipoJotnada { get; set; }

        public Curso()=> UniqueId=Guid.NewGuid().ToString();


        
    }
}