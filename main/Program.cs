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
                    byte[] src = Convert.FromBase64String(data);
                    string source = Encoding.UTF8.GetString(src);

                    Console.WriteLine(source);
                }
            }
        }
    }
}
