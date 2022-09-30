using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gitEscuelaCore.Entidades
{
    //abstrac que solamente puede heredar no se pueden crear instancias de la clase
    public  class ObjetoEscuelaBase
    {
         public string UniqueId {get; private set ;}

         public string Nombre { get; set; }

         public ObjetoEscuelaBase()
         {
            UniqueId = Guid.NewGuid().ToString();
         }

        public override string ToString()
        {
            return $"{Nombre},{UniqueId}";
        }
    }
}