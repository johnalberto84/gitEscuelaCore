using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscuelaCore.Entidades;
using gitEscuelaCore.Entidades;
using EscuelaCore.Until;

namespace EscuelaCore.App
{
  //sealed significa sellada que la clace no puede heredar
    public sealed class EscuelaEngine
    {

        public Escuela Escuela { get; set; }


        public EscuelaEngine()
        {

        }



        public void Inicializar()
        {
            Escuela = new Escuela("Escuela Platzi", 2022, TipoEscuela.Secundaria,
            pais: "Colombia", ciuddad: "Floridablanca");

            CargarCursos();

            CargarAsignaturas();

            CargarEvaluaciones();
          
            //CargarEvaluacionesYo(5);


        }

    public void ImprimirDiccionario(Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> dic,
    bool imprimirEvaluacion=false)
    {
        foreach (var obj in dic)
        {
            Printer.WriteTitle(obj.Key.ToString());

            foreach (var con in obj.Value)
            {

              switch (obj.Key )
              {

                case LlavesDiccionario.Evaluacion :
                if (imprimirEvaluacion)
                  Console.WriteLine("Evaluacion:"+ con);

                break;

                case LlavesDiccionario.Alumno :
                Console.WriteLine("Alumno:"+ con.Nombre);
                break;

                case LlavesDiccionario.Asignatura:
                Console.WriteLine("Asignatura:"+ con.Nombre);

                break;

                case LlavesDiccionario.Curso:
                Console.WriteLine("Cursos:"+ con.Nombre);

                break;
                
                default:
                Console.WriteLine(con) ;
                break;
                
              }


              
        
            /*
             if (con is Evaluación )
             {
                if (imprimirEvaluacion)
                {
                   Console.WriteLine(con);
                }
               
             }
             else
             {
               Console.WriteLine(con);
             }
             */

                
            }
        }
    }
    public Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
    {

      var diccionario = new Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>>();

      diccionario.Add(LlavesDiccionario.Escuela, new[] {Escuela});
      diccionario.Add(LlavesDiccionario.Curso,Escuela.Cursos.Cast<ObjetoEscuelaBase>());

      var listaAsi= new List<Asignatura>();
      var listaEva= new List<Evaluación>();
      var listaAlu = new List<Alumno>();

      foreach (var cur in Escuela.Cursos)
      {

        listaAlu.AddRange(cur.Alumnos);
        listaAsi.AddRange(cur.Asignaturas);
      

          foreach (var alu in cur.Alumnos)
          {
            listaEva.AddRange(alu.Evaluaciones);
          }
        
      }

      diccionario.Add(LlavesDiccionario.Asignatura ,
       listaAsi.Cast<ObjetoEscuelaBase>());

      diccionario.Add(LlavesDiccionario.Alumno, 
      listaAlu.Cast<ObjetoEscuelaBase>());

      diccionario.Add(LlavesDiccionario.Evaluacion, 
      listaEva.Cast<ObjetoEscuelaBase>());

      return diccionario;

    }

     public List<ObjetoEscuelaBase> GetObjetosEscuela(
      out  int conetoEvaluaciones,
      bool traerEvaluacion = true,
      bool traerAsignaturas = true,
      bool traerCursos = true,
      bool traerAlumnos = true) 
    {
        return GetObjetosEscuela(out conetoEvaluaciones);
    }


    public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
      out  int conetoEvaluaciones,
      out int conetoAsignaturas,
      out int conetoCursos,
      out int conetoAlumnos,
      bool traerEvaluacion = true,
      bool traerAsignaturas = true,
      bool traerCursos = true,
      bool traerAlumnos = true) 
    {
 
      var listObj = new List<ObjetoEscuelaBase>();

      conetoEvaluaciones=0;
      conetoAsignaturas=0;
      conetoCursos=0;
      conetoAlumnos=0;


      listObj.Add(Escuela);

      if (traerCursos)
      listObj.AddRange(Escuela.Cursos);
      conetoCursos+= Escuela.Cursos.Count;

      foreach (var cur in Escuela.Cursos)
      {
        if (traerAsignaturas)
          listObj.AddRange(cur.Asignaturas);
          conetoAsignaturas+=cur.Asignaturas.Count;

        if (traerAlumnos)
          listObj.AddRange(cur.Alumnos);
          conetoAlumnos+=cur.Alumnos.Count;
        
        
        if (traerEvaluacion)
        {
           foreach (var alu in cur.Alumnos)
            {
              listObj.AddRange(alu.Evaluaciones);
              conetoEvaluaciones+= alu.Evaluaciones.Count();
            }
        }
           
      }


      return listObj.AsReadOnly();
    }    



        private void CargarEvaluacionesYo( int numeroEvaluaciones )
        {

          

          var listaEvaluaciones = from c1 in Escuela.Cursos
                                  from c2 in c1.Alumnos
                                  from c3 in c1.Asignaturas
                                  select new Evaluación { Alumno=c2, Asignatura=c3};

            for (int i = 0; i < numeroEvaluaciones; i++)
            {


                  foreach (var eva in listaEvaluaciones)
                  {

                    eva.Nombre= "Eva"+i.ToString()+ eva.Asignatura;
                    Random entero = new Random();
                    Random deci = new Random();
                    string numero = entero.ToString()+"."+deci.ToString();
                    eva.Nota= float.Parse(numero, System.Globalization.CultureInfo.InvariantCulture);

                  }
              
            
              
            }

            
        }

        private void CargarEvaluaciones()
        {

          var rdn = new Random();
          foreach (var cur in Escuela.Cursos)
          {
             foreach (var asi in cur.Asignaturas)
             {

              foreach (var alu in cur.Alumnos)
              {
                
                
                for (int i = 0; i < 5; i++)
                {
                  var eva = new Evaluación
                  { Asignatura= asi,
                    Nombre=$"{asi.Nombre}, Eva# {i + 1}",
                    Nota = (float)Math.Round((5*rdn.NextDouble()),2),
                    Alumno=alu

                  };
                  alu.Evaluaciones.Add(eva);

                  
                  
                }
              }
              
             }
          }
        }
        

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>()
              {
                new Asignatura{Nombre="Matematicas" },
                new Asignatura {Nombre="Educación Fisíca"} ,
                new Asignatura {Nombre="Castellano"} ,
                new Asignatura{Nombre="Cianecias Naturales" },
                new Asignatura {Nombre="Geometria" } ,
              };
                curso.Asignaturas=listaAsignaturas;
            }
        }

        private IEnumerable<Alumno> GenerarAlumnosAlAzar( int cantidad)
        {
           string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

           var listaAlumnos = from n1 in nombre1
                              from n2 in nombre2
                              from a1 in apellido1
                              select new Alumno{Nombre=$"{n1} {n2} {a1}"};

          return listaAlumnos.OrderBy( (a1)=> a1.UniqueId ).Take(cantidad).ToList() ;

        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso{Nombre="101" ,TipoJornada =TipoJornada.Mañana },
                new Curso {Nombre="201",TipoJornada =TipoJornada.Mañana } ,
                new Curso {Nombre="301",TipoJornada =TipoJornada.Mañana } ,
                new Curso{Nombre="401" ,TipoJornada =TipoJornada.Tarde },
                new Curso {Nombre="501",TipoJornada =TipoJornada.Tarde }

               };

              Random rnd = new Random();

              int cantidadrdn = rnd.Next(1,10);
              
      


            foreach (var c in Escuela.Cursos)
            {
              c.Alumnos= GenerarAlumnosAlAzar(cantidadrdn).ToList();
            }   
        }

    }
}