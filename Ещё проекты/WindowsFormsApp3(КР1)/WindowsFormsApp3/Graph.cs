using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public delegate void EventHandler(int num);
    public class Graph
    {
        static Random rond = new Random();
        string Name;                       //Название графа
        public List <GraphPoint> Points;   //Коллекция элементов-вершин графа
        public event EventHandler ChangedGraph;
        public virtual void OnChangedGraph(int num)
        {
            if (ChangedGraph != null)
                ChangedGraph(num);
        }
        public Graph(int Num)
        {
            Name = "Стандартное имя графа";
            Points = new List<GraphPoint>(Num);
            List<int> mas = new List<int>(Num);
            for (int i = 0; i < Num; i++)
            {
                mas.Add(1);
                Points.Add(new GraphPoint(Num));
            }
            for(int i=0;i<Num;i++)
            {
                Points[i].Distance=new List<int> (mas);
            }
            for (int j = 0; j < mas.Count; j++)
            {
                Points[j].Distance[j] = 0;
            }
            OnChangedGraph(Num);
        }
        public Graph(int Num, string name)
        {
            Name = name;
            Points = new List<GraphPoint>(Num);
            List<int> mas = new List<int>(Num);
            for (int i = 1; i < mas.Capacity; i++)
            {
                mas.Add(1);
                Points.Add(new GraphPoint(Num));
            }
            for (int i = 0; i < Points.Capacity - 1; i++)
            {
                Points[i] = new GraphPoint(i, mas);
            }
            OnChangedGraph(Num);
        }
        public void Show()
        {
            for (int i=0;i<Points.Capacity;i++)
            {
                Console.Write($"{i} ");
                Points[i].ShowConnections();
                Console.WriteLine();
            }
        }
        public void AddPoint()
        {
            for (int i=0;i<Points.Count;i++)
            {
                Points[i].Distance.Add(1);
            }
            Points.Add(new GraphPoint(Points.Count+1));
            for (int i=0;i<Points.Count;i++)
            {
                Points[Points.Count - 1].Distance.Add(1);
            }
            Points[Points.Count - 1].Distance[Points.Count-1] = 0;
            OnChangedGraph(Points.Count);
        }
        public void AddPoint(List<int> Dist)
        {
            Points.Add(new GraphPoint(Points.Count, Dist));
            for (int i=0;i<Dist.Count-1;i++)
            {
                Points[i].Distance.Add(Dist[i]);
            }
            OnChangedGraph(Points.Count);
        }
        public void DeletePoint(int PointName)
        {
            try
            {
                Points.RemoveAt(PointName-1);
                for (int i = 0; i < Points.Count; i++)
                {
                    Points[i].Distance.RemoveAt(PointName-1);
                }
                ChangedGraph(PointName);
            }
            catch
            { }
        }
        public bool DeletePoint(GraphPoint Point)
        {
            bool buf;
            buf=Points.Remove(Point);
            if (buf)
            {
                for (int i = 0; i < Points.Count; i++)
                {
                    Points[i].Distance.RemoveAt(Point.Name-1);
                }
                return true;
            }
            return false;
        }
        public void RepairNames(int num)
        {
            for(int i=1;i<=Points.Count;i++)
            {
                Points[i - 1].Name = i;
            }
        }
        public void ChangeDistance(int i,int j,int distance)
        {
            if (i != j && i >= 0 && j >= 0)
            {
                Points[i].Distance[j] = distance;
                Points[j].Distance[i] = distance;
            }
        }
        public List<int> EnumerationSolve()
        {
            if (Points.Count > 2)
            {
                List<int> graf = new List<int>(Points.Count);
                graf.Add(1);
                List<int> Unusedpoints = new List<int>();
                for (int i = 1; i <= Points.Count; i++)
                {
                    if (i != 1)
                    {
                        graf.Add(i);
                        Unusedpoints.Add(i);
                    }
                }
                graf.Add(1);
                List<int> Res = new List<int>(Points.Count);
                Res.Add(1);
                EnumerateGraf(ref graf, Unusedpoints, Res);
                return graf;
            }
            return null;
        }
        public void EnumerateGraf(ref List<int> res, List<int> UnusedPoints, List<int> result)
        {
            int PointsLeft = UnusedPoints.Count;
            for (int i = 0; i < PointsLeft; i++)
            {
                List<int> resul = new List<int>(result);
                resul.Add(UnusedPoints[i]);
                List<int> UnusedPointsCopy = new List<int>(UnusedPoints);
                UnusedPointsCopy.Remove(UnusedPointsCopy[i]);
                if (UnusedPointsCopy.Count > 0)
                    EnumerateGraf(ref res, UnusedPointsCopy, new List<int>(resul));
                if (UnusedPointsCopy.Count == 0)
                {
                    resul.Add(1);
                    if (EstimateLength(resul) < EstimateLength(res))
                        res = resul;
                }
            }
        }
        public int EstimateLength(List<int> res)
        {
            int Length = 0;
            for (int i = 0; i < res.Count - 1; i++)
            {
                int pos1 = res[i + 1];
                int pos2 = res[i];
                Length += Points[pos2 - 1].Distance[pos1 - 1];
            }
            return Length;
        }
        public override bool Equals(object obj)
        {
            if (obj is Graph)
            {
                Graph g = (Graph)obj;
                return g.Name == this.Name && g.Points == this.Points;
            }
            else
                return false;
        }
        public void AntsAlgoritmSolve(out List<int> res, int Iters, int AntsNum, List<int> AntsPos, int Feromon, float FeromonInc, float FeromonChange, float FeromonCriterea, float LengthCritirea)
        {
            OnChangedGraph(Points.Count);
            int min = int.MaxValue;
            List<int> AntsStartPos = new List<int>(AntsPos);
            res = new List<int>();
            List<List<double>> FeromonAmount = new List<List<double>>(Points.Count);
            for (int i = 0; i < Points.Count; i++)
            {                                                                 //Инициализация стартового феромона
                FeromonAmount.Add(new List<double>());
                for (int j = 0; j < Points.Count; j++)
                {
                    FeromonAmount[i].Add(Feromon);
                }
            }
            for (int i = 0; i < Iters; i++)
            {
                List<List<int>> grafs = new List<List<int>>(AntsNum);
                for (int j = 0; j < AntsNum; j++)
                {
                    grafs.Add(new List<int>());
                    grafs[j].Add(AntsStartPos[j]);                                  //Инициализация массива графов муравьёв начальными позициями муравьё
                }
                List<List<int>> UnusedPoints = new List<List<int>>(AntsPos.Count);//Непройденные каждым муравьём вершины
                for (int j = 0; j < grafs.Count; j++)
                {
                    UnusedPoints.Add(new List<int>());
                    for (int k = 0; k < Points.Count; k++)
                    {
                        if (grafs[j].Contains(Points[k].Name) == false)
                        {
                            UnusedPoints[j].Add(Points[k].Name);
                        }
                    }
                }
                for (int j = 0; j < Points.Count - 1; j++)                                  //обход графа муравьями по одной вершине
                {
                    for (int o = 0; o < AntsNum; o++)                             //Движение муравьёв
                    {
                        List<float> ChanceMas = new List<float>(UnusedPoints.Count);                 //Массив шансов муравьёв на переход в ту или иную вершину
                        float Chances = 0;                                                       //
                        for (int In = 0; In < UnusedPoints[o].Count; In++)
                        {
                            ChanceMas.Add(0);
                            float lencrit = (float)Math.Pow(Points[AntsPos[o] - 1].Distance[UnusedPoints[o][In] - 1], LengthCritirea);
                            float Fercrit = (float)Math.Pow(FeromonAmount[AntsPos[o] - 1][UnusedPoints[o][In] - 1], FeromonCriterea);
                            ChanceMas[In] = Fercrit / lencrit;
                            Chances += ChanceMas[In];                                              //считается сумма этих веростностей
                        }                                                                         //
                        float chances = Chances;                                                 //
                        int signs = 0;                                                            //
                        while (chances % 1 > 0)                                                   //
                        {                                                                         //
                            chances = chances * 10;                                               //Преобразования суммы для генерации с помощью ДСЧ выбора муравьёв
                            signs++;                                                              //
                        }                                                                         //
                        float choice = (float)(rond.Next(0, (int)chances) / Math.Pow(10, signs));//Генерация выбора муравья
                        float SeekChoiceLine = 0;                                                //
                        int ChoicePoint = 0;                                                      //
                        for (int c = 0; c < ChanceMas.Count && SeekChoiceLine < choice; c++)      //
                        {                                                                         //
                            SeekChoiceLine += ChanceMas[c];                                       //Перебор, для нахождения точки, выбранной муравьём. Исходя из значения сгенерированного числа
                            if (SeekChoiceLine < choice)                                          //
                                ChoicePoint++;                                                    //
                        }                                                                         //
                        grafs[o].Add( UnusedPoints[o][ChoicePoint]);                      //Добавление этой точки к строке-построенному муравьём графу
                        AntsPos[o] = UnusedPoints[o][ChoicePoint];                                                 //Меняем позицию муравь
                        UnusedPoints[o].Remove(UnusedPoints[o][ChoicePoint]);                           //удаление выбранной точки из массива неиспользованных точек
                    }
                    for (int k = 0; k < AntsNum; k++)
                    {
                        FeromonAmount[int.Parse((grafs[k][grafs[k].Count - 2]).ToString()) - 1][int.Parse((grafs[k][grafs[k].Count - 1]).ToString()) - 1] += FeromonInc;
                        FeromonAmount[int.Parse((grafs[k][grafs[k].Count - 1]).ToString()) - 1][int.Parse((grafs[k][grafs[k].Count - 2]).ToString()) - 1] += FeromonInc;
                    }
                }
                for (int j = 0; j < grafs.Count; j++)
                {
                    grafs[j].Add(AntsStartPos[j]);
                    if (EstimateLength(grafs[j]) < min)
                    {
                        min = (int)EstimateLength(grafs[j]);
                        res = grafs[j];
                    }
                }
                for (int j = 0; j < Points.Count; j++)
                {
                    for (int k = 0; k < Points.Count; k++)
                    {                                                                   //Изменение феромона
                        FeromonAmount[j][k] = FeromonAmount[j][k] * (1 - FeromonChange);
                    }
                }
                for (int j=0;j<AntsNum;j++)
                {
                    AntsPos[j] = AntsStartPos[j];
                }
            }
        }
    }
}
