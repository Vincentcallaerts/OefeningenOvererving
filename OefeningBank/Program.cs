using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OefeningBank
{
    class Program
    {
        static void Main(string[] args)
        {
            BankDirecteur kbc = new BankDirecteur();
            DebitRekening debit = new DebitRekening("SpaarRekening");
            kbc.AddRekening(debit);

            bool running = true;
            int index = 0;
            double bedragOverschrijving = 0;
            
            


            while (running)
            {
                switch (SelectMenu("BankApp","Overzicht Rekeningen", "Overschrijven naar Rekening", "Rekening Verwijderen","Niewe Rekening","Stop"))
                {
                    case 0:
                        kbc.OverzichtRekeningen();                     
                        break;
                    case 1:
                        
                        index = SelectMenu("Selecteer een rekening voor van over te schrijven", kbc.ZonderSpaarRekening());
                        Console.Write("Hoeveel wilt u overschrijven: ");
                        bedragOverschrijving = Convert.ToDouble(Console.ReadLine());

                        switch (SelectMenu("Naar welke rekening wil je overschrijven ", "Rekening bij onze bank", "Rekening andere bank"))
                        {
                            case 0:
                                kbc.Overschrijven(kbc.Klanten[index], kbc.Klanten[SelectMenu("Kies een rekening", kbc.Klanten)].RekeningNummer, bedragOverschrijving);
                                break;
                            case 1:
                                Console.Write("Vul het corecte rekeningnummer in: ");
                                kbc.Overschrijven(kbc.Klanten[index], Console.ReadLine(), bedragOverschrijving);
                                break;
                           
                        }
                        break;

                    case 2:
                        kbc.VerwijderRekening(kbc.Klanten[SelectMenu("Kies een rekening", kbc.Klanten)].RekeningNummer);
                        break;

                    case 3:
                        switch (SelectMenu("Welke soort rekening wil je aanmaken ", "Debit", "Credit", "SpaarRekening"))
                        {
                            case 0:
                                Console.Write("Hoeveel wil je al direct op je rekening storten\nals je dit liever niet direct doet geef dan 0 in: ");
                                DebitRekening tempDebit = new DebitRekening("");
                                bedragOverschrijving = Convert.ToDouble(Console.ReadLine());
                                tempDebit.Bedrag = bedragOverschrijving;
                                kbc.AddRekening(tempDebit);
                                break;
                            case 1:

                                Console.Write("Hoeveel wil je al direct op je rekening storten\nals je dit liever niet direct doet geef dan 0 in: ");
                                CreditRekening tempCredit = new CreditRekening("");
                                bedragOverschrijving = Convert.ToDouble(Console.ReadLine());
                                tempCredit.Bedrag = bedragOverschrijving;
                                kbc.AddRekening(tempCredit);
                                break;
                            case 2:

                                Console.Write("Hoeveel wil je al direct op je rekening storten\nals je dit liever niet direct doet geef dan 0 in: ");
                                SpaarRekening tempSpaar = new SpaarRekening("");
                                bedragOverschrijving = Convert.ToDouble(Console.ReadLine());
                                tempSpaar.Bedrag = bedragOverschrijving;
                                kbc.AddRekening(tempSpaar);
                                break;
                        }
                        
                        
                        break;
                    case 4:
                        running = false;
                        break;
                    default:
                        break;
                }
            }

            kbc.OverzichtRekeningen();
            Console.ReadLine();
        }

        static int SelectMenu(string message,params string[] menu)
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            Console.Clear();

            int selection = 1;
            bool selected = false;
            ConsoleColor selectionForeground = Console.BackgroundColor;
            ConsoleColor selectionBackground = Console.ForegroundColor;

            while (!selected)
            {
                Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.CursorTop);
                Console.WriteLine(message);
                for (int i = 0; i < menu.Length; i++)
                {
                    if (selection == i + 1)
                    {
                        Console.ForegroundColor = selectionForeground;
                        Console.BackgroundColor = selectionBackground;
                    }
                    Console.SetCursorPosition((Console.WindowWidth - menu[i].Length) / 2, Console.CursorTop);
                    Console.WriteLine((i + 1 + ": " + menu[i]));
                    Console.ResetColor();
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selection--;
                        break;
                    case ConsoleKey.DownArrow:
                        selection++;
                        break;
                    case ConsoleKey.Enter:
                        selected = true;
                        break;
                }

                selection = Math.Min(Math.Max(selection, 1), menu.Length);
                Console.SetCursorPosition(0, 0);
            }

            Console.Clear();
            Console.CursorVisible = true;

            return selection - 1;
        }
        static int SelectMenu(string message, List<Rekening> rekeningenBank)
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            Console.Clear();

            int selection = 1;
            bool selected = false;
            ConsoleColor selectionForeground = Console.BackgroundColor;
            ConsoleColor selectionBackground = Console.ForegroundColor;

            while (!selected)
            {
                Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.CursorTop);
                Console.WriteLine(message);
                for (int i = 0; i < rekeningenBank.Count; i++)
                {
                    if (selection == i + 1)
                    {
                        Console.ForegroundColor = selectionForeground;
                        Console.BackgroundColor = selectionBackground;
                    }
                    
                    Console.SetCursorPosition((Console.WindowWidth - rekeningenBank[i].RekeningNummer.Length) / 2, Console.CursorTop);
                    Console.WriteLine((i + 1 + ": " + rekeningenBank[i].RekeningNummer));
                    Console.ResetColor();
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selection--;
                        break;
                    case ConsoleKey.DownArrow:
                        selection++;
                        break;
                    case ConsoleKey.Enter:
                        selected = true;
                        break;
                }

                selection = Math.Min(Math.Max(selection, 1), rekeningenBank.Count+1);
                Console.SetCursorPosition(0, 0);
            }

            Console.Clear();
            Console.CursorVisible = true;

            return selection - 1;
        }
    }
}
