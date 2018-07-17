using System;
using Newtonsoft.Json;
using PubSubClientCore.Responses;

namespace PubSubClientCore.Model
{
    public class Subscriber : NodeBase<SubscribeResponse>
    {
        public Subscriber(ConfigurationFile configurationFile)
        : base(configurationFile)
        {
        }

        public override async void SetupNode(int nodeNumber)
        {
            var response = await HttpRestClient.Get(ConfigurationFile.BaseUrl + "/api/Subscribe");
            Nodes[nodeNumber] = JsonConvert.DeserializeObject<SubscribeResponse>(response);
            Console.WriteLine($"Subscriber {nodeNumber} created. Queue Name: {Nodes[nodeNumber].QueueName}");
        }
    }
}