using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace PubSubClientCore.Model
{
    public class AzureSubscriberManager : SubscriberManagerBase
    {
        public AzureSubscriberManager(ConfigurationFile configurationFile) : base(configurationFile)
        {
        }

        private AzureSubscriber[] _subscribers;
        public AzureSubscriber[] Subscribers => _subscribers ?? (_subscribers = new AzureSubscriber[ConfigurationFile.NodesCount]);

        public override void SetupMessageQueue(int subscriberNumber)
        {
            Subscribers[subscriberNumber] = new AzureSubscriber(Nodes[subscriberNumber]);
            Subscribers[subscriberNumber].Setup();
        }
    }
}