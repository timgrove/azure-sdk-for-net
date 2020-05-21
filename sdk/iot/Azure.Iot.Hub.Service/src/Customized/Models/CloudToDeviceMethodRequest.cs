// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Iot.Hub.Service.Models
{
    /// <summary>
    /// Parameters to execute a direct method on the device.
    /// </summary>
    [CodeGenModel("CloudToDeviceMethod")]
    public partial class CloudToDeviceMethodRequest
    {
        public CloudToDeviceMethodRequest(string methodName)
        {
            MethodName = methodName;
        }

        /// <summary>
        /// The JSON-formatted direct method payload, up to 128kb in size.
        /// </summary>
        public string Payload { get; set; }
    }
}
