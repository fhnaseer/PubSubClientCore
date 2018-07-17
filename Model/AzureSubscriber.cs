using System;

namespace PubSubClientCore.Model
{
    public class AzureSubscriber : Subscriber
    {
        public AzureSubscriber(ConfigurationFile configurationFile) : base(configurationFile)
        {
        }

        public override void SetupMessageQueue()
        {
        }
    }
}