using System;
using System.IO;
using Newtonsoft.Json;

namespace PubSubClientCore
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide configuration file in command line arguments,");
                return;
            }
            var fileName = args[0];
            var fileText = File.ReadAllText(fileName);
            var configurationFile = JsonConvert.DeserializeObject<ConfigurationFile>(fileText);
            Console.WriteLine($"Provider: {configurationFile.ProviderType}");
            Console.WriteLine($"Application Mode: {configurationFile.ApplicationMode}");
        }
    }
}
