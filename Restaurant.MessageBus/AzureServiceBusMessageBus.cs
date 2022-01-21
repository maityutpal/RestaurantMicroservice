﻿using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.MessageBus
{
    public class AzureServiceBusMessageBus:IMessageBus
    {
        
        private string connectionString = "Endpoint=sb://XXXXXXXXXX.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=6CDIGhKMnlYGTyaFFJQDa+hHXXXXXPksVVgzQYWA8oWCdiU=";

        public async Task PublishMessage(BaseMessage message, string topicName)
        {

            await using var client = new ServiceBusClient(connectionString);

            ServiceBusSender sender = client.CreateSender(topicName);

            var jsonMessage = JsonConvert.SerializeObject(message);
            ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString()
            };

            await sender.SendMessageAsync(finalMessage);

            await client.DisposeAsync();
        }
    }
}
