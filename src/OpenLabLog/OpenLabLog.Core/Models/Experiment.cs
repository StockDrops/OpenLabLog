using OpenLabLog.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLabLog.Core.Models
{
    /// <summary>
    /// An experiments can hold multiple logbooks and global information that will not change between runs/logs
    /// </summary>
    public class Experiment : IEntity
    {
        ///<inheritdoc/>
        public long Id { get; set; }
        /// <summary>
        /// The name of the experiment
        /// </summary>
        /// 
        [Required]
        public string? Name { get; set; }
        
        /// <summary>
        /// This is meant to be a place where you can enter information of the expiriment in a global fashion.
        /// Even include information to help first time students get started.
        /// </summary>
        public string? Description { get; set; }
    }
}
