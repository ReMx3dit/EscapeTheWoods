using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAL.Model
{
    public class Monkey
    {
        public Monkey(int id, string naam)
        {
            Id = id;
            Naam = naam;
        }
        public int Id { get; set; }
        public string Naam { get; set; }
        public int Hops { get; set; } = 0;
        public SortedList<int, Tree> VisitedTrees { get; set; } = new SortedList<int, Tree>();
        public SortedList<int, Tree> CalculatedPath { get; set; } = new SortedList<int, Tree>();
        public bool JumpToEdge(Forest f)
        {
            do
            {
                Tree closestTree = f.GetClosestTree(VisitedTrees.Last().Value, this);
                double distanceToBorder = f.GetDistanceToBorder(VisitedTrees.Last().Value);
                double distanceToClosestTree = f.GetDistance(VisitedTrees.Last().Value, closestTree);
                if (distanceToBorder < distanceToClosestTree)
                {
                    CalculatedPath.Add(++Hops, new Tree(9696));

                    // Logging
                    Console.WriteLine($"[{f.Id}]: Monkey {Naam} jumps out of the forest");
                    Global.Log.TaskList.Add(Task.Run(() => Global.Log.ActionLog(f.Id, this.Id, $"[{f.Id}]: Monkey {Naam} jumps out of the forest")));
                    f.TextLogs.Add($"[{f.Id}]: Monkey {Naam} jumps out of the forest");
                }
                else
                {
                    Tree prev = VisitedTrees[Hops];
                    CalculatedPath.Add(++Hops, closestTree);
                    VisitedTrees.Add(Hops, closestTree);

                    // Logging
                    Console.WriteLine($"[{f.Id}]: Monkey {Naam} jumps from {prev.Id} to {closestTree.Id} at {closestTree.X},{closestTree.Y}");
                    Global.Log.TaskList.Add(Task.Run(() => Global.Log.ActionLog(f.Id, this.Id, $"[{f.Id}]: Monkey {Naam} jumps from {prev.Id} to {closestTree.Id} at {closestTree.X},{closestTree.Y}")));
                    Global.Log.TaskList.Add(Task.Run(() => Global.Log.MonkeyLog(f, this, closestTree)));
                    f.TextLogs.Add($"[{f.Id}]: Monkey {Naam} jumps from {prev.Id} to {closestTree.Id} at {closestTree.X},{closestTree.Y}");
                    Global.Log.WriteMonkeyJump(f, prev, closestTree);
                }
            } while (CalculatedPath.Last().Value.Id != 9696);
            return true;
        }
    }
}
