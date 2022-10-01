using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gitEscuelaCore.Entidades
{
    public interface ILugar
    {
        string Direccion { get; set; }

        void LimpiarLugar();
    }
}