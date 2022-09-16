namespace EscuelaCore.Entidades
{
    public class Escuela
    {
        public string Nombre{get;set;}

        public int AnioCreacion { get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }

        public TipoEscuela TipoEscuela {get;set;}

        public Curso[] Cursos { get; set; }

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