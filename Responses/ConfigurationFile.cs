using System;
using Newtonsoft.Json;

namespace PubSubClientCore
{
    public enum ProviderType
    {
        Azure,
        Aws
    }

    public enum ApplicationMode
    {
        Subscriber,
        Publisher,
        Mixed,
    }

    public class ConfigurationFile
    {
        [JsonProperty("baseUrl")]
        public string BaseUrl { get; set; }

        [JsonProperty("providerType")]
        public ProviderType ProviderType { get; set; }

        [JsonProperty("applicationMode")]
        public ApplicationMode ApplicationMode { get; set; }
    }
}