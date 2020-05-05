using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Model
{
    public class Tree
    {
        public Tree()
        {

        }
        public Tree(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Monkey Monkey { get; set; }
    }
}
