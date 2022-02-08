using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLabLog.Core.Models.Configuration
{
    public class ApiRole
    {
        public ApiRole(string roleName)
        {
            RoleName = roleName ?? throw new ArgumentNullException(nameof(roleName));
        }
        public ApiRole() { }
        public string? RoleName { get; set; }
        public string? RoleAdValue { get; set; }
    }
    public class PredifinedRoles
    {
        public const string AdminsPolicyName = "Admins";
        public ApiRole Admins { get; set; } = new ApiRole("Admin");

    }
}
