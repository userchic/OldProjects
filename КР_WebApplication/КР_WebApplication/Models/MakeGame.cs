using CPWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPWebApplication.Models
{
    public class MakeGame
    {
        public string GameName { get; set; }
        public DateTime StartData { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int Lenga { get; set; }
        public int ID { get; set; }
        public List<Tasks> Tasks { get; set; }
        public string Text {get;set; }
        public string RightAnswer {get;set; }
    }
}