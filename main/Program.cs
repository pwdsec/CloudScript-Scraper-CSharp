using System;
using System.Net;
using System.Text;

namespace CloudScriptScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true){

                Console.Write("[Code]: ");
                string code = Console.ReadLine();

                using (var client = new WebClient()){
                    var data = client.DownloadString($"http://lynx.rip/dashboard/home/cloudscripts/storage/{code}_src.lua");

                    Console.WriteLine(Encoding.UTF8.GetString(Convert.FromBase64String(data)));
                }
                
            }
        }
    }
}
