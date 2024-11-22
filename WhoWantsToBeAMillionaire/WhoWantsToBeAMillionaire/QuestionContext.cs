using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire
{
    class QuestionContext:DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
