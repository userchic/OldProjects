using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class EnemyArmyMan : IInit, IComparable, ICloneable
    {
        Random rnd = new Random();
        public string Name { get; set; }
        public int enemyDivision;
        public int EnemyDivision
        {
            get
            {
                return enemyDivision;
            }
            set
            {
                while (value <= 0)
                {
                    Console.WriteLine("Ошибка, номер подразделения противника не может быть ненатуральным числом");
                    value = Console.Read();
                }
                enemyDivision = value;
            }
        }
        public EnemyArmyMan()
        {
            Name = "UnfriendlyAnonimous";
            enemyDivision = 0;
        }
        public EnemyArmyMan(string Nam,int Div)
        {
            Name = Nam;
            EnemyDivision = Div;
        }
        public object Init()
        {
            string[] Names = { "zombie", "spider", "Tank", "Marksman" };
            EnemyArmyMan ea = new EnemyArmyMan(Names[rnd.Next(0,Names.Length)], rnd.Next(1,100000));
            return ea;
        }
        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine($" - Имя: {Name} Подразделение противника {EnemyDivision}");
            Console.WriteLine("---------------------------------------------------");
        }
        public int CompareTo(object obj)
        {
            EnemyArmyMan temp = (EnemyArmyMan)obj;
            if (String.Compare(this.Name, temp.Name) > 0) return 1;
            if (String.Compare(this.Name, temp.Name) < 0) return -1;
            return 0;
        }
        public object Clone()
        {
            return new EnemyArmyMan("Клон" + this.Name, this.EnemyDivision);
        }
        public EnemyArmyMan ShallowCopy()
        {
            return (EnemyArmyMan)this.MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            if (obj is EnemyArmyMan)
            {
                EnemyArmyMan m = (EnemyArmyMan)obj;
                return this.Name == m.Name && this.EnemyDivision == m.EnemyDivision;
            }
            else return false;
        }
    }
}
