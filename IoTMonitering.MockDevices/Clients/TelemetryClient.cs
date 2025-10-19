﻿using DeviceMock.Interface;
using DeviceMock.Models;

namespace DeviceMock.Clients
{
    public abstract class TelemetryClient : ITelemetryClient
    {
        protected readonly string _endpoint;
        public TelemetryClient(string endpoint)
        {
            _endpoint = endpoint;
        }

        public abstract bool IsDeviceRegisterd(string deviceId);

        public abstract Task SendTelemtryAsync(Telemetry telemetry);
    }
}
