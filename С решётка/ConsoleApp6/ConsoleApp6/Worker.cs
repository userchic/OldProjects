using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Worker :Person, IInit, IComparable, ICloneable
    {
       // protected string profession;
        public string Profession
        { get; set; }
        public Worker() : base()
        {
            Profession = "Not professional";
        }
        public Worker(string Nam,int divi,string pro) : base(Nam,divi)
        {
            Profession = pro;
        }
        public override void Show()
        {
            Console.WriteLine();
            base.Show();
            Console.WriteLine($"   Профессия: {Profession}");
            Console.WriteLine("------------------------------------------------------------");
        }
        public override object Init()
        {
            string[] professionalization = { "Рыть траншеи", "Переводчик", "Ремонт инфраструктуры"};
            Person p = (Person)base.Init();
            Worker w = new Worker(p.Name, p.Division, professionalization[rnd.Next(professionalization.Length)]);
            return w;
        }
        public override object Clone()
        {
            return new Worker("Клон" + this.Name, this.division, this.Profession);
        }
        public override Person ShallowCopy()
        {
            return (Worker)this.MemberwiseClone();
        }
        public override int CompareTo(object obj)
        {
            Person temp = (Person)obj;
            if (String.Compare(this.Name, temp.Name) > 0) return 1;
            if (String.Compare(this.Name, temp.Name) < 0) return -1;
            return 0;
        }
        public override bool Equals(object obj)
        {
            if (obj is Worker)
            {
                Worker w = (Worker)obj;
                return this.Name == w.Name && this.division == w.division && this.Profession == w.Profession;
            }
            else return false;
        }
        public Person BasePerson
        {
            get
            {
                return new Person(Name, Division);//возвращает объект базового класса
            }
        }
    }
}
