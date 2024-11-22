using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp6
{
    public class Engineer : Person, IInit, IComparable, ICloneable
    {
        public string Specialization { get; set; }
        public Engineer():base()
        {
            Specialization = "NotSpecialised";
        }
        public Engineer(string Nam,int divize,string special) : base(Nam, divize)
        {
            Specialization = special;
        }
        public override void Show()
        {
            Console.WriteLine();
            base.Show();
            Console.WriteLine($"   Специализация: {Specialization}");
            Console.WriteLine("------------------------------------------------------------");
        }
        public Person BasePerson
        {
            get
            {
                return new Person(Name, Division);//возвращает объект базового класса
            }
        }

        public override object Init()
        {
            string[] specialization = { "Ремонт техники", "Разминирование", "Установка минных полей"};
            Person p = (Person)base.Init();
            Engineer e = new Engineer(p.Name, p.Division, specialization[rnd.Next(specialization.Length)]);
            return e;
        }
        public override int CompareTo(object obj)
        {
            Person temp = (Person)obj;
            if ((String.Compare(this.Name, temp.Name) > 0) & (String.Compare(this.Division.ToString(), temp.Division.ToString()) > 0)) return 1;
            if ((String.Compare(this.Name, temp.Name) < 0) & (String.Compare(this.Division.ToString(), temp.Division.ToString()) < 0)) return -1;
            else
            return 0;
        }
        public override object Clone()
        {
            return new Engineer(this.Name, this.division, this.Specialization);
        }
        public override Person ShallowCopy()
        {
            return (Engineer)this.MemberwiseClone(); ;
        }
        public override bool Equals(object obj)
        {
            if (obj is Engineer)
            {
                Engineer e = (Engineer)obj;
                return (this.Name == e.Name && this.Division == e.Division);
            }
            else return false;
        }
        public override string ToString()
        {
            return this.Name + ", "+ this.Division +", " + this.Specialization;
        }
        public override int GetHashCode()
        {
            int code= base.GetHashCode();
            foreach (char c in Specialization)
                code += 1;
            return code;
        }
    }
}
