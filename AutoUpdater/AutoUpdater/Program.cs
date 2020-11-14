using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.CodeDom;
using System.Collections;
using System.Text;

namespace AutoUpdater
{
    class Program
    {
        static string[] files = new string[] {
            // Down below, paste the link for your application (WARNING: IT HAS TO BE IN A WINRAR)
            "https://simplifiedstuff.000webhostapp.com/example%20stuff/example.rar"
        };

        static void Main(string[] args)
        {
            if (!Directory.Exists(Environment.CurrentDirectory + "/appname"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "/appname");
            }
            Console.Title = "Bootstrapper";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[+] Auto-Closing appname...");

            foreach (Process process in Process.GetProcessesByName("appname"))
            {
                process.Kill();
            }

            Console.WriteLine("[/] Downloading...");
            foreach (string file in files)
            {
                Console.WriteLine("[/] Reading Files...");
                string name = file.Substring(file.LastIndexOf("/") + 1);
                Console.WriteLine("[/] Downloading Functions...");
                try
                {
                    Console.WriteLine("[/] Creating Files...");
                    new WebClient().DownloadFile(new Uri(file), Environment.CurrentDirectory + "/appname/" + name);
                }
                catch (IOException ex)
                {

                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[+] Downloaded!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[TIP] Launch AutoUpdater recently to get latest version.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
            Environment.Exit(0);
            Console.Read();
        }
    }
}