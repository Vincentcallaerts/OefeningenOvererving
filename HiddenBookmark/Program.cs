using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenBookmark
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            Bookmark[] topFive = new Bookmark[5];
            Bookmark google = new Bookmark("Google ", "www.google.com");
            Bookmark youtube = new Bookmark("Youtube ", "www.youtube.com");
            Bookmark facebook = new Bookmark("Facebook ", "www.facebook.com");
            Bookmark reddit = new Bookmark("Reddit ", "www.reddit.com");
            HiddenBookmark github = new HiddenBookmark("Github ", "www.github.com");

            topFive[0] = google;
            topFive[1] = youtube;
            topFive[2] = facebook;
            topFive[3] = reddit;
            topFive[4] = github;

            while (running)
            {

                int index = 0;
                switch (SelectMenu("Bekijk top 5 bookmarks", "Bookmarks aanpassen", "Bookmarks verwijderen", "Stop"))
                {

                    case 0:
                        switch (SelectMenu(BookmarkZonderNull(topFive), "Top Five"))
                        {
                            case 0:
                                topFive[0].Opensite();
                                break;
                            case 1:
                                topFive[1].Opensite();
                                break;
                            case 2:
                                topFive[2].Opensite();
                                break;
                            case 3:
                                topFive[3].Opensite();
                                break;
                            case 4:
                                topFive[4].Opensite();
                                break;
                        }
                        break;
                    case 1:

                        index = SelectMenu(topFive, "Welke Bookmark wil je aanpassen");
                        Console.Write("Geef de naam van de bookmark in: ");
                        string naam = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write("Geef de url van de bookmark in: ");
                        string url = Console.ReadLine();
                        Console.WriteLine();

                        topFive = AanpassenBookmark(topFive, index, naam, url);

                        break;

                    case 2:

                        index = SelectMenu(BookmarkZonderNull(topFive), "Bookmark Leegmaken");
                        topFive = VerwijderBookmark(topFive, index);
                        Console.WriteLine($"We hebben index {index} leeg gemaakt ");
                        Console.ReadKey();

                        break;
                    case 3:
                        running = false;
                        break;
                }
            }

            Console.ReadLine();

        }
        static int SelectMenu(Bookmark[] topFive, string title)
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

                Console.WriteLine();
                Console.WriteLine();
                Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);

                Console.WriteLine(title);


                for (int i = 0; i < topFive.Length; i++)
                {
                    if (true)
                    {
                        if (selection == i + 1)
                        {
                            Console.ForegroundColor = selectionForeground;
                            Console.BackgroundColor = selectionBackground;
                        }
                        if (topFive[i] == null)
                        {
                            string altmsg = $"{i + 1}. Leeg";
                            Console.SetCursorPosition((Console.WindowWidth - altmsg.Length) / 2, Console.CursorTop);
                            Console.WriteLine(altmsg);
                            Console.ResetColor();
                        }
                        else
                        {
                            string msg = $"{i + 1}. {topFive[i].Naam}";
                            Console.SetCursorPosition((Console.WindowWidth - msg.Length) / 2, Console.CursorTop);
                            Console.WriteLine(msg);
                            Console.ResetColor();
                        }
                    }
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

                selection = Math.Min(Math.Max(selection, 1), topFive.Length);
                Console.SetCursorPosition(0, 0);
            }

            Console.Clear();
            Console.CursorVisible = true;

            return selection - 1;
        }
        static int SelectMenu(params string[] menu)
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
        static Bookmark[] VerwijderBookmark(Bookmark[] bookmarks, int index)
        {
            Bookmark[] temp = new Bookmark[5];
            for (int i = 0; i < bookmarks.Length; i++)
            {
                if (i != index)
                {
                    temp[i] = bookmarks[i];
                }
                else
                {
                    temp[i] = null;

                }
            }
            for (int i = 0; i < temp.Length; i++)
            {

                if (temp[i] == null)
                {
                    if (temp.Length != (i + 1))
                    {
                        temp[i] = temp[i + 1];
                        temp[i + 1] = null;
                    }
                    else
                    {
                        temp[i] = null;
                    }

                }
            }

            return temp;
        }
        static Bookmark[] AanpassenBookmark(Bookmark[] bookmarks, int index, string naam, string url)
        {
            Bookmark[] temp = new Bookmark[5];
            for (int i = 0; i < bookmarks.Length; i++)
            {
                if (i != index)
                {
                    temp[i] = bookmarks[i];
                }
                else
                {
                    temp[i] = new Bookmark(naam, url);

                }
            }

            return temp;
        }
        static Bookmark[] BookmarkZonderNull(Bookmark[] bookmarks)
        {
            int counter = 5;

            for (int i = 0; i < bookmarks.Length; i++)
            {
                if (bookmarks[i] == null)
                {
                    counter--;
                }

            }

            Bookmark[] temp = new Bookmark[counter];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = bookmarks[i];
            }
            return temp;
        }
    }
}
