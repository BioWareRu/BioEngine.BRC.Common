﻿using Sitko.Core.Repository;

namespace BioEngine.BRC.Common.Users
{
    public interface IUser : IEntity<string>
    {
        string Name { get; set; }
        string PhotoUrl { get; set; }
        string ProfileUrl { get; set; }
    }
}
