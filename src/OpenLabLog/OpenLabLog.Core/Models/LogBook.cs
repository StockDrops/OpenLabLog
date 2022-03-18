using OpenLabLog.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLabLog.Core.Models
{
    /// <summary>
    /// A log book represents a place where you can make many logs for a given experiment.
    /// </summary>
    public class LogBook : IEntity
    {
        ///<inheritdoc/>
        public long Id { get; set; }
        /// <summary>
        /// log book's title. Imagine what you'd name your physical log book.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// The logbook contains many logs.
        /// </summary>
        public virtual ISet<Log> Logs { get; set; } = new HashSet<Log>();

        /// <summary>
        /// The id of the associated experiment
        /// </summary>
        public long ExperimentId { get; set; }
        /// <summary>
        /// The navigational property for the experiment.
        /// </summary>
        public virtual Experiment? Experiment { get; set; }
    }
}
