using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLabLog.Core.Models
{
    /// <summary>
    /// Defines an author in the notebook. Ideally this information would come from an Azure AD directory?
    /// </summary>
    public class Author
    {
        /// <summary>
        /// First name
        /// </summary>
        /// 
        [Required]
        public string? FirstName { get; set; }
        /// <summary>
        /// Last name
        /// </summary>
        [Required]
        public string? LastName { get; set; }
    }
}
