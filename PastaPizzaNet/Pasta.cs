using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    class Pasta : Gerecht
    {
        public Pasta(string naam, decimal prijs, string omschrijving = null) : base(naam, prijs)
        {
            Omschrijving = omschrijving;
        }
        public string Omschrijving { get; set; }

        public override string WegSchrijven()
        {
            var tekst = new StringBuilder();
            tekst.Append("pasta#");
            tekst.Append(base.WegSchrijven());

            if(Omschrijving != null)
                tekst.Append(Omschrijving);

            return tekst.ToString();
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append(base.ToString());

            if (Omschrijving != null)
                str.Append(Omschrijving);

            return str.ToString();
        }
    }
}
