using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    class Dessert :IBedrag
    {
        public Dessert(Enum.Dessert naam)
        {
            Naam = naam;
        }
        private List<Enum.Dessert> desserten = new List<Enum.Dessert> { Enum.Dessert.Cake, Enum.Dessert.Ijs, Enum.Dessert.Tiramisu };
        private Enum.Dessert naamValue;
        public Enum.Dessert Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                if (!desserten.Contains(value))
                    throw new Exception("Dit dessert bestaat niet. Kies uit Cake, Ijs of Tiramisu");
                naamValue = value;
            }
        }

        public decimal BerekenBedrag()
        {
            decimal prijs = 0m;
            switch (Naam)
            {
                case Enum.Dessert.Cake:
                    prijs = 2.00m;
                    break;
                case Enum.Dessert.Ijs:
                case Enum.Dessert.Tiramisu:
                    prijs = 3.00m;
                    break;
            }
            return prijs;
        }

        public string WegSchrijven()
        {
            return Naam.ToString();
        }

        public override string ToString()
        {
            return $"{Naam} <{BerekenBedrag()} eur>";
        }
    }
}
