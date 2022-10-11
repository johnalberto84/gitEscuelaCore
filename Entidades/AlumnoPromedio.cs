using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscuelaCore.Entidades;

namespace gitEscuelaCore.Entidades
{
    public class AlumnoPromedio
    {
        public float AlumnoPromedio;

        public string Nombre { get; set; }

        public Alumno Alumno{get;set;}

    }
}