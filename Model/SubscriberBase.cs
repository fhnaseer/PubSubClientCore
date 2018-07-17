using PubSubClientCore.Responses;

namespace PubSubClientCore.Model
{
    public abstract class SubscriberBase
    {
        public SubscriberBase(SubscriberMetadata subscriberMetadata)
        {
            SubscriberMetadata = subscriberMetadata;
        }

        public SubscriberMetadata SubscriberMetadata { get; private set; }

        public abstract void Setup();
    }
}