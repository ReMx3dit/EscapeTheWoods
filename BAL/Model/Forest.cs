using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Model
{
    public class Forest
    {
        public Forest(int id, int amountOfTrees, int amountOfMonkeys)
        {
            Id = id;
            Xmax = (int)(amountOfTrees *10); // 10 times the amount of trees is the X and Y size
            Ymax = Xmax;
            MonkeyCounter = Global.DB.GetLastMonkeyId();
            GenerateTrees(amountOfTrees);
            GenerateMonkeys(amountOfMonkeys);
        }
        private List<string> NameList = new List<string>
        {
            "Robin",
            "Jo",
            "Bart",
            "Toon",
            "Evi",
            "Tamara",
            "Tom",
            "Marc",
            "Jeroen",
            "Sofie",
            "Silke",
            "Lien",
            "Tina",
            "Kevin",
            "Nienke",
            "Aline",
            "Naomi",
            "Peter",
            "Geert",
            "Antoine",
            "Monique",
            "Mohammed"
        };
        public int Id { get; set; }
        public int Xmax { get; set; }
        public int Ymax { get; set; }
        public int MonkeyCounter { get; set; }
        public List<Tree> Trees { get; set; } = new List<Tree>();
        public List<Monkey> Monkeys { get; set; } = new List<Monkey>();
        public List<string> TextLogs { get; set; } = new List<string>();
        public Image Bitmap { get; set; }

        private void GenerateTrees(int amountOfTrees)
        {
            int treeCounter = 0;
            Random r = new Random();
            for (int i = 0; i < amountOfTrees; i++)
            {
                int random1 = r.Next(1, Xmax - 1);
                int random2 = r.Next(1, Ymax - 1);
                Tree newTree = new Tree { Id = treeCounter++, X = random1, Y = random2 };

                if (!Trees.Contains(newTree))
                {
                    Task.Run(() => Global.Log.TreeLog(this, newTree));
                    Console.WriteLine($"[{Id}]: Creating tree at {newTree.X},{newTree.Y} with ID: {newTree.Id}");
                    Trees.Add(newTree);
                }
                else
                    i--;
            }
            Console.WriteLine($"[{Id}]: Generated forest with {Trees.Count} amount of trees with ID: {Id}");
            Global.Log.CreateBitmap(this);
        }
        private void GenerateMonkeys(int amountOfMonkeys)
        {
            Random r = new Random();
            if (Id % 2 == 0)
                NameList.Reverse();
            for (int i = 1; i < amountOfMonkeys + 1; i++)
            {
                int rand = r.Next(Trees.Count - 1);
                Monkey m = new Monkey(MonkeyCounter++, NameList[i]);
                if (this.Trees[rand].Monkey != null)
                {
                    i--;
                }
                else
                {
                    m.VisitedTrees.Add(m.Hops, Trees[rand]);
                    Trees[rand].Monkey = m;
                    Monkeys.Add(m);
                    Console.WriteLine($"[{Id}]: Placing new monkey {m.Naam} with ID {m.Id} in Tree: {Trees[rand].Id}");
                    Global.Log.WriteMonkeyToImage(this, Trees[rand]);
                }
            }
        }

        public Tree GetClosestTree(Tree t, Monkey m)
        {
            double nearest = Xmax;
            Tree nearestTree = null;
            for (int i = 0; i < Trees.Count; i++)
            {
                if (Trees[i] != t && !m.VisitedTrees.ContainsValue(Trees[i]))
                {
                    if (GetDistance(t, Trees[i]) < nearest)
                    {
                        nearest = GetDistance(t, Trees[i]);
                        nearestTree = Trees[i];
                    }
                }
            }
            return nearestTree;
        }

        public double GetDistance(Tree tree1, Tree tree2)
        {
            return Math.Sqrt(Math.Pow(tree1.X - tree2.X, 2) + Math.Pow(tree1.Y - tree2.Y, 2));
        }

        public double GetDistanceToBorder(Tree t)
        {
            double distance = (new List<double>()
            {
                Xmax - t.X,
                Ymax - t.Y,
                t.X - 0,
                t.Y - 0
            }).Min();
            return distance;
        }
    }
}
