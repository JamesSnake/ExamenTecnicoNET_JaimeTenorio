using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTecnicoPrimeraParte
{
    public class CompleteRange
    {
        public int[] build(int[] Parametro)
        {
            int[] Resultado = new int[] { };
            int IndiceMaximo = 0;
            IndiceMaximo = Parametro.Max();

            Resultado = Enumerable.Range(1, IndiceMaximo).ToArray();

            return Resultado; 
        }
    }
}
