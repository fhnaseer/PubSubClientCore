using System;

namespace PubSubClientCore.Model
{
    public class PublisherManager : NodeBase
    {
        public PublisherManager(ConfigurationFile configurationFile) : base(configurationFile)
        {
        }

        public override void SetupNode(int nodeNumber)
        {
            // TODO: Send some random data here,
        }
    }
}