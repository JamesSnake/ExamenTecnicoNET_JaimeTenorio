using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExamenTecnicoPrimeraParte
{
    public class ChangeString
    {
        Dictionary<int, string> getAlfabeto() {
            Dictionary<int, string> alfabeto = new Dictionary<int, string>();
            alfabeto.Add(1, "a");
            alfabeto.Add(2, "b");
            alfabeto.Add(3, "c");
            alfabeto.Add(4, "d");
            alfabeto.Add(5, "e");
            alfabeto.Add(6, "f");
            alfabeto.Add(7, "g");
            alfabeto.Add(8, "h");
            alfabeto.Add(9, "i");
            alfabeto.Add(10, "j");
            alfabeto.Add(11, "k");
            alfabeto.Add(12, "l");
            alfabeto.Add(13, "m");
            alfabeto.Add(14, "n");
            alfabeto.Add(15, "ñ");
            alfabeto.Add(16, "o");
            alfabeto.Add(17, "p");
            alfabeto.Add(18, "q");
            alfabeto.Add(19, "r");
            alfabeto.Add(20, "s");
            alfabeto.Add(21, "t");
            alfabeto.Add(22, "u");
            alfabeto.Add(23, "v");
            alfabeto.Add(24, "w");
            alfabeto.Add(25, "x");
            alfabeto.Add(26, "y");
            alfabeto.Add(27, "z");
            return alfabeto;
        }

        public string build(string Parametro) {
            Dictionary<int, string> alfabeto = getAlfabeto();
            string Resultado="";
            string segmento = "";
            bool Upper = false;

            for (int i = 0; i < Parametro.Length; i++)
            {
               segmento = Parametro.Substring(i, 1);
               if (!String.IsNullOrEmpty(segmento) && Regex.IsMatch(segmento, @"^[a-zA-Z]+$")) {
                   if (Regex.IsMatch(segmento, @"^[A-Z]+$")) { Upper = true; } else { Upper = false; }
                   var letras = Upper ? alfabeto.Where(e => segmento.Contains(e.Value.ToUpper())) : alfabeto.Where(e => segmento.Contains(e.Value));
                   if (letras.Any())
                   {
                       if (Upper)
                       {
                           segmento = alfabeto[letras.First().Key + (alfabeto.Count == letras.First().Key ? 0 : 1)].ToUpper();
                       }
                       else
                       {
                           segmento = alfabeto[letras.First().Key + (alfabeto.Count == letras.First().Key ? 0 : 1)];
                       }
                   }
               }
               Resultado = Resultado + segmento;
            }
            return Resultado;
        }
    }
}
