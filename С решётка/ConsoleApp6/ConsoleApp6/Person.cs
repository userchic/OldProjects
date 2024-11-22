using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Person : IInit, IComparable, ICloneable
    {
        protected static Random rnd = new Random();
        public string Name { get; set; }
        protected int division;
        public int Division
        {
            get 
            {
                return division;
            }
            set
            {
                while (value <= 0)
                {
                    Console.WriteLine("Ошибка, номер подразделения не может быть ненатуральным числом");
                    value = Console.Read();
                }
                division = value;
            }
        }
        public Person()
        {
            division = 0;
            Name = "Anonimous";
        }
        public Person(string Nam,int divis)
        {
            Division = divis;
            Name = Nam;
        }
        public virtual void Show()
        {
            Console.WriteLine($" - Имя: {Name} Подразделение {division}");
            Console.WriteLine("---------------------------------------------------");
        }

        public virtual object Init()
        {
            string[]Names= { "Вася", "Ииосиф", "Дурдынев", "Чипполино" , "Василий", "Николай", "Александр", "Петя", "Васёк", "Иннокентий", "Филипп", "Карл", "А.П.Пушкин", "Л.Н.Толстой", "А.С.Миронов", "С.А.Трунин" };
            Person p = new Person(Names[rnd.Next(Names.Length)], rnd.Next(1,100000000));
            return p;
        }
        public virtual int CompareTo(object obj)
        {
            Person temp = (Person)obj;
            return String.Compare(this.ToString(),temp.ToString());
            //if ((String.Compare(this.Name, temp.Name) > 0) & (String.Compare(this.Division.ToString(), temp.Division.ToString()) > 0)) return 1;
            //if ((String.Compare(this.Name, temp.Name) < 0) & (String.Compare(this.Division.ToString(), temp.Division.ToString()) < 0)) return -1;
            //else
            //return 0;
        }
        public virtual object Clone()
        {
            return new Person("Клон" + this.Name, this.division);
        }
        public virtual Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                Person p = (Person)obj;
                return (this.Name == p.Name && this.Division == p.Division);
            }
            else return false;
        }
        public override string ToString()
        {
            return this.Name + ", подразделение"+ this.Division;
        }
        public override int GetHashCode()
        {
            int code=0;
            foreach (char c in Name)
                code += 1;
            code += Division;
            return code;
        }
    }
}
