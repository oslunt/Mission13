using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlingLeagueDbContext context;

        public EFBowlersRepository(BowlingLeagueDbContext temp)
        {
            context = temp;
        }

        public IQueryable<Bowler> Bowlers => context.Bowlers;

        public void CreateBowler(Bowler bowler)
        {
            if(bowler.BowlerID == 0)
            {
                bowler.BowlerID = context.Bowlers.Max(b => b.BowlerID) + 1;
                context.Bowlers.Add(bowler);
            }
            
            context.SaveChanges();
        }

        public void DeleteBowler(Bowler bowler)
        {
            context.Remove(bowler);
            context.SaveChanges();
        }

        public void SaveBowler(Bowler bowler)
        {
            context.Update(bowler);
            context.SaveChanges();
        }
    }
}
