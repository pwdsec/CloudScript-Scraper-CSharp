using System;
using System.Net;

namespace CloudScriptScraper
{
    public static Program {
        public static void Main(){
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
