using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AuthFix
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "AuthFix - @PixelCircuit";

            string RobloxDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Roblox");

            if (!Directory.Exists(RobloxDirectory))
            {
                Console.WriteLine("Failed to locate Roblox path.");
                Console.ReadKey(true);
                return;
            }

            Directory.EnumerateFiles(RobloxDirectory)
                .ToList()
                .ForEach(File.Delete);
            Directory.EnumerateDirectories(RobloxDirectory)
                .ToList()
                .ForEach(dir => {
                    Directory.Delete(dir, true);
                });

            Directory.Delete(RobloxDirectory);
            Directory.CreateDirectory(RobloxDirectory);

            Console.WriteLine("Process has completed successfully, you can now relaunch Roblox.");
            Console.ReadKey(true);
        }
    }
}