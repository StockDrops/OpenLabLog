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
    /// Defines an entry in a log.
    /// </summary>
    public class LogEntry : IEntity
    {
        ///<inheritdoc/>
        public long Id { get; set; }
        /// <summary>
        /// The title of the entry. Optional.
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// Optional entry. The user can just change values.
        /// </summary>
        public string? Entry { get; set; }
        /// <summary>
        /// The date of the entry
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// The id of the author
        /// </summary>
        /// 
        [Required(ErrorMessage = "Enter an author Id. Enter 0 if specifying a new author with the field 'author'")]
        public long AuthorId { get; set; }
        /// <summary>
        /// The author of the entry
        /// </summary>
        public virtual Author? Author { get; set; }
        /// <summary>
        /// The set of values associated with this log entry.
        /// </summary>
        public virtual ISet<ValuedParameter> Values { get; set; } = new HashSet<ValuedParameter>();
    }
}
