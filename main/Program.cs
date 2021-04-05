using System;
using System.Net;
using System.Text;
using System.IO;
/*
*   Private as of: 4/5/2021
*   Made by pwd0kernel - pwdsec
*/

namespace CloudScriptScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists("Scripts"))
                Directory.CreateDirectory("Scripts");

            while (true) {
                Console.Write("[Code]: ");
                string code = Console.ReadLine();
                using (var client = new WebClient()) {
                    var data = client.DownloadString($"http://lynx.rip/dashboard/home/cloudscripts/storage/{code}_src.lua");
                    
                    Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(data)));
                    File.WriteAllText($"Scripts\\{code}_src.lua", Encoding.UTF8.GetString(Convert.FromBase64String(data)));
                    Console.WriteLine($"CloudScript Code: cloudscript({code})()");
                } 
            }
        }
    }
}
