using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningenOvererving
{
    class Patient
    {
        public string Naam { get; set; }
        public int AantalUur { get; set; }

        public virtual double BerekenKost()
        {
            return 50 + 20 * AantalUur;
        }
        public void ToonInfo()
        {
            Console.WriteLine($"{Naam} is {AantalUur} uur opgenomen en moet {BerekenKost()} betalen");
        }
    }
}
