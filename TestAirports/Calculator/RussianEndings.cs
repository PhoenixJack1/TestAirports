using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TestAirports.Calculator
{
    public class RussianEndings:IRussianEndings
    {
        public string GetEndingMiles(int value)
        {
            string text = value.ToString();
            if (text.Length == 1)
            {
                switch (text[0])
                {
                    case '1': return "миля";
                    case '2':
                    case '3':
                    case '4': return "мили";
                    default: return "миль";
                }
            }
            else if (text.Length > 1)
            {
                string end = text.Substring(text.Length - 2);
                char last = end[1];
                switch (last)
                {
                    case '1': return end == "11" ? "миль" : "миля";
                    case '2': return end == "12" ? "миль" : "мили";
                    case '3': return end == "13" ? "миль" : "мили";
                    case '4': return end == "14" ? "миль" : "мили";
                    default: return "миль";
                }
            }
            else return "миль";
        }
    }
}
