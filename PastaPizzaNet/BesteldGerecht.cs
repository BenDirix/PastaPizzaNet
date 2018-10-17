using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum;

namespace PastaPizzaNet
{  
    class BesteldGerecht : IBedrag
    {
        public BesteldGerecht(Gerecht gerecht, Grootte grootte = Grootte.Klein, List<Extra> extras = null)
        {
            Gerecht = gerecht;
            Grootte = grootte;
            Extras = extras;
        }

        public Gerecht Gerecht { get; set; }
        public Grootte Grootte { get; set; }
        public List<Extra> Extras { get; set; }

        public decimal BerekenBedrag()
        {
            var prijs = 0m;
            prijs += Gerecht.BerekenBedrag();
            if(Grootte == Grootte.Groot)
            {
                prijs += 3m;
            }

            if(Extras != null)
            {
                foreach (var extra in Extras)
                    prijs += 1m;
            }
            
            return prijs;
        }

        public string WegSchrijven()
        {
            var tekst = new StringBuilder();
            tekst.Append(Gerecht.Naam + "-");
            tekst.Append(Grootte + "-");
            if (Extras != null)
            {
                var last = Extras.Last();
                tekst.Append(Extras.Count + "-");
                foreach(var extra in Extras)
                {
                    if (extra != last)
                        tekst.Append(extra + "-");
                    else
                        tekst.Append(extra);
                }
            }                
            else
                tekst.Append("0");

            return tekst.ToString();
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append(Gerecht.ToString());
            str.Append($" <{Grootte}> ");
            if(Extras != null)
            {
                str.Append("extra: ");
                foreach(var extra in Extras)
                {
                    str.Append($"{extra} ");
                }
            }
            str.Append($"<bedrag: {BerekenBedrag()} eur>");

            return str.ToString();
        }
    }
}
