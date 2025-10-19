using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceMock.Models;

namespace DeviceMock.Clients
{
    internal class TelemetryGrpcClient : TelemetryClient
    {
        public TelemetryGrpcClient(string endpoint) : base(endpoint)
        {
        }

        public override bool IsDeviceRegisterd(string deviceId)
        {
            throw new NotImplementedException();
        }

        public override Task SendTelemtryAsync(Telemetry telemetry)
        {
            throw new NotImplementedException();
        }
    }
}
