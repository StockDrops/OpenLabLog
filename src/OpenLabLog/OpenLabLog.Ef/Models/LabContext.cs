using Microsoft.EntityFrameworkCore;
using OpenLabLog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLabLog.Ef.Models
{
    public class LabContext : DbContext
    {
        public DbSet<Experiment> Experiments => Set<Experiment>();
        public DbSet<LogBook> LogBooks => Set<LogBook>();
        public DbSet<Log> Logs => Set<Log>();
        public DbSet<LogEntry> LogEntries => Set<LogEntry>();
        public DbSet<ValuedParameter> ValuedParameters => Set<ValuedParameter>();
        public DbSet<Parameter> Parameters => Set<Parameter>();
    }
}
