﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPWebApplication.Models
{
    public class GameDbInitializer:DropCreateDatabaseAlways<GameContext>
    {
        protected override void Seed(GameContext db)
        {
            base.Seed(db);
        }
    }
}