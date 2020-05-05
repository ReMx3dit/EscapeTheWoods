using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class ActionLog
    {
        public int Id { get; set; }
        public int WoodId { get; set; }
        public int MonkeyId { get; set; }
        public string Message { get; set; }
    }
}
