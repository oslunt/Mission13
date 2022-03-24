using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFTeamsRepository : ITeamsRepository
    {
        private BowlingLeagueDbContext context { get; set; }

        public EFTeamsRepository(BowlingLeagueDbContext temp)
        {
            context = temp;
        }

        public IQueryable<Team> Teams => context.Teams;
    }
}
