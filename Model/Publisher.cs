using System;

namespace PubSubClientCore.Model
{
    public class Publisher : NodeBase
    {
        public Publisher(ConfigurationFile configurationFile) : base(configurationFile)
        {
        }

        public override void SetupNode(int nodeNumber)
        {
            // TODO: Send some random data here,
        }
    }
}