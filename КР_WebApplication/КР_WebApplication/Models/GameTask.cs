﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPWebApplication.Models
{
    public class GameTask
    {
        public string Text { get; set; }
        public string Answer { get; set; }
        public string SentAnswer { get; set; }
        public string Result { get; set; }
        public int ID { get; set; }
    }
}