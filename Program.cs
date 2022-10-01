using EscuelaCore.Entidades;
using EscuelaCore.App;
using EscuelaCore.Until;
using gitEscuelaCore.Entidades;

internal class Program
{
    private static void Main(string[] args)
    {
        EscuelaEngine esc = new EscuelaEngine();
        esc.Inicializar();
        Printer.WriteTitle("Bienvenidos a la escuela");

        Printer.Beep(10000,cantidad:2);
        ImprimirCursos( esc.Escuela);

        var listaObjetos = esc.GetObjetosEscuela(true,false,false,false );




        /* var listaObjetosIlugar = from obj in listaObjetos
                                 where obj is ILugar
                                select (ILugar) obj; */

        //esc.Escuela.LimpiarLugar();

        /*
        Printer.DrawLine(20);
        Printer.DrawLine(20);
        Printer.DrawLine(20);
        Printer.WriteTitle("Pruebas de Polimorfismo");

        var alumnoTest = new Alumno(){Nombre= "Juancho Alberto Carreño"};
        ObjetoEscuelaBase ob = alumnoTest;
        Printer.WriteTitle("Alumno");
        Console.WriteLine($"Almmno: {alumnoTest.Nombre}");
        Console.WriteLine($"UniqueId: {alumnoTest.UniqueId}");
        Console.WriteLine($"UniqueId: {alumnoTest.GetType()}");

        Printer.WriteTitle("ObjetoEscuela");
        Console.WriteLine($"Alumno:{ob.Nombre}");
        Console.WriteLine($"UniqueId:{ob.UniqueId}");
        Console.WriteLine($"UniqueId: {ob.GetType()}");

        var objDummy = new ObjetoEscuelaBase(){Nombre="Pipo Carreño"};
        Printer.WriteTitle("ObjetoEscuelaBase");
        Console.WriteLine($"Alumno:{objDummy.Nombre}");
        Console.WriteLine($"Alumno:{objDummy.UniqueId}");
        Console.WriteLine($"Alumno:{objDummy.GetType()}");

        var eva = new Evaluación(){Nombre="Evaluacion de Math", Nota=4.7f};

        Printer.WriteTitle("Evaluacion");
        Console.WriteLine($"Alumno:{eva.Nombre}");
        Console.WriteLine($"Alumno:{eva.UniqueId}");
        Console.WriteLine($"Alumno:{eva.Nota.ToString()}");
        Console.WriteLine($"Alumno:{eva.GetType()}");

        ob = eva;
        if (ob is Alumno)
        {
            Alumno alumnorecuperado = (Alumno)ob;
        }

        Alumno alumnorecuperado2 = ob as Alumno ;

        */



        
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