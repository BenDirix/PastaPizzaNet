using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enum;

namespace PastaPizzaNet
{
    
    abstract class Drank : IBedrag
    {
        public Drank(Enum.Drank naam)
        {
            Naam = naam;            
        }
        public abstract Enum.Drank Naam { get; set; }
        public abstract decimal Prijs { get; set; }

        public decimal BerekenBedrag()
        {
            return Prijs;
        }

        public virtual string WegSchrijven()
        {
            return Naam.ToString();
        }

        public override string ToString()
        {
            return $"{Naam} <{Prijs} eur>";
        }
    }
}
