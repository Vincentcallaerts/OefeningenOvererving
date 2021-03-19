using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningBank
{
    class CreditRekening : Rekening
    {
        public CreditRekening(string type) : base("CreditRekening") { }
        public string Achterkant { get; set; }
        public override string ToString()
        {
            return $"{RekeningNummer}({Achterkant}): Bedrag {Bedrag}";
        }
    }
}
