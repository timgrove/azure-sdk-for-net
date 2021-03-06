// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace Azure.Management.Network.Models
{
    /// <summary> Result of the request to list VpnGateways. It contains a list of VpnGateways and a URL nextLink to get the next set of results. </summary>
    public partial class ListVpnGatewaysResult
    {
        /// <summary> Initializes a new instance of ListVpnGatewaysResult. </summary>
        internal ListVpnGatewaysResult()
        {
        }

        /// <summary> Initializes a new instance of ListVpnGatewaysResult. </summary>
        /// <param name="value"> List of VpnGateways. </param>
        /// <param name="nextLink"> URL to get the next set of operation list results if there are any. </param>
        internal ListVpnGatewaysResult(IReadOnlyList<VpnGateway> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary> List of VpnGateways. </summary>
        public IReadOnlyList<VpnGateway> Value { get; }
        /// <summary> URL to get the next set of operation list results if there are any. </summary>
        public string NextLink { get; }
    }
}
