using System;
using BAL.Model;
using BAL;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Title();
            menu.Main();
        }
    }
}
