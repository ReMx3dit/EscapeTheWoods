using BAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class Menu
    {
        private void DeleteOneLine()
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            Console.WriteLine("                                                 ");
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
        }
        public void Title()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("| ESCAPE THE WOODS |");
            Console.WriteLine();
            Console.WriteLine();
            Console.ResetColor();
        }
        public void Main()
        {
            int games;
            do
            {
                DeleteOneLine();
                Console.Write("Hoeveel spelletjes wenst u te spelen?: ");
            } while (!int.TryParse(Console.ReadLine(), out games) && games < 20 && games > 0);
            int trees;
            do
            {
                DeleteOneLine();
                Console.Write("Hoeveel bomen in het bos?: ");
            } while (!int.TryParse(Console.ReadLine(), out trees) && trees < 150 && trees > 10);
            int monkeys;
            do
            {
                DeleteOneLine();
                Console.Write("Hoeveel apen in het bos?: ");
            } while (!int.TryParse(Console.ReadLine(), out monkeys) && monkeys < 23 && monkeys > 0);
            DeleteOneLine();
            Footer(games, trees, monkeys);
        }

        private void Footer(int games, int trees, int monkeys)
        {
            Console.WriteLine($"We starten nu {games} spelletjes met {trees} bomen en {monkeys} apen.");
            Console.WriteLine("Van zodra alle spelletjes afgelopen zijn zal hieronder melding gegeven worden.");
            Console.WriteLine();
            Game game = new Game();
            if (game.PlayGames(games, trees, monkeys).Result)
            {
                Console.WriteLine("Alle spelletjes zijn klaar, de rapporten vind je in de Documenten map.");
                Console.WriteLine("Program ended, press any key to exit...");
                Console.ReadLine();
            }
        }
    }
}
