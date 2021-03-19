using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningBank
{
    class DebitRekening : Rekening
    {
        public DebitRekening(string type) : base("DebitRekening") { }
        public override void Overschrijven(double getal)
        {
            if (!(getal > Bedrag))
            {
                base.Overschrijven(getal);
            }
        }
    }
}
