// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Iot.Hub.Service.Models
{
    /// <summary>
    /// Represents the Device Method Invocation Results.
    /// </summary>
    [CodeGenModel("CloudToDeviceMethodResult")]
    public partial class CloudToDeviceMethodResponse
    {
        /// <summary>
        /// The JSON-formatted direct method result payload, up to 128kb in size; provided by the device.
        /// </summary>
        public string Payload { get; }
    }
}
