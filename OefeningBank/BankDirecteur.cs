using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningBank
{
    class BankDirecteur
    {
        public List<Rekening> Klanten { get; set; }
        public BankDirecteur()
        {
            Klanten = new List<Rekening>();
        }
        public void Overschrijven(Rekening rekening , string rekeningnummer, double bedrag)
        {

            if (BestaatRekeningNummer(rekeningnummer))
            {
                rekening.Overschrijven(bedrag);
                Klanten[IndexRekening(rekeningnummer)].BijSchrijven(bedrag);

            }
            else
            {
                rekening.Overschrijven(bedrag);
                //Geld verdwijnt gewoon is deel van de opgaven
            }
        }
        public bool BestaatRekeningNummer(string rekeningnummer)
        {
            if (HaalRekeningOp(rekeningnummer) != null)
            {
                return true;
            }
            return false;
        }
        public Rekening HaalRekeningOp(string rekeningnummer)
        {
            for (int i = 0; i < Klanten.Count; i++)
            {
                if (rekeningnummer == Klanten[i].RekeningNummer)
                {
                    return Klanten[i];
                }
            }
            return null;
        }
        public int IndexRekening(string rekeningnummer)
        {
            for (int i = 0; i < Klanten.Count; i++)
            {
                if (rekeningnummer == Klanten[i].RekeningNummer)
                {
                    return i;
                }
            }
            return -1;
        }
        public void VerwijderRekening(string rekeningnummer)
        {
            if (BestaatRekeningNummer(rekeningnummer))
            {
                if (HaalRekeningOp(rekeningnummer).Bedrag == 0)
                {
                    Klanten.RemoveAt(IndexRekening(rekeningnummer));
                }
                else
                {
                    Console.WriteLine("Het bedrag op de rekening is niet 0 en mag dus niet gesloten worden");
                    Console.ReadLine();
                }             
            }
            else
            {
                Console.WriteLine("Dat is geen bestaand rekeningnummer");
                Console.ReadLine();
            }
        }
        public  void AddRekening(Rekening rekening)
        {
            Klanten.Add(rekening);
        }
        public void OverzichtRekeningen()
        {
            for (int i = 0; i < Klanten.Count; i++)
            {
                Console.WriteLine(Klanten[i].ToString()); ;
            }
            Console.ReadLine();
        }
        public List<Rekening> ZonderSpaarRekening()
        {
            List<Rekening> temp = new List<Rekening>();
            for (int i = 0; i < Klanten.Count; i++)
            {
                if (Klanten[i].Type != "SpaarRekening")
                {
                    temp.Add(Klanten[i]);
                }
            }
            return temp;
        }
        public void SortList() 
        {

            List<Rekening> temp = new List<Rekening>();

            for (int i = 0; i < Klanten.Count; i++)
            {
                if (Klanten[i].Type == "SpaarRekening")
                {
                    temp.Add(Klanten[i]);
                    Klanten.RemoveAt(i);
                }
            }
            for (int i = 0; i < temp.Count; i++)
            {
                Klanten.Add(temp[i]);
            }
        }
    }
}
