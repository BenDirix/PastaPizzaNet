using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaPizzaNet
{
    class Frisdrank : Drank
    {
        public Frisdrank(Enum.Drank naam):base(naam)
        {
            Prijs = 2.00m;
        }
        private List<Enum.Drank> frisdranken = new List<Enum.Drank> { Enum.Drank.Water, Enum.Drank.Limonade, Enum.Drank.CocaCola };
       
        private Enum.Drank naamValue;
        public override Enum.Drank Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                if (!frisdranken.Contains(value))
                    throw new Exception("Geen frisdrank. Kies uit Water, Coca Cola of Limonade");
                naamValue = value;
            }
        }

        public override string WegSchrijven()
        {
            return "F-" + base.WegSchrijven();
        }

        public override  decimal Prijs { get; set; }

    }
}
