﻿using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PubSubClientCore.Model;

namespace PubSubClientCore
{
    class Program
    {
        static Subscriber _subscriber;
        static Publisher _publisher;

        static void Main(string[] args)
        {
            // if (args.Length == 0)
            // {
            //     Console.WriteLine("Please provide configuration file in command line arguments,");
            //     return;
            // }
            //var fileName = args[0];
            var fileName = "CreateSubscribers.json";
            var fileText = File.ReadAllText(fileName);
            var configurationFile = JsonConvert.DeserializeObject<ConfigurationFile>(fileText);
            Console.WriteLine($"Provider: {configurationFile.ProviderType}");
            Console.WriteLine($"Application Mode: {configurationFile.ApplicationMode}");

            MainAsync(configurationFile).GetAwaiter().GetResult();
        }

        static async Task MainAsync(ConfigurationFile configurationFile)
        {
            if (configurationFile.ApplicationMode == ApplicationMode.Publisher)
            {
                _publisher = new Publisher(configurationFile);
                _publisher.Setup();
            }
            else if (configurationFile.ApplicationMode == ApplicationMode.Subscriber)
            {
                if (configurationFile.ProviderType == ProviderType.Azure)
                    _subscriber = new AzureSubscriber(configurationFile);
                else
                    _subscriber = new AwsSubscriber(configurationFile);
                _subscriber.Setup();
            }
            Console.Read();
        }
    }
}
