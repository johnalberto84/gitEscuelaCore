using EscuelaCore.Entidades;
using EscuelaCore.App;
using EscuelaCore.Until;
using gitEscuelaCore.Entidades;
using gitEscuelaCore.App;
using  static System.Console;

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
        var toppro= reporteador.GetEvaluacionesTopAsignaturas(5);

        Printer.WriteTitle("Obteniendo Evaluaciones");

        var evalu = new Evaluación();
        string nombre, notastring;
        float nota;

        WriteLine("Escriba el nombre d ela evalución:");
        Printer.PresioneEnter();
        nombre= Console.ReadLine();

      if (string.IsNullOrWhiteSpace(nombre))
      {
        throw new ArgumentException("El valor del nombre no puede ser bacio");
      }
      else
      {
        evalu.Nombre=nombre.ToLower();
        Console.WriteLine($"El nombre fue procesado:{nombre}...... ");
      }

      WriteLine("Escriba la nota de evalución:");
      Printer.PresioneEnter();
      notastring= Console.ReadLine();

      if (string.IsNullOrWhiteSpace(notastring))
      {
        throw new ArgumentException("El valor de la nota puede ser vacio");
      }
      else
      {

        try
        {
             evalu.Nota= float.Parse(notastring);

            if (evalu.Nota <0 || evalu.Nota >5 )
            {
                throw new ArgumentOutOfRangeException ($"El valor debe tener un rago entre 0.0 y 5.0:{notastring}...... ");
                 
            }
            else
            {
               
                Console.WriteLine($"El nota fue procesado:{notastring}...... ");
            }
            
        }
        catch(ArgumentOutOfRangeException arge)
        {
            WriteLine(arge.Message);
        }
        catch (Exception)
        {
            
           WriteLine("Saliendo del programa");
        }
        finally
        {
            WriteLine("Finally");
            Printer.Beep(2000,500,3);

        }

        PrintReport();
        
       
      }
      




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

    private static void PrintReport()
    {

       

        int opcion;
        string opcionstring  ;

        Printer.WriteTitle("Opciones de Reporte");
        WriteLine("Digite Ver Listado de Todas las Evaluaciones (1) ");
        WriteLine("Digite Ver Listado de Asignaturas (2) ");
        WriteLine("Digite Ver Listado de Todas las Evaluaciones x Asignaura (3) ");
        WriteLine("Digite Ver Listado de promedios de mas asignatura (4) ");
        WriteLine("Digite Ver Listado Las mejores evaluaciones (5) ");
        
        Printer.PresioneEnter();
        opcionstring= Console.ReadLine();

        if (string.IsNullOrWhiteSpace(opcionstring))
        {
            throw new ArgumentNullException("No has registrado ninguna opción");
        }
        else
        {
                try
                {
                    
                    opcion= Convert.ToInt32(opcionstring);
                    if (opcion<0 || opcion>5)
                    {
                        throw new ArgumentOutOfRangeException("La opción esta por fuera del rango");
                        
                    }
                    else
                    {
                        switch (opcion)
                        {
                            case 1:
                                WriteLine("Elegiste Opción (1)");
                            break;

                             case 2:
                                WriteLine("Elegiste Opción (2)");
                            break;
                             case 3:
                                WriteLine("Elegiste Opción (3)");
                            break;

                             case 4:
                                WriteLine("Elegiste Opción (4)");
                            break;
                            
                            default :
                                TopPromedio();
                                WriteLine("Elegiste Opción (5)");
                            break;
                        }

                        
                    }


                }
                catch ( ArgumentOutOfRangeException arge )
                {
                    
                    WriteLine(arge.Message);
                }
                catch
                {
                    throw new ArgumentException("La opción de selecciono no es un numero:");
                    
                }
        }

        



    }

    private static void TopPromedio()
    {

        string topstring;
        int top;
        WriteLine("Digite Ver Listado Las mejores evaluaciones:");
        Printer.PresioneEnter();
        topstring= Console.ReadLine();

        if (string.IsNullOrWhiteSpace(topstring))
        {
            throw new ArgumentNullException("Cuantos alumnos quieres ver");
        }
        else
        {
            try
            {
                top= int.Parse(topstring);
                WriteLine($"El Top de alumnos es {topstring}");
            }
            catch (Exception ex)
            {
                
               WriteLine("Probablemente lo que escribio no era un número"+ ex.Message);
            }
           
        }

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