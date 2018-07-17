using System;

namespace PubSubClientCore.Model
{
    public class AwsSubscriber : Subscriber
    {
        public AwsSubscriber(ConfigurationFile configurationFile) : base(configurationFile)
        {
        }

        public override void SetupMessageQueue()
        {
        }
    }
}