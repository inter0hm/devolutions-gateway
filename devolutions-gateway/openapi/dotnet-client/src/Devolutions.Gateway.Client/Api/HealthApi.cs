/*
 * devolutions-gateway
 *
 * Protocol-aware fine-grained relay server
 *
 * The version of the OpenAPI document: 2024.3.4
 * Contact: infos@devolutions.net
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using Devolutions.Gateway.Client.Client;
using Devolutions.Gateway.Client.Model;

namespace Devolutions.Gateway.Client.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IHealthApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Performs a health check
        /// </summary>
        /// <exception cref="Devolutions.Gateway.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Identity</returns>
        Identity GetHealth();

        /// <summary>
        /// Performs a health check
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Devolutions.Gateway.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Identity</returns>
        ApiResponse<Identity> GetHealthWithHttpInfo();
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IHealthApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Performs a health check
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Devolutions.Gateway.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Identity</returns>
        System.Threading.Tasks.Task<Identity> GetHealthAsync(System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));

        /// <summary>
        /// Performs a health check
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Devolutions.Gateway.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Identity)</returns>
        System.Threading.Tasks.Task<ApiResponse<Identity>> GetHealthWithHttpInfoAsync(System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IHealthApi : IHealthApiSync, IHealthApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class HealthApi : IDisposable, IHealthApi
    {
        private Devolutions.Gateway.Client.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <returns></returns>
        public HealthApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthApi"/> class.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        public HealthApi(string basePath)
        {
            this.Configuration = Devolutions.Gateway.Client.Client.Configuration.MergeConfigurations(
                Devolutions.Gateway.Client.Client.GlobalConfiguration.Instance,
                new Devolutions.Gateway.Client.Client.Configuration { BasePath = basePath }
            );
            this.ApiClient = new Devolutions.Gateway.Client.Client.ApiClient(this.Configuration.BasePath);
            this.Client =  this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            this.ExceptionFactory = Devolutions.Gateway.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthApi"/> class using Configuration object.
        /// **IMPORTANT** This will also create an instance of HttpClient, which is less than ideal.
        /// It's better to reuse the <see href="https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests#issues-with-the-original-httpclient-class-available-in-net">HttpClient and HttpClientHandler</see>.
        /// </summary>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public HealthApi(Devolutions.Gateway.Client.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Devolutions.Gateway.Client.Client.Configuration.MergeConfigurations(
                Devolutions.Gateway.Client.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.ApiClient = new Devolutions.Gateway.Client.Client.ApiClient(this.Configuration.BasePath);
            this.Client = this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            ExceptionFactory = Devolutions.Gateway.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public HealthApi(HttpClient client, HttpClientHandler handler = null) : this(client, (string)null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthApi"/> class.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="basePath">The target service's base path in URL format.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public HealthApi(HttpClient client, string basePath, HttpClientHandler handler = null)
        {
            if (client == null) throw new ArgumentNullException("client");

            this.Configuration = Devolutions.Gateway.Client.Client.Configuration.MergeConfigurations(
                Devolutions.Gateway.Client.Client.GlobalConfiguration.Instance,
                new Devolutions.Gateway.Client.Client.Configuration { BasePath = basePath }
            );
            this.ApiClient = new Devolutions.Gateway.Client.Client.ApiClient(client, this.Configuration.BasePath, handler);
            this.Client =  this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            this.ExceptionFactory = Devolutions.Gateway.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthApi"/> class using Configuration object.
        /// </summary>
        /// <param name="client">An instance of HttpClient.</param>
        /// <param name="configuration">An instance of Configuration.</param>
        /// <param name="handler">An optional instance of HttpClientHandler that is used by HttpClient.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        /// <remarks>
        /// Some configuration settings will not be applied without passing an HttpClientHandler.
        /// The features affected are: Setting and Retrieving Cookies, Client Certificates, Proxy settings.
        /// </remarks>
        public HealthApi(HttpClient client, Devolutions.Gateway.Client.Client.Configuration configuration, HttpClientHandler handler = null)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");
            if (client == null) throw new ArgumentNullException("client");

            this.Configuration = Devolutions.Gateway.Client.Client.Configuration.MergeConfigurations(
                Devolutions.Gateway.Client.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.ApiClient = new Devolutions.Gateway.Client.Client.ApiClient(client, this.Configuration.BasePath, handler);
            this.Client = this.ApiClient;
            this.AsynchronousClient = this.ApiClient;
            ExceptionFactory = Devolutions.Gateway.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public HealthApi(Devolutions.Gateway.Client.Client.ISynchronousClient client, Devolutions.Gateway.Client.Client.IAsynchronousClient asyncClient, Devolutions.Gateway.Client.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Devolutions.Gateway.Client.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Disposes resources if they were created by us
        /// </summary>
        public void Dispose()
        {
            this.ApiClient?.Dispose();
        }

        /// <summary>
        /// Holds the ApiClient if created
        /// </summary>
        public Devolutions.Gateway.Client.Client.ApiClient ApiClient { get; set; } = null;

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Devolutions.Gateway.Client.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Devolutions.Gateway.Client.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Devolutions.Gateway.Client.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Devolutions.Gateway.Client.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Performs a health check 
        /// </summary>
        /// <exception cref="Devolutions.Gateway.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>Identity</returns>
        public Identity GetHealth()
        {
            Devolutions.Gateway.Client.Client.ApiResponse<Identity> localVarResponse = GetHealthWithHttpInfo();
            return localVarResponse.Data;
        }

        /// <summary>
        /// Performs a health check 
        /// </summary>
        /// <exception cref="Devolutions.Gateway.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <returns>ApiResponse of Identity</returns>
        public Devolutions.Gateway.Client.Client.ApiResponse<Identity> GetHealthWithHttpInfo()
        {
            Devolutions.Gateway.Client.Client.RequestOptions localVarRequestOptions = new Devolutions.Gateway.Client.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

            var localVarContentType = Devolutions.Gateway.Client.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Devolutions.Gateway.Client.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);



            // make the HTTP request
            var localVarResponse = this.Client.Get<Identity>("/jet/health", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetHealth", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// Performs a health check 
        /// </summary>
        /// <exception cref="Devolutions.Gateway.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Identity</returns>
        public async System.Threading.Tasks.Task<Identity> GetHealthAsync(System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {
            Devolutions.Gateway.Client.Client.ApiResponse<Identity> localVarResponse = await GetHealthWithHttpInfoAsync(cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Performs a health check 
        /// </summary>
        /// <exception cref="Devolutions.Gateway.Client.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Identity)</returns>
        public async System.Threading.Tasks.Task<Devolutions.Gateway.Client.Client.ApiResponse<Identity>> GetHealthWithHttpInfoAsync(System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
        {

            Devolutions.Gateway.Client.Client.RequestOptions localVarRequestOptions = new Devolutions.Gateway.Client.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };


            var localVarContentType = Devolutions.Gateway.Client.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Devolutions.Gateway.Client.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);



            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Identity>("/jet/health", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetHealth", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
