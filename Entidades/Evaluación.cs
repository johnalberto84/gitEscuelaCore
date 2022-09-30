using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gitEscuelaCore.Entidades;

namespace EscuelaCore.Entidades
{
    public class Evaluación:ObjetoEscuelaBase
    {
       

         public Alumno Alumno {get; set;}

         public Asignatura Asignatura{get;set;}

         public float Nota {get;set;}

        public override string ToString()
         {
                return $"{Nota},{Alumno.Nombre},{Asignatura.Nombre}";
         }

         

    }
}