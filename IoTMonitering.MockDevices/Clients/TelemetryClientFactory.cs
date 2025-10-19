using DeviceMock.Interface;
using DeviceMock.Models;

namespace DeviceMock.Clients
{
    public static class TelemetryClientFactory
    {
        public static TelemetryClient? Create(string type, string endpoint)
        {
            return type switch
            {
                "rest" => new TelemetryRestClient(endpoint),
                "hub" => new TelemetryRestClient(endpoint),
                "websocket" => new TelemetryRestClient(endpoint),
                "tcp" => new TelemetryRestClient(endpoint),
                "udp" => new TelemetryRestClient(endpoint),
                "grpc" => new TelemetryRestClient(endpoint),
                _ => null
            };
        }
    }
}
