// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Media.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Describes the settings to produce a PNG image from the input video.
    /// </summary>
    [Newtonsoft.Json.JsonObject("#Microsoft.Media.PngLayer")]
    public partial class PngLayer : Layer
    {
        /// <summary>
        /// Initializes a new instance of the PngLayer class.
        /// </summary>
        public PngLayer()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PngLayer class.
        /// </summary>
        /// <param name="width">The width of the output video for this layer.
        /// The value can be absolute (in pixels) or relative (in percentage).
        /// For example 50% means the output video has half as many pixels in
        /// width as the input.</param>
        /// <param name="height">The height of the output video for this layer.
        /// The value can be absolute (in pixels) or relative (in percentage).
        /// For example 50% means the output video has half as many pixels in
        /// height as the input.</param>
        /// <param name="label">The alphanumeric label for this layer, which
        /// can be used in multiplexing different video and audio layers, or in
        /// naming the output file.</param>
        public PngLayer(string width = default(string), string height = default(string), string label = default(string))
            : base(width, height, label)
        {
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

    }
}