using System;
using BAL.Model;
using BAL;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Title();
            await Task.Run(()=>menu.Main());
            Console.ReadLine();
        }
    }
}
