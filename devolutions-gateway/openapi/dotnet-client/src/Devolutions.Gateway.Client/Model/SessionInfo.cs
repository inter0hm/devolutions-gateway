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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using FileParameter = Devolutions.Gateway.Client.Client.FileParameter;
using OpenAPIDateConverter = Devolutions.Gateway.Client.Client.OpenAPIDateConverter;

namespace Devolutions.Gateway.Client.Model
{
    /// <summary>
    /// Information about an ongoing Gateway session
    /// </summary>
    [DataContract(Name = "SessionInfo")]
    public partial class SessionInfo : IValidatableObject
    {

        /// <summary>
        /// Gets or Sets ConnectionMode
        /// </summary>
        [DataMember(Name = "connection_mode", IsRequired = true, EmitDefaultValue = true)]
        public ConnectionMode ConnectionMode { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionInfo" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SessionInfo() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SessionInfo" /> class.
        /// </summary>
        /// <param name="applicationProtocol">Protocol used during this session (required).</param>
        /// <param name="associationId">Unique ID for this session (required).</param>
        /// <param name="connectionMode">connectionMode (required).</param>
        /// <param name="destinationHost">Destination Host.</param>
        /// <param name="filteringPolicy">Filtering Policy (required).</param>
        /// <param name="recordingPolicy">Recording Policy (required).</param>
        /// <param name="startTimestamp">Date this session was started (required).</param>
        /// <param name="timeToLive">Maximum session duration in minutes (0 is used for the infinite duration).</param>
        public SessionInfo(string applicationProtocol = default(string), Guid associationId = default(Guid), ConnectionMode connectionMode = default(ConnectionMode), string destinationHost = default(string), bool filteringPolicy = default(bool), bool recordingPolicy = default(bool), DateTime startTimestamp = default(DateTime), long? timeToLive = default(long?))
        {
            // to ensure "applicationProtocol" is required (not null)
            if (applicationProtocol == null)
            {
                throw new ArgumentNullException("applicationProtocol is a required property for SessionInfo and cannot be null");
            }
            this.ApplicationProtocol = applicationProtocol;
            this.AssociationId = associationId;
            this.ConnectionMode = connectionMode;
            this.FilteringPolicy = filteringPolicy;
            this.RecordingPolicy = recordingPolicy;
            this.StartTimestamp = startTimestamp;
            this.DestinationHost = destinationHost;
            this.TimeToLive = timeToLive;
        }

        /// <summary>
        /// Protocol used during this session
        /// </summary>
        /// <value>Protocol used during this session</value>
        [DataMember(Name = "application_protocol", IsRequired = true, EmitDefaultValue = true)]
        public string ApplicationProtocol { get; set; }

        /// <summary>
        /// Unique ID for this session
        /// </summary>
        /// <value>Unique ID for this session</value>
        [DataMember(Name = "association_id", IsRequired = true, EmitDefaultValue = true)]
        public Guid AssociationId { get; set; }

        /// <summary>
        /// Destination Host
        /// </summary>
        /// <value>Destination Host</value>
        [DataMember(Name = "destination_host", EmitDefaultValue = true)]
        public string DestinationHost { get; set; }

        /// <summary>
        /// Filtering Policy
        /// </summary>
        /// <value>Filtering Policy</value>
        [DataMember(Name = "filtering_policy", IsRequired = true, EmitDefaultValue = true)]
        public bool FilteringPolicy { get; set; }

        /// <summary>
        /// Recording Policy
        /// </summary>
        /// <value>Recording Policy</value>
        [DataMember(Name = "recording_policy", IsRequired = true, EmitDefaultValue = true)]
        public bool RecordingPolicy { get; set; }

        /// <summary>
        /// Date this session was started
        /// </summary>
        /// <value>Date this session was started</value>
        [DataMember(Name = "start_timestamp", IsRequired = true, EmitDefaultValue = true)]
        public DateTime StartTimestamp { get; set; }

        /// <summary>
        /// Maximum session duration in minutes (0 is used for the infinite duration)
        /// </summary>
        /// <value>Maximum session duration in minutes (0 is used for the infinite duration)</value>
        [DataMember(Name = "time_to_live", EmitDefaultValue = true)]
        public long? TimeToLive { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SessionInfo {\n");
            sb.Append("  ApplicationProtocol: ").Append(ApplicationProtocol).Append("\n");
            sb.Append("  AssociationId: ").Append(AssociationId).Append("\n");
            sb.Append("  ConnectionMode: ").Append(ConnectionMode).Append("\n");
            sb.Append("  DestinationHost: ").Append(DestinationHost).Append("\n");
            sb.Append("  FilteringPolicy: ").Append(FilteringPolicy).Append("\n");
            sb.Append("  RecordingPolicy: ").Append(RecordingPolicy).Append("\n");
            sb.Append("  StartTimestamp: ").Append(StartTimestamp).Append("\n");
            sb.Append("  TimeToLive: ").Append(TimeToLive).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            // TimeToLive (long?) minimum
            if (this.TimeToLive < (long?)0)
            {
                yield return new ValidationResult("Invalid value for TimeToLive, must be a value greater than or equal to 0.", new [] { "TimeToLive" });
            }

            yield break;
        }
    }

}
