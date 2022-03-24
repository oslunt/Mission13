using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public interface ITeamsRepository
    {
        public IQueryable<Team> Teams { get; }
    }
}
