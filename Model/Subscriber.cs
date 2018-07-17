using System;
using Newtonsoft.Json;
using PubSubClientCore.Responses;

namespace PubSubClientCore.Model
{
    public abstract class Subscriber : NodeBase
    {
        protected Subscriber(ConfigurationFile configurationFile) : base(configurationFile)
        {
        }

        private SubscribeResponse[] _nodes;
        protected SubscribeResponse[] Nodes => _nodes ?? (_nodes = new SubscribeResponse[ConfigurationFile.NodesCount]);

        public override async void SetupNode(int nodeNumber)
        {
            var response = await HttpRestClient.Get(ConfigurationFile.BaseUrl + "/api/Subscribe");
            Nodes[nodeNumber] = JsonConvert.DeserializeObject<SubscribeResponse>(response);
            Console.WriteLine($"Subscriber {nodeNumber} created. Queue Name: {Nodes[nodeNumber].QueueName}");
            SetupMessageQueue();
        }

        public abstract void SetupMessageQueue();
    }
}