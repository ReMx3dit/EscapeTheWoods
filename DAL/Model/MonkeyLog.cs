using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class MonkeyLog
    {
        public int Id { get; set; }
        public int MonkeyId { get; set; }
        public string MonkeyName { get; set; }
        public int WoodId { get; set; }
        public int SequenceNumber { get; set; }
        public int TreeId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
