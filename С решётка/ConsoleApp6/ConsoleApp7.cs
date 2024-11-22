using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Engineer:Person
    {
        protected string Specialization { get; set; }
        public Engineer():base()
        {
            Specialization = "NotSpecialised";
        }
        public Engineer(string Nam,int divize,string special) : base(Nam, divize)
        {
            Specialization = special;
        }
        public new void Show()
        {
            base.Show();
            Console.WriteLine($"   Специализация: {Specialization}");
        }
    }
}
