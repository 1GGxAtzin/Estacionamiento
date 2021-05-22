using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACTIVIDAD4
{
    public class elementos
    {
        
        public int dato;
        public string hora;
        public int costo;
        public string horas;
        public elementos(string hora, int dato, int costo, string horas)
        {
            this.dato = dato;
            this.hora = hora;
            this.horas = horas;
            this.costo = costo;
        }
    }
}
