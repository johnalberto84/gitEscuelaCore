using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaCore.Entidades
{
    public class Alumno
    {
        public string UniqueId {get; private set ;}

         public string Nombre { get; set; }

         public List<Evaluación> Evaluaciones {get; set;}= new List<Evaluación>();

         public Alumno()
         {
            UniqueId = Guid.NewGuid().ToString();
            //Evaluaciones= new List<Evaluación>();
         }
    }
}