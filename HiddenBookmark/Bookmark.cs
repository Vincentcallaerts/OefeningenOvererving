using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HiddenBookmark
{
    class Bookmark
    {
        
        public string Naam { get; set; }
        public string Url { get; set; }
        public Bookmark(string naam, string url)
        {
            Naam = naam;
            Url = url;


        }
        public virtual void Opensite()
        {
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", Url);
        }

        public override string ToString()
        {
            return $"{Naam} ({Url})";
        }
    }
}

