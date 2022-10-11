using EscuelaCore.Entidades;
using EscuelaCore.App;
using EscuelaCore.Until;
using gitEscuelaCore.Entidades;
using gitEscuelaCore.App;

internal class Program
{
    private static void Main(string[] args)
    {

#region Eventos
/*
        AppDomain.CurrentDomain.ProcessExit+=AccionDelEvento;
        AppDomain.CurrentDomain.ProcessExit+= (o,s) =>
        {
            Printer.Beep(2000, 1000, 1);
        };
        AppDomain.CurrentDomain.ProcessExit-=AccionDelEvento;
*/        
#endregion

        EscuelaEngine esc = new EscuelaEngine();
        esc.Inicializar();
        Printer.WriteTitle("Bienvenidos a la escuela");

        var  reporteador = new Reporteador(esc.GetDiccionarioObjetos());

        var evalList= reporteador.GetListaEvaluaciones();
        var asiList = reporteador.GetListaAsignaturas();
        var asixEval = reporteador.GetDicEvaluacionesXAsignatura();
        var promEval= reporteador.GetPromedioalumnosXAsignatura();


#region llenado
/*
        //Printer.Beep(10000,cantidad:2);
        ImprimirCursos( esc.Escuela);

        
        var listaObjetos = esc.GetObjetosEscuela(out int conetoEvaluaciones,
                                                 out int conetoAsignaturas,
                                                 out int conetoCursos,
                                                 out int conetoAlumnos);
    
     Dictionary<int,string> diccionario = new Dictionary<int, string>();

     diccionario.Add(11,"Jauncho Carreño");
     diccionario.Add(22,"Jennifercita");

     //throw new Exception();

        Printer.WriteTitle("Diccionario");
     foreach (var dic in diccionario)
     {
        Console.WriteLine($"Key:{dic.Key} Valor:{dic.Value}");
     }

      //diccionario.Add(22," y Jennifercita");

     Console.WriteLine(diccionario[22]);

     Printer.WriteTitle("Nuevo Diccionario");

     var di = new Dictionary<string,string>();
        di["luna"]= "Cuerpo Celeste para la Gloria de DIOS";
        Console.Write($"Luna:{di["luna"]}");


       var dictemp= esc.GetDiccionarioObjetos();

       esc.ImprimirDiccionario(dictemp,true);
 */      
#endregion





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

    private static void AccionDelEvento(object? sender, EventArgs e)
    {
        Printer.WriteTitle("SALIENDO");
        Printer.Beep(3000,1000,3);
        Printer.WriteTitle("SALIO");
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