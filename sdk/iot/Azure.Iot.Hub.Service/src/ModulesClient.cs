// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Iot.Hub.Service.Models;

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    ///
    /// </summary>
    public class ModulesClient
    {
        private const string ContinuationTokenHeader = "x-ms-continuation";

        private readonly RegistryManagerRestClient _registryManagerClient;
        private readonly TwinRestClient _twinRestClient;
        private readonly DeviceMethodRestClient _deviceMethodRestClient;

        /// <summary>
        /// Parameterless constructor for mocking purposes.
        /// </summary>
        protected ModulesClient()
        {
        }

        internal ModulesClient(RegistryManagerRestClient registryManagerClient, TwinRestClient twinRestClient, DeviceMethodRestClient deviceMethodRestClient)
        {
            Argument.AssertNotNull(registryManagerClient, nameof(registryManagerClient));
            Argument.AssertNotNull(twinRestClient, nameof(twinRestClient));
            Argument.AssertNotNull(deviceMethodRestClient, nameof(deviceMethodRestClient));

            _registryManagerClient = registryManagerClient;
            _twinRestClient = twinRestClient;
            _deviceMethodRestClient = deviceMethodRestClient;
        }

        /// <summary>
        /// Create a device module.
        /// </summary>
        /// <param name="moduleIdentity">The module to create.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual async Task<Response<ModuleIdentity>> CreateIdentityAsync(ModuleIdentity moduleIdentity, CancellationToken cancellationToken = default)
        {
            return await _registryManagerClient.CreateOrUpdateModuleAsync(moduleIdentity.DeviceId, moduleIdentity.ModuleId, moduleIdentity, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a device module.
        /// </summary>
        /// <param name="moduleIdentity">The module to create.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public virtual Response<ModuleIdentity> CreateIdentity(ModuleIdentity moduleIdentity, CancellationToken cancellationToken = default)
        {
            return _registryManagerClient.CreateOrUpdateModule(moduleIdentity.DeviceId, moduleIdentity.ModuleId, moduleIdentity, null, cancellationToken);
        }

        /// <summary>
        /// Get a single device module.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device that contains the module.</param>
        /// <param name="moduleId">The unique identifier of the module to get.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved device.</returns>
        public virtual async Task<Response<ModuleIdentity>> GetIdentityAsync(string deviceId, string moduleId, CancellationToken cancellationToken = default)
        {
            return await _registryManagerClient.GetModuleAsync(deviceId, moduleId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a single device module.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device that contains the module.</param>
        /// <param name="moduleId">The unique identifier of the module to get.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved device.</returns>
        public virtual Response<ModuleIdentity> GetIdentity(string deviceId, string moduleId, CancellationToken cancellationToken = default)
        {
            return _registryManagerClient.GetModule(deviceId, moduleId, cancellationToken);
        }

        /// <summary>
        /// List a set of device modules.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of device modules.</returns>
        public virtual async Task<Response<IReadOnlyList<ModuleIdentity>>> GetIdentitiesAsync(string deviceId, CancellationToken cancellationToken = default)
        {
            return await _registryManagerClient.GetModulesOnDeviceAsync(deviceId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// List a set of device modules.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of device modules.</returns>
        public virtual Response<IReadOnlyList<ModuleIdentity>> GetIdentities(string deviceId, CancellationToken cancellationToken = default)
        {
            return _registryManagerClient.GetModulesOnDevice(deviceId, cancellationToken);
        }

        /// <summary>
        /// Update a device module.
        /// </summary>
        /// <param name="moduleIdentity">The module to update.</param>
        /// <param name="ifMatch">A string representing a weak ETag for this module, as per RFC7232. The update operation is performed
        /// only if this ETag matches the value maintained by the server, indicating that the module has not been modified since it was last retrieved.
        /// The current ETag can be retrieved from the module identity last retrieved from the service. To force an unconditional update, set If-Match to the wildcard character (*).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created or updated device module.</returns>
        public virtual async Task<Response<ModuleIdentity>> UpdateIdentityAsync(ModuleIdentity moduleIdentity, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            return await _registryManagerClient.CreateOrUpdateModuleAsync(moduleIdentity.DeviceId, moduleIdentity.ModuleId, moduleIdentity, ifMatch, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a device module.
        /// </summary>
        /// <param name="moduleIdentity">The module to update.</param>
        /// <param name="ifMatch">A string representing a weak ETag for this module, as per RFC7232. The update operation is performed
        /// only if this ETag matches the value maintained by the server, indicating that the module has not been modified since it was last retrieved.
        /// The current ETag can be retrieved from the module identity last retrieved from the service. To force an unconditional update, set If-Match to the wildcard character (*).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The created or updated device module.</returns>
        public virtual  Response<ModuleIdentity> UpdateIdentity(ModuleIdentity moduleIdentity, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            return _registryManagerClient.CreateOrUpdateModule(moduleIdentity.DeviceId, moduleIdentity.ModuleId, moduleIdentity, ifMatch, cancellationToken);
        }

        /// <summary>
        /// Delete a single device module.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device that contains the module.</param>
        /// <param name="moduleId">The unique identifier of the module to get.</param>
        /// <param name="ifMatch">A string representing a weak ETag for this module, as per RFC7232. The update operation is performed
        /// only if this ETag matches the value maintained by the server, indicating that the module has not been modified since it was last retrieved.
        /// The current ETag can be retrieved from the module identity last retrieved from the service. To force an unconditional update, set If-Match to the wildcard character (*).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        public virtual async Task<Response> DeleteIdentityAsync(string deviceId, string moduleId, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            return await _registryManagerClient.DeleteModuleAsync(deviceId, moduleId, ifMatch, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a single device module.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device that contains the module.</param>
        /// <param name="moduleId">The unique identifier of the module to get.</param>
        /// <param name="ifMatch">A string representing a weak ETag for this module, as per RFC7232. The update operation is performed
        /// only if this ETag matches the value maintained by the server, indicating that the module has not been modified since it was last retrieved.
        /// The current ETag can be retrieved from the module identity last retrieved from the service. To force an unconditional update, set If-Match to the wildcard character (*).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The http response.</returns>
        public virtual Response DeleteIdentity(string deviceId, string moduleId, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            return _registryManagerClient.DeleteModule(deviceId, moduleId, ifMatch, cancellationToken);
        }

        /// <summary>
        /// Gets the module twin.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device.</param>
        /// <param name="moduleId">The unique identifier of the device module.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved module twin.</returns>
        public virtual async Task<Response<TwinData>> GetTwinAsync(string deviceId, string moduleId, CancellationToken cancellationToken = default)
        {
            return await _twinRestClient.GetModuleTwinAsync(deviceId, moduleId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the module twin.
        /// </summary>
        /// <param name="deviceId">The unique identifier of the device.</param>
        /// <param name="moduleId">The unique identifier of the device module.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The retrieved module twin.</returns>
        public virtual Response<TwinData> GetTwin(string deviceId, string moduleId, CancellationToken cancellationToken = default)
        {
            return _twinRestClient.GetModuleTwin(deviceId, moduleId, cancellationToken);
        }

        /// <summary>
        /// List a set of module twins.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of module twins.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<Pending>")]
        public virtual AsyncPageable<TwinData> GetTwinsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<TwinData>> FirstPageFunc(int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification
                {
                    Query = "select * from modules"
                };

                Response<IReadOnlyList<TwinData>> response = await _registryManagerClient.QueryIotHubAsync(querySpecification, null, pageSizeHint?.ToString(), cancellationToken).ConfigureAwait(false);

                string continuationToken;
                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out continuationToken);

                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            async Task<Page<TwinData>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification();
                Response<IReadOnlyList<TwinData>> response = await _registryManagerClient.QueryIotHubAsync(querySpecification, nextLink, pageSizeHint?.ToString(), cancellationToken).ConfigureAwait(false);
                string continuationToken;
                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out continuationToken);
                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// List a set of module twins.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A pageable set of module twins.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1305:Specify IFormatProvider", Justification = "<Pending>")]
        public virtual Pageable<TwinData> GetTwins(CancellationToken cancellationToken = default)
        {
            Page<TwinData> FirstPageFunc(int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification
                {
                    Query = "select * from modules"
                };

                Response<IReadOnlyList<TwinData>> response = _registryManagerClient.QueryIotHub(querySpecification, null, pageSizeHint?.ToString(), cancellationToken);

                string continuationToken;
                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out continuationToken);

                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            Page<TwinData> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var querySpecification = new QuerySpecification();
                Response<IReadOnlyList<TwinData>> response = _registryManagerClient.QueryIotHub(querySpecification, nextLink, pageSizeHint?.ToString(), cancellationToken);
                response.GetRawResponse().Headers.TryGetValue(ContinuationTokenHeader, out string continuationToken);
                return Page.FromValues(response.Value, continuationToken, response.GetRawResponse());
            }

            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Update a module's twin.
        /// </summary>
        /// <param name="twinPatch">The properties to update. Any existing properties not referenced by this patch will be unaffected by this patch.</param>
        /// <param name="ifMatch">A string representing a weak ETag for this twin, as per RFC7232. The update operation is performed
        /// only if this ETag matches the value maintained by the server, indicating that the twin has not been modified since it was last retrieved.
        /// To force an unconditional update, set If-Match to the wildcard character (*).</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The server's new representation of the device twin.</returns>
        public virtual async Task<Response<TwinData>> UpdateTwinAsync(TwinData twinPatch, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            return await _twinRestClient.UpdateModuleTwinAsync(twinPatch.DeviceId, twinPatch.ModuleId, twinPatch, ifMatch, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Update a module's twin.
        /// </summary>
        /// <param name="twinPatch">The properties to update. Any existing properties not referenced by this patch will be unaffected by this patch.</param>
        /// <param name="ifMatch">A string representing a weak ETag for this twin, as per RFC7232. The update operation is performed
        /// only if this ETag matches the value maintained by the server, indicating that the twin has not been modified since it was last retrieved.
        /// To force an unconditional update, set If-Match to the wildcard character (*).</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The server's new representation of the device twin.</returns>
        public virtual Response<TwinData> UpdateTwin(TwinData twinPatch, string ifMatch = null, CancellationToken cancellationToken = default)
        {
            return _twinRestClient.UpdateModuleTwin(twinPatch.DeviceId, twinPatch.ModuleId, twinPatch, ifMatch, cancellationToken);
        }

        ///// <summary>
        ///// Invoke a method on a device module.
        ///// </summary>
        ///// <param name="deviceId">The unique identifier of the device that contains the module.</param>
        ///// <param name="moduleId">The unique identifier of the module.</param>
        ///// <param name="cloudToDeviceMethodRequest">The details of the method to invoke.</param>
        ///// <param name="cancellationToken">The cancellation token.</param>
        ///// <returns>The result of the method invocation.</returns>
        // TODO: merge with updated models first // public virtual async Task<Response<CloudToDeviceMethodResponse>> InvokeMethodAsync(string deviceId, string moduleId, CloudToDeviceMethodRequest cloudToDeviceMethodRequest, CancellationToken cancellationToken = default);
    }
}
