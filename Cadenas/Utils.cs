using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadenas
{
    internal static class Utils
    {
        internal static bool IsFortyCharactersLong(string s)
        {
            return s.Length > 39;
        }
        internal static string ReplaceFrom(string input, string replaceInput)
        {
            string[] words = replaceInput.Split(new char[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return input.Replace(words[0], words[1]);
        }
        internal static string Find(string input, string search)
        {
            int index = input.IndexOf(search);
            if (index != -1 && search != "")
            {
                return $"En el índice {index} de la cadena introducida hay una coincidencia: \"{input.Substring(index)}\".";
            }
            else
            {
                return "No hay coincidencias.";
            }
        }
        internal static string StartWith(string input, string search)
        {
            if (search != "" && input.StartsWith(search))
            {
                return $"La cadena proporcionada empieza por \"{search}\".";
            }
            else
            {
                return $"No hay coincidencias.";
            }
        }
        internal static string ZeroFill(string input)
        {
            if (int.TryParse(input, out int n))
            {
                return n.ToString().PadLeft(12, '0');
            }
            else
            {
                return "Esta operación solo está disponible para números enteros.";
            }
        }
    }
}
