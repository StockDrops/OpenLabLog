using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLabLog.Core.Contracts.Models;

/// <summary>
/// An interface defining an entity using a long for id.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Id of the entity.
    /// </summary>
    public long Id { get; set; }
}
