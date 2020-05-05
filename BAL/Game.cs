using BAL.Model;
using DAL;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BAL
{
    public class Game
    {
        public Game()
        {
            ForestCounter = Global.DB.GetLastWoodId();
        }
        public int ForestCounter { get; set; }
        public void PlayGames(int amountOfGames, int amountOfTrees, int amountOfMonkeys)
        {
            for (int i = 0; i < amountOfGames; i++)
            {
                PlaySingleGame(amountOfTrees, amountOfMonkeys);
            }
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

    }
}
