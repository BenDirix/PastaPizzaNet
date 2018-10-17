using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum;

namespace PastaPizzaNet
{
    class Warmedrank : Drank
    {
        private List<Enum.Drank> warmedranken = new List<Enum.Drank> { Enum.Drank.Koffie, Enum.Drank.Thee };
        public Warmedrank(Enum.Drank naam):base(naam)
        {
            Prijs = 2.50m;
        }

        private Enum.Drank naamValue;
        public override Enum.Drank Naam
        {
            get
            {
                return naamValue;
            }
            set
            {
                if (!warmedranken.Contains(value))
                    throw new Exception("Geen warme drank. Kies uit Koffie of Thee");
                naamValue = value;
            }
        }
        public override decimal Prijs { get; set; }

        public override string WegSchrijven()
        {         
            return "W-" + base.WegSchrijven();
        }
    }
}
