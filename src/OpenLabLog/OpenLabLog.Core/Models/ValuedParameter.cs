using OpenLabLog.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace OpenLabLog.Core.Models
{
    /// <summary>
    /// A value linked to a parameter set previously
    /// TODO: Add binary data support/image support
    /// </summary>
    public class ValuedParameter : IEntity
    {
        ///<inheritdoc/>
        public long Id { get; set; }
        /// <summary>
        /// The value entered.
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        /// The unit of the value. Required.
        /// </summary>
        /// 
        [Required]
        public string? Unit { get; set; }
        /// <summary>
        /// An optional note about the value in here.
        /// </summary>
        public string? Note { get; set; }
        /// <summary>
        /// The id of the parameter linked to this value.
        /// </summary>
        public long ParameterId { get; set; }
        /// <summary>
        /// The parameter navigational property.
        /// </summary>
        public virtual Parameter? Parameter { get; set; }
    }
}
