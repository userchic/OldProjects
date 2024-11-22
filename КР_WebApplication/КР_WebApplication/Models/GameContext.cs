using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPWebApplication.Models
{
    public class GameContext:DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Sent_Answers> UsersAnswers { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
