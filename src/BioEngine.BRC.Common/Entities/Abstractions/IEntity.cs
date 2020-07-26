using System;
using Sitko.Core.Repository;

namespace BioEngine.BRC.Common.Entities.Abstractions
{
    public interface IBioEntity : IEntity<Guid>
    {
        DateTimeOffset DateAdded { get; set; }
        DateTimeOffset DateUpdated { get; set; }
    }
}
