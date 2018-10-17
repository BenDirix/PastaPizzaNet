using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    class Klant
    {
        public Klant(int klantId, string naam)
        {
            KlantId = klantId;
            Naam = naam;
        }
        public int KlantId { get; set; }
        public string Naam { get; set; }

        public string WegSchrijven()
        {
            var tekst = new StringBuilder();
            tekst.Append(KlantId + "#");
            tekst.Append(Naam);            

            return tekst.ToString();
        }

        public override string ToString()
        {
            return $"{KlantId}. {Naam}";
        }
    }
}
