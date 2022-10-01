using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscuelaCore.Entidades;
using gitEscuelaCore.Entidades;

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


    public (List<ObjetoEscuelaBase>,int) GetObjetosEscuela(
      bool traerEvaluacion = true,
      bool traerAsignaturas = true,
      bool traerCursos = true,
      bool traerAlumnos = true) 
    {
 
      var listObj = new List<ObjetoEscuelaBase>();

      int conetoEvaluaciones=0;

      listObj.Add(Escuela);

      if (traerCursos)
      listObj.AddRange(Escuela.Cursos);

      foreach (var cur in Escuela.Cursos)
      {
        if (traerAsignaturas)
          listObj.AddRange(cur.Asignaturas);

        if (traerAlumnos)
          listObj.AddRange(cur.Alumnos);
        
        
        
        if (traerEvaluacion)
        {
           foreach (var alu in cur.Alumnos)
            {
              listObj.AddRange(alu.Evaluaciones);
              conetoEvaluaciones+= alu.Evaluaciones.Count();
            }
        }
           
      }


      return (listObj, conetoEvaluaciones);
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
          foreach (var cur in Escuela.Cursos)
          {
             foreach (var asi in cur.Asignaturas)
             {

              foreach (var alu in cur.Alumnos)
              {
                
                var rdn = new Random(System.Environment.TickCount);
                for (int i = 0; i < 5; i++)
                {
                  var eva = new Evaluación
                  { Asignatura= asi,
                    Nombre=$"{asi.Nombre}, Eva# {i + 1}",
                    Nota = (float)(5*rdn.NextDouble()),
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