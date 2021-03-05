﻿using Grpc.Net.Client;
using GrpcDottyLogs;
using System;
using System.Threading.Tasks;

namespace DottyLogs.Client.BackgroundServices
{
    public class UpdatePusherService : IDisposable
    {
        private readonly GrpcChannel _channel;
        private readonly GrpcDottyLogs.DottyLogs.DottyLogsClient _client;

        public UpdatePusherService()
        {
            _channel = GrpcChannel.ForAddress("https://localhost:5001");
            _client = new GrpcDottyLogs.DottyLogs.DottyLogsClient(_channel);
        }

        public void Dispose()
        {
            _channel.ShutdownAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public async Task StartSpan(StartSpanRequest requestUpdate)
        {
            await _client.StartSpanAsync(requestUpdate);
        }

        public async Task StopSpan(StopSpanRequest requestUpdate)
        {
            await _client.StopSpanAsync(requestUpdate);
        }
    }
}