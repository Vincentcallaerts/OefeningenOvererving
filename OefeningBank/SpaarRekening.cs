using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningBank
{
    class SpaarRekening : Rekening
    {
        public SpaarRekening(string type) : base("SpaarRekening") { }
        public override void Overschrijven(double getal)
        {
            Console.WriteLine("Dit is een spaarrekening neem contact op met de bank voor hier geld af te halen");
        }

    }
}
