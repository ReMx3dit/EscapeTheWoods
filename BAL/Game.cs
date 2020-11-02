using BAL.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAL
{
    public class Game
    {
        public Game()
        {
            ForestCounter = Global.DB.GetLastWoodId() + 1;
        }
        public int ForestCounter { get; set; }
        public async Task<bool> PlayGames(int amountOfGames, int amountOfTrees, int amountOfMonkeys)
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < amountOfGames; i++)
            {
                Task t = new Task(()=>PlaySingleGame(amountOfTrees, amountOfMonkeys));
                tasks.Add(t);
            }
            foreach(Task t in tasks)
            {
                t.Start();
            }
            int postfilecount = GetFileCount();
            while (postfilecount != amountOfGames)
            {
                Thread.Sleep(1000);
                postfilecount = GetFileCount();
            }
            await Task.WhenAll(Global.Log.TaskList);
            return true;
        }
        public void PlaySingleGame(int amountOfTrees, int amountOfMonkeys)
        {
            Forest f = new Forest(ForestCounter++, amountOfTrees, amountOfMonkeys);
            for (int i = 0; i < f.Monkeys.Count; i++)
            {
                Monkey m = f.Monkeys[i];
                m.JumpToEdge(f);
            }
            Global.Log.WriteImage(f.Id, f.Bitmap);
            Global.Log.SaveTextLog(f);
        }
        public int GetFileCount()
        {
            DirectoryInfo di = new DirectoryInfo(Global.Log.PathToDocs);
            int fileCount = di.GetFiles().Where(x => x.Extension == ".jpg").Count();
            return fileCount;
        }
    }
}
