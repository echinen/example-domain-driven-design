using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExampleDDDArchitecture.Infra.CrossCutting
{
    public static class Helper
    {
        public static string ExtrairNumeros(string texto)
        {
            Regex regex = new Regex("[0-9]");
            StringBuilder sb = new StringBuilder();

            foreach (Match m in regex.Matches(texto))
            {
                sb.Append(m.Value);
            }

            return sb.ToString();
        }
    }
}
