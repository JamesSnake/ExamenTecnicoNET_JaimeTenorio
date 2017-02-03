using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTecnicoPrimeraParte
{
    public class MoneyParts
    {

        public object[] build(string Parametro)
        {
            decimal Monto = 0;
            object[] Resultado = new object[] { };
            List<decimal> Denominaciones = getDenominaciones();
            decimal.TryParse(Parametro, out Monto);
            Resultado = GenerarCombinaciones(Denominaciones, Monto);
            return Resultado;
        }

        private List<decimal> getDenominaciones() {
            List<decimal> Denominaciones = new List<decimal>();
            Denominaciones = new List<decimal>() { decimal.Parse("0.05"), decimal.Parse("0.1"), decimal.Parse("0.2"), decimal.Parse("0.5"), 1, 2, 5, 10, 20, 50, 100, 200 };
            return Denominaciones;
        }

        private static object[] GenerarCombinaciones(List<decimal> Denominadores, decimal Monto)
        {
            object[] Almacenador = new object[]{} ;
            List<object> ListaAcumulador = new List<object>();
            CombinadorSumaRecursiva(Denominadores, Monto, new List<decimal>(), ref ListaAcumulador);
            Almacenador = ListaAcumulador.ToArray();
            return Almacenador;
        }

        private static void CombinadorSumaRecursiva(List<decimal> Denominadores, decimal Monto, List<decimal> ListaParcial, ref List<object> Almacenador)
        {
            List<decimal> ListaParcialReferencia;
            decimal Denominador = 0;
            decimal Suma = 0;

            foreach (decimal Elemento in ListaParcial) { Suma += Elemento; }

            if (Suma == Monto){Almacenador.Add(ListaParcial.ToArray());}

            if (Suma >= Monto){return;}

            for (int i = 0; i < Denominadores.Count; i++)
            {
                Denominador = Denominadores[i];
                ListaParcialReferencia = new List<decimal>(ListaParcial);
                ListaParcialReferencia.Add(Denominador);
                CombinadorSumaRecursiva(Denominadores, Monto, ListaParcialReferencia, ref Almacenador);
            }
        }


    }
}
