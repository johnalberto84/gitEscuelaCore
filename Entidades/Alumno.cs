using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gitEscuelaCore.Entidades;

namespace EscuelaCore.Entidades
{
    public class Alumno: ObjetoEscuelaBase
    {
     
         public List<Evaluación> Evaluaciones {get; set;}= new List<Evaluación>();

        
    }
}