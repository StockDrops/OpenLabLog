using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLabLog.Core.Models.Configuration
{
    /// <summary>
    /// Configuration for azure
    /// </summary>
    public class AzureConfiguration
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public string? Instance { get; set; }
        public string? Domain { get; set; }
        public string? TenantId { get; set; }
        public string? ClientId { get; set; }
        public string? Scopes { get; set; }
        public string? CallbackPath { get; set; }
        public string? ApiScopeRoot { get; set; }
    }
    /// <summary>
    /// The configuration for B2C
    /// </summary>
    public class AzureB2CConfiguration : AzureConfiguration
    {
        public string? SignUpSignInPolicyId { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
