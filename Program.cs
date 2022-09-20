using EscuelaCore.Entidades;
using EscuelaCore.App;
using EscuelaCore.Until;

internal class Program
{
    private static void Main(string[] args)
    {
        EscuelaEngine esc = new EscuelaEngine();
        esc.Inicializar();
        Printer.Beep(10000,cantidad:10);
        ImprimirCursos( esc.Escuela);


        
    }

    private static void ImprimirCursos(Escuela esc)
        {
            Printer.WriteTitle("La Gloria de DIOS estoy aprendiendo");
            foreach (var cur in esc.Cursos)
            {

                foreach (var alu in cur.Alumnos)
                {
                                  
                    foreach (var eva in alu.Evaluaciones)
                    {
                        Console.WriteLine($"Evaluacion{eva.Nombre} ' Alumno'{eva.Alumno.Nombre}' Nota:'{eva.Nota.ToString()} ");
                    }

                }      
                        
                    
               
            }
        }
}