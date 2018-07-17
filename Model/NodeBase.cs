using System;
using Newtonsoft.Json;
using PubSubClientCore.Responses;

namespace PubSubClientCore.Model
{
    public abstract class NodeBase<T>
    {
        public NodeBase(ConfigurationFile configurationFile)
        {
            ConfigurationFile = configurationFile;
        }

        protected ConfigurationFile ConfigurationFile { get; private set; }

        protected int NodesCount => ConfigurationFile.NodesCount;

        private T[] _nodes;
        protected T[] Nodes => _nodes ?? (_nodes = new T[ConfigurationFile.NodesCount]);

        public void Setup()
        {
            for (var i = 0; i < ConfigurationFile.NodesCount; i++)
                SetupNode(i);
        }

        public abstract void SetupNode(int nodeNumber);
    }
}