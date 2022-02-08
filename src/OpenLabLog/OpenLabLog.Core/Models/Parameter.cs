using OpenLabLog.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace OpenLabLog.Core.Models
{
    /// <summary>
    /// Defines a parameter used in a log/experiment.
    /// It will have a unique Id, a name, and a unit associated with it.
    /// </summary>
    public class Parameter : IEntity
    {
        /// <summary>
        /// unique id identifying the parameter.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// User's name for the parameter
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Unit for the parameter.
        /// </summary>
        public string? Unit { get; set; }
        /// <summary>
        /// Is the parameter required?
        /// </summary>
        public bool IsRequired { get; set; }
    }
}
