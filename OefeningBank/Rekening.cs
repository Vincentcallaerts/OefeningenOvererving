using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningBank
{
    class Rekening
    {
        private Random random = new Random();
        public string RekeningNummer { get; set; }
        public double Bedrag { get; set; }
        public string Type { get; set; }

        public Rekening(string type) 
        {

            RekeningNummer = NieweRekening();
            Bedrag = 10000;
            Type = type;

        }
        public void BijSchrijven(double getal)
        {
            Bedrag += getal;
        }
        public virtual void Overschrijven(double getal)
        {
            Bedrag -= getal;
        }
        public override string ToString()
        {
            
           return $"{Type} {RekeningNummer.Substring(0,4)} {RekeningNummer.Substring(5, 4)} {RekeningNummer.Substring(9, 4)} {RekeningNummer.Substring(12, 4)}: Bedrag {Bedrag}";
        }
        private string NieweRekening()
        {
            string temp = "BE";
            for (int i = 0; i < 14; i++)
            {
                temp += Convert.ToChar(random.Next(48, 57));
            }
            return temp;
        }
    }
}
