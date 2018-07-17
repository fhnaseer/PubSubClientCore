using System;

namespace PubSubClientCore.Model
{
    public class AwsSubscriberManager : SubscriberManagerBase
    {
        public AwsSubscriberManager(ConfigurationFile configurationFile) : base(configurationFile)
        {
        }

        public override void SetupMessageQueue(int subscriberNumber)
        {
        }
    }
}