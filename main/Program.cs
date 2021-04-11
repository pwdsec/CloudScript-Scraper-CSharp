using System;
using System.Net;
using System.Text;
using System.IO;

/*
*   Private as of: 4/5/2021
*   Made by pwd0kernel - pwdsec
*   Desc: It gets the Lua Script in Base64 Decode it and then show the source. You can also bruteforce it.
*   Organization: https://github.com/pwdsec
*   C++ Version [not updated]: https://github.com/pwdsec/CloudScript-Scraper
*   Lynx Cloudscripts: https://lynx.rip/dashboard/home/cloudscripts/storage/
*   You can also buy Lynx here: https://lynx.rip/purchase/
*
*   Last edited: 4/10/2021 
*   ChangeLogs:
*       [4/10/2021] - added some codes and formated.
*       [4/9/2021] - Formated the code.
*       [4/9/2021] - Changed a bit the stuff.
*       [4/9/2021] - Shitty {Not Found} handler.
*       [4/9/2021] - Made it work with { cloudscript(0000000)() } it will just remove cloudscript()() and keep the int
*       [x/x/xxxx] - Bruteforce.
*       [x/x/xxxx] - cloudscript scrapper.
*       [x/x/xxxx] - Start of the project. 
*
*   Commands: 
*       bute (tries to brute force accounts).
*       help (explains how to use etc).
*       exit (closes the app)
*/

namespace CloudScriptScraper
{
    class Program
    {
        static void BruceForce(int num)
        {
            /*this can take forever, so just go here: https://lynx.rip/dashboard/home/cloudscripts/storage/
            you can also use threading so it goes way faster lol, i juts didn't do it (maybe later?)*/
            for (int i = 1; i <= num; i = i + 1) // original [num]{1000000}
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        var data = client.DownloadString($"http://lynx.rip/dashboard/home/cloudscripts/storage/{i}_src.lua");
                        if (!data.Contains("Not Found")) { Console.WriteLine(i); }
                    }
                }
                catch (Exception) { Console.WriteLine($"Error: {i}"); }
            }
        }

        static string replace_cs(string data)
        {
            if (data.Contains("cloudscript"))
            {
                data = data.Replace("cloudscript", "");
                data = data.Replace("(", "");
                data = data.Replace(")", "");
                return data;
            }
            else
            {
                return data;
            }
        }

        /*
        *   [Commands]:
        *       bute (tries to brute force accounts).
        *       help (explains how to use etc).
        *       exit (closes the app).
        */

        static void Main()
        {
            Console.WriteLine("Commands: \n brute - BruteForce Scripts\n    help - [show how to use etc]\n  exit - closes the app");
            if (!Directory.Exists("Scripts"))
            {
                Directory.CreateDirectory("Scripts");
                Console.WriteLine("\"Scripts\" Folder created.");
            }

            while (true)
            {
                Console.Write("[Code/Cloudscript]: ");
                string code = Console.ReadLine();

                // there are alternative ways of doing replace
                code = replace_cs(code);

                if (code == "brute") // low-key useless
                {
                    Console.Write("[Number]: ");
                    BruceForce(int.Parse(Console.ReadLine())); // original [num]{1000000}
                }
                else if (code == "help")
                {
                    Console.WriteLine("Go on lynx cloudscript page and copy a script.\nThen paste it here and it will show the full script.");
                }
                else if (code == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    using (var client = new WebClient())
                    {
                        var data = client.DownloadString($"http://lynx.rip/dashboard/home/cloudscripts/storage/{code}_src.lua");
                        if (!data.Contains("Not Found")) // shity detector
                        {
                            Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(data)));
                            File.WriteAllText($"Scripts\\{code}_src.lua", Encoding.UTF8.GetString(Convert.FromBase64String(data)));
                            Console.WriteLine($"CloudScript Code: cloudscript({code})()");
                        }
                        else { Console.WriteLine("This script does not exists"); }
                    }
                }
            }
        }
    }
}