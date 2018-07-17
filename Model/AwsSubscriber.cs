using System;
using PubSubClientCore.Responses;

namespace PubSubClientCore.Model
{
    public class AwsSubscriber : SubscriberBase
    {

        public AwsSubscriber(SubscriberMetadata subscriberMetadata) : base(subscriberMetadata)
        {
        }

        public override void Setup()
        {
        }
    }
}