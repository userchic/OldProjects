using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWantsToBeAMillionaire
{
    class QuestionDbInitializer:DropCreateDatabaseAlways<QuestionContext>
    {
        protected override void Seed(QuestionContext db)
        {
            base.Seed(db);
        }
    }
}
