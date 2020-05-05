using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DBController
    {
        public void AddActionLog(ActionLog x)
        {
            using (var context = new MonkeyDbContext())
            {
                context.ActionLogs.Add(x);
                context.SaveChanges();
            }
        }
        public void AddTreeLog(TreeLog x)
        {
            using (var context = new MonkeyDbContext())
            {
                context.TreeLogs.Add(x);
                context.SaveChanges();
            }
        }
        public void AddMonkeyLog(MonkeyLog x)
        {
            using (var context = new MonkeyDbContext())
            {
                context.MonkeyLogs.Add(x);
                context.SaveChanges();
            }
        }
        public int GetLastWoodId()
        {
            int lastId = 0;
            using (var context = new MonkeyDbContext())
            {
                lastId = context.ActionLogs.ToList().Last().WoodId;
            }
            return lastId;
        }
        public int GetLastMonkeyId()
        {
            int lastId = 0;
            using (var context = new MonkeyDbContext())
            {
                lastId = context.ActionLogs.Select(x => x.MonkeyId).ToList().Max();
            }
            return lastId;
        }
    }
}
