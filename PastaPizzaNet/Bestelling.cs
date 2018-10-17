using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    class Bestelling : IBedrag
    {
        public Bestelling(BesteldGerecht besteldgerecht = null, Drank drank = null, Dessert dessert = null, int aantal = 1, Klant klant = null)
        {
            Klant = klant;
            BesteldGerecht = besteldgerecht;
            Drank = drank;
            Dessert = dessert;
            Aantal = aantal;            
        }
        public BesteldGerecht BesteldGerecht { get; set; }
        public Drank Drank { get; set; }
        public Dessert Dessert { get; set; }
        public int Aantal { get; set; }
        private Klant klantValue;
        public Klant Klant
        {
            get
            {
                return klantValue;
            }
            set
            {
                if (value == null)
                    klantValue = new Klant(0, "Onbekende Klant");
                else
                    klantValue = value;
            }
        }

        public decimal BerekenBedrag()
        {
            var prijs = 0m;
            if(BesteldGerecht != null)
                prijs = BesteldGerecht.BerekenBedrag();
            if (Drank != null)
                prijs += Drank.BerekenBedrag();
            if (Dessert != null)
                prijs += Dessert.BerekenBedrag();

            if (BesteldGerecht != null && Drank != null && Dessert != null)
                prijs -= (prijs / 10);

            prijs *= Aantal;

            return prijs;
        }

        public string WegSchrijven()
        {
            var tekst = new StringBuilder();
            tekst.Append(Klant.KlantId + "#");
            if(BesteldGerecht!=null)
                tekst.Append(BesteldGerecht.WegSchrijven());
            tekst.Append("#");
            if (Drank != null)
                tekst.Append(Drank.WegSchrijven());
            tekst.Append("#");
            if (Dessert != null)
                tekst.Append(Dessert.WegSchrijven());
            tekst.Append("#");
            tekst.Append(Aantal);

            return tekst.ToString();
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            str.Append($"Klant: {Klant.Naam}");
            if(BesteldGerecht != null)
                str.Append(Environment.NewLine + $"Gerecht: {BesteldGerecht.ToString()}");
            if(Drank != null)
                str.Append(Environment.NewLine + $"Drank: {Drank.ToString()}");
            if(Dessert != null)
                str.Append(Environment.NewLine + $"Dessert: {Dessert.ToString()}");

            str.Append(Environment.NewLine + $"Aantal: {Aantal}");
            str.Append(Environment.NewLine + $"Bedrag van deze bestelling: {BerekenBedrag()} eur");


            return str.ToString();
        }
    }
}
