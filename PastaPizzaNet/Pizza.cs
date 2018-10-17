using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    class Pizza : Gerecht
    {
        public Pizza(string naam, decimal prijs, List<string> onderdelen):base(naam, prijs)
        {
            Onderdelen = onderdelen;
        }
        public List<string> Onderdelen { get; set; }

        public override string WegSchrijven()
        {
            var tekst = new StringBuilder();
            tekst.Append("pizza#");
            tekst.Append(base.WegSchrijven());
            var last = Onderdelen.Last();
            foreach(var onderdeel in Onderdelen)
            {
                if (onderdeel != last)
                    tekst.Append(onderdeel + "#");
                else
                    tekst.Append(onderdeel);
            }
            return tekst.ToString();
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append(base.ToString());
            var last = Onderdelen.Last();

            foreach(var onderdeel in Onderdelen)
            {
                str.Append(onderdeel);
                if (!onderdeel.Equals(last))
                {
                    str.Append(" - ");
                }
            }

            return str.ToString();
        }
    }
}
