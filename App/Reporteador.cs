using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscuelaCore.Entidades;
using gitEscuelaCore.Entidades;

namespace gitEscuelaCore.App
{
    public  class Reporteador
    {

        Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador( Dictionary<LlavesDiccionario, IEnumerable<ObjetoEscuelaBase>> diccEsculea)
        {
            if(diccEsculea==null)
            {
                throw new  ArgumentNullException(nameof(diccEsculea));
            }
            else
            _diccionario=diccEsculea;
        }

        public IEnumerable<Evaluación> GetListaEvaluaciones()
        {
                IEnumerable<Evaluación>  rta;

                if (_diccionario.TryGetValue(LlavesDiccionario.Evaluacion , out IEnumerable<ObjetoEscuelaBase>  lista))
                {
                   return  rta=lista.Cast<Evaluación>();
                } 
                else    
                {
                     return new List<Evaluación>();
                }
                 
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
               
               return GetListaAsignaturas(out var dummy);
                 
        }

        public IEnumerable<string> GetListaAsignaturas( out  IEnumerable<Evaluación>  listaEvaluaciones)
        {
                listaEvaluaciones = GetListaEvaluaciones();

               return (from ev in listaEvaluaciones
                      select ev.Asignatura.Nombre).Distinct();
                 
        }

        public Dictionary<string , IEnumerable<Evaluación>> GetDicEvaluacionesXAsignatura()
        {
            var dicevas = new Dictionary<string, IEnumerable<Evaluación>>();

            var listaAsi = GetListaAsignaturas(out var listaEval );

            foreach (var asi in listaAsi)
            {

                var evalasi = from eval in listaEval
                             where eval.Asignatura.Nombre== asi
                            select eval ;
                dicevas.Add(asi,evalasi);
                
            }

            return dicevas;
                 
        }

         public Dictionary<string , IEnumerable<object>> GetPromedioalumnosXAsignatura()
         {
            var rta =  new Dictionary<string , IEnumerable<object>>();
            var dicEvalXAsi = GetDicEvaluacionesXAsignatura();

            foreach (var asieval in dicEvalXAsi)
            {
                var proAlumno = from  eval in asieval.Value
                            group eval by  new {eval.Alumno.UniqueId , eval.Alumno.Nombre } 
                            into grupoEvalAlumno
                            select new AlumnoPromedio
                            { 
                              alumnokey = grupoEvalAlumno.Key.UniqueId,
                              alumnonombre = grupoEvalAlumno.Key.Nombre,
                              alumnoPromedio = grupoEvalAlumno.Average(evaluacion=>evaluacion.Nota)
                            };

                rta.Add(asieval.Key,proAlumno);

            }


            return rta;

         }


        public Dictionary<string , IEnumerable<object>> GetEvaluacionesTopAsignaturas(int top)
        {
            var rta =  new Dictionary<string , IEnumerable<object>>();
             var dicEvalXAsi = GetDicEvaluacionesXAsignatura();

            foreach (var asieval in dicEvalXAsi)
            {
                var proAlumno = (from  eval in asieval.Value
                            group eval by  new {eval.Alumno.UniqueId , eval.Alumno.Nombre } 
                            into grupoEvalAlumno
                            select new AlumnoPromedio
                            { 
                              alumnokey = grupoEvalAlumno.Key.UniqueId,
                              alumnonombre = grupoEvalAlumno.Key.Nombre,
                              alumnoPromedio = grupoEvalAlumno.Average(evaluacion=>evaluacion.Nota)
                            }).OrderByDescending(r=> r.alumnoPromedio).Take(top);

                




                rta.Add(asieval.Key,proAlumno);


            }



            return rta;

        }


    }
}