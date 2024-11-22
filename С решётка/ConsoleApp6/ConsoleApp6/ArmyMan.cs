using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class ArmyMan :Person, IInit, IComparable, ICloneable
    {
        protected int workexperience;
        public int WorkExperience
        {
            get
            {
                return workexperience;
            }
            set
            {
                if (value >= 0) 
                    workexperience = value;
                else
                {
                    Console.WriteLine("Error!");
                    workexperience = 0;
                }
            }
        }
        public Person BasePerson
        {
            get
            {
                return new Person(Name, Division);//возвращает объект базового класса
            }
        }
        public ArmyMan() : base()
        {
            WorkExperience = 0;
        }
        public ArmyMan(string Nam, int divize, int exp) : base(Nam, divize)
        {
            WorkExperience = exp;
        }
        public override void Show()
        {
            Console.WriteLine();
            base.Show();
            Console.WriteLine($"   Стаж: {workexperience}");
            Console.WriteLine("------------------------------------------------------------");
        }
        public override object Init()
        {
            Person p = (Person)base.Init();
            ArmyMan a = new ArmyMan(p.Name, p.Division, rnd.Next(100));
            return a;
        }
        public override int CompareTo(object obj)
        {
            Person temp = (Person)obj;
            if (String.Compare(this.Name, temp.Name) > 0) return 1;
            if (String.Compare(this.Name, temp.Name) < 0) return -1;
            return 0;
        }
        public override object Clone()
        {
            return new ArmyMan("Клон" + this.Name, this.division, this.workexperience);
        }
        public override Person ShallowCopy()
        {
            return (ArmyMan)this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            if (obj is ArmyMan)
            {
                ArmyMan a = (ArmyMan)obj;
                return this.Name == a.Name && this.division == a.division && this.WorkExperience == a.WorkExperience;
            }
            else return false;
        }
    }
}
