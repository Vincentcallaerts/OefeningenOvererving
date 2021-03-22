using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HiddenBookmark
{
    class HiddenBookmark : Bookmark
    {
        public HiddenBookmark(string naam, string url) : base(naam, url) { }
        public override void Opensite()
        {
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe","-incognito " + Url);
        }
        public override string ToString()
        {
            return base.ToString() + "---HIDDEN---";
        }
    }
}
