using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscuelaCore.Entidades
{
    public class Asignatura
    {
        public string UniqueId {get; private set ;}

         public string Nombre { get; set; }

         public List<Evaluaciones> Evaluaciones { get; set; }

         public Asignatura()=> UniqueId=Guid.NewGuid().ToString();
    }
}