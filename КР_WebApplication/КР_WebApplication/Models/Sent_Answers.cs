﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CPWebApplication.Models
{
    public class Sent_Answers
    {
        public int ID { get; set; }
        public string Answer { get; set; }
        public int? TaskID { get; set; }
        public Tasks Task { get; set; }
        public int? UserID { get; set; }
        public Users User { get; set; }
        public DateTime SentTime { get; set; }
    }
}