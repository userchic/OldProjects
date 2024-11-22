using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPWebApplication.Models
{
    public class Game
    {
        public string GameName { get; set; }
        public DateTime StartData { get; set; }
        public DateTime StartTime { get; set; }
        public int Lenga { get; set; }
        public int ID {get;set;}
        public ICollection<Tasks> TasksList { get; set; }
        public Game()
        {
            TasksList = new List<Tasks>();
        }
    }
}