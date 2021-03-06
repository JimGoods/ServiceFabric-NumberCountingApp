﻿using Microsoft.ServiceFabric.Services;
using Microsoft.ServiceFabric.Services.Wcf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Client;

namespace NumberCountingService.Client
{
    class NumCountingSvcClient : ServicePartitionClient<WcfCommunicationClient<INumberCounter>>, INumberCounter
    {
        public NumCountingSvcClient(
            WcfCommunicationClientFactory<INumberCounter> clientFactory,
            Uri serviceName)
            : base(clientFactory, serviceName)
        {
        }

        public Task<long> GetCurrentNumber()
        {
            return this.InvokeWithRetryAsync(
                client => client.Channel.GetCurrentNumber());
        }
    }
}
