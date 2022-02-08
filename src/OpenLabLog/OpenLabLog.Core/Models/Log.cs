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
    /// A log containing information of the experiment. The idea is that every day you can create a log and then add entries to it as you go. 
    /// </summary>
    public class Log : IEntity
    {
        ///<inheritdoc/>
        public long Id { get; set; }
        /// <summary>
        /// The title of the log
        /// </summary>
        [Required]
        public string? Title { get; set; }
        /// <summary>
        /// The entries associated
        /// </summary>
        public ISet<LogEntry> LogEntry { get; set; } = new HashSet<LogEntry>();
        
        /// <summary>
        /// The id of the log book
        /// </summary>
        public long LogBookId { get; set; }
        /// <summary>
        /// Navigational property for a log book
        /// </summary>
        public LogBook? LogBook { get; set; }

    }
}
