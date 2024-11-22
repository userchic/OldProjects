using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class GraphPoint
    {
        public int Name;//название точки(число)
        public List<int> Distance;// расстояние до каждой точки графа
        //public GraphPoint()
        //{
        //    Name = null;
        //    Distance = new List<int>();
        //}
        public GraphPoint(int name)
        {
            Name = name;
            Distance = new List<int>(name);
        }
        public GraphPoint(int name,List<int>Distances )
        {
            Name = name;
            Distance = new List<int>(Distances);
        }
        public override bool Equals(object obj)
        {
            if (obj is GraphPoint)
            {
                GraphPoint gg = (GraphPoint)obj;
                int flag = 0;
                if (this.Distance.Count == gg.Distance.Count)
                {
                    flag = 1;
                    for (int i = 0; i < gg.Distance.Count; i++)
                    {
                        if (this.Distance[i] == gg.Distance[i]) ;
                        else
                            flag = 0;
                    }
                }
                return flag == 1;
            }
            else
                return false;
        }
        public void ShowConnections()
        {
            foreach (int range in Distance)
            {
                try
                {
                    Console.Write(range);
                }
                catch
                {
                    Console.Write("null");
                }
            }
        }
    }
}
