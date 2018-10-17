using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    abstract class Gerecht :IBedrag
    {
        public Gerecht(string naam, decimal prijs)
        {
            Naam = naam;
            Prijs = prijs;
        }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }

        public decimal BerekenBedrag()
        {
            return Prijs;
        }

        public virtual string WegSchrijven()
        {
            var tekst = new StringBuilder();
            tekst.Append(Naam + "#");
            tekst.Append(Prijs + "#");
            return tekst.ToString();
        }

        public override string ToString()
        {
            return $"{Naam} <{Prijs} eur> ";
        }
    }
}
