using System;
using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using PubSubClientCore.Responses;

namespace PubSubClientCore.Model
{
    public class AwsSubscriber : SubscriberBase
    {
        private AmazonSQSClient _amazonClient;

        public AwsSubscriber(SubscriberMetadata subscriberMetadata) : base(subscriberMetadata)
        {
        }

        public override void Setup()
        {
            var credentials = new AnonymousAWSCredentials();
            _amazonClient = new AmazonSQSClient(credentials, RegionEndpoint.EUCentral1);
        }

        private async void FetchMessages()
        {
            var request = new ReceiveMessageRequest
            {
                AttributeNames = { "SentTimestamp" },
                MaxNumberOfMessages = 1,
                MessageAttributeNames = { "All" },
                QueueUrl = SubscriberMetadata.QueueUrl,
                WaitTimeSeconds = 20,
            };

            while (true)
            {
                var response = await _amazonClient.ReceiveMessageAsync(request);
                foreach (var message in response.Messages)
                    Console.WriteLine(message.Body);
            }
        }
    }
}