using System;
using Newtonsoft.Json;
using PubSubClientCore.Responses;

namespace PubSubClientCore.Model
{
    public class SubscriberManager : NodeBase
    {
        public SubscriberManager(ConfigurationFile configurationFile) : base(configurationFile)
        {
        }

        private SubscriberMetadata[] _nodes;
        public SubscriberMetadata[] Nodes => _nodes ?? (_nodes = new SubscriberMetadata[ConfigurationFile.NodesCount]);

        private SubscriberBase[] _subscribers;
        public SubscriberBase[] Subscribers => _subscribers ?? (_subscribers = new SubscriberBase[ConfigurationFile.NodesCount]);

        public override async void SetupNode(int nodeNumber)
        {
            var response = await HttpRestClient.Get(ConfigurationFile.BaseUrl + "/api/Subscribe");
            Nodes[nodeNumber] = JsonConvert.DeserializeObject<SubscriberMetadata>(response);
            Console.WriteLine($"Subscriber {nodeNumber} created. Queue Name: {Nodes[nodeNumber].QueueName}");
            if (ConfigurationFile.ProviderType == ProviderType.Azure)
                Subscribers[nodeNumber] = new AzureSubscriber(Nodes[nodeNumber]);
            else
                Subscribers[nodeNumber] = new AwsSubscriber(Nodes[nodeNumber]);
            Subscribers[nodeNumber].Setup();
        }
    }
}