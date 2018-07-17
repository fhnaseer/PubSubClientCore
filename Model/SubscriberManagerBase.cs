using System;
using Newtonsoft.Json;
using PubSubClientCore.Responses;

namespace PubSubClientCore.Model
{
    public abstract class SubscriberManagerBase : NodeBase
    {
        protected SubscriberManagerBase(ConfigurationFile configurationFile) : base(configurationFile)
        {
        }

        private SubscriberMetadata[] _nodes;
        protected SubscriberMetadata[] Nodes => _nodes ?? (_nodes = new SubscriberMetadata[ConfigurationFile.NodesCount]);

        public override async void SetupNode(int nodeNumber)
        {
            var response = await HttpRestClient.Get(ConfigurationFile.BaseUrl + "/api/Subscribe");
            Nodes[nodeNumber] = JsonConvert.DeserializeObject<SubscriberMetadata>(response);
            Console.WriteLine($"Subscriber {nodeNumber} created. Queue Name: {Nodes[nodeNumber].QueueName}");
            SetupMessageQueue(nodeNumber);
        }

        public abstract void SetupMessageQueue(int subscriberNumber);
    }
}