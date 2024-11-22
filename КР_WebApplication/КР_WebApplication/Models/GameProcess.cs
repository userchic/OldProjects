using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using КР_WebApplication.Models;

namespace CPWebApplication.Models
{
    public class GameProcess
    {
        public int ID { get; set; }
        public List<GameTask> Tasks;
        public InGameUser Player = new InGameUser();
        public InGameUser RNG = new InGameUser();
    }
}