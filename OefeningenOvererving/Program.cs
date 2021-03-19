using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningenOvererving
{
    class Program
    {
        static void Main(string[] args)
        {
            VerzekerdePatient patient = new VerzekerdePatient();
            patient.Naam = "vincent";
            patient.AantalUur = 20;
            patient.ToonInfo();
            Console.ReadLine();
        }
    }
}
