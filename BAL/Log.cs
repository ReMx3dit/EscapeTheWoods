using BAL.Model;
using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace BAL
{
    public class Log
    {
        public string PathToDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\EscapeFromTheForests";
        public List<Task> TaskList = new List<Task>();
        private int _scaling = 2;
        private int _thickness = 20;
        public Log()
        {
            DirectoryInfo dir = new DirectoryInfo(PathToDocs);
            if (!dir.Exists)
                dir.Create();

            foreach (FileInfo file in dir.GetFiles())
            {
                file.Delete();
            }
        }
        public void CreateBitmap(Forest f)
        {
            Console.WriteLine($"[{f.Id}]: Starting bitmap-writing for forest {f.Id}");
            Bitmap image = new Bitmap(f.Xmax * _scaling, f.Ymax * _scaling);
            Pen treePen = new Pen(Color.Green);
            Graphics g = Graphics.FromImage(image);
            foreach (Tree t in f.Trees)
            {
                g.DrawEllipse(treePen, t.X * _scaling, t.Y * _scaling, _thickness, _thickness);
            }
            f.Bitmap = image;
        }
        public void WriteMonkeyToImage(Forest f, Tree t)
        {
            Brush monkeyBrush = new SolidBrush(Color.White);
            Image thisImg = f.Bitmap;
            Graphics g = Graphics.FromImage(thisImg);
            g.FillEllipse(monkeyBrush, t.X * _scaling, t.Y * _scaling, _thickness, _thickness);
        }
        public void WriteMonkeyJump(Forest f, Tree t1, Tree t2)
        {
            Pen monkeyPen = new Pen(Color.White);
            Image thisImg = f.Bitmap;
            Graphics g = Graphics.FromImage(thisImg);
            g.DrawLine(monkeyPen,
                new Point { X = t1.X * _scaling + _thickness/2, Y = t1.Y * _scaling + _thickness/2 },
                new Point { X = t2.X * _scaling + _thickness/2, Y = t2.Y * _scaling + _thickness/2 });
        }

        public void WriteImage(int key, Image i)
        {
            i.Save(Path.Combine(PathToDocs, $"WoodMap_{key}.jpg"), ImageFormat.Jpeg); //Sometimes this doesnt work, why?!
        }

        public void ActionLog(int woodID, int monkeyID, string message)
        {
            Console.WriteLine($"Writing Log: {message}");
            Global.DB.AddActionLog(
                new ActionLog
                {
                    WoodId = woodID,
                    MonkeyId = monkeyID,
                    Message = message
                }
                );
        }
        public void MonkeyLog(Forest w, Monkey m, Tree t)
        {
            Console.WriteLine($"Writing MonkeyLog: {m.Id}, {m.Naam}");
            Global.DB.AddMonkeyLog(
                new MonkeyLog
                {
                    MonkeyId = m.Id,
                    MonkeyName = m.Naam,
                    WoodId = w.Id,
                    SequenceNumber = m.Hops,
                    TreeId = t.Id,
                    X = t.X,
                    Y = t.Y
                }
                );
        }
        public void TreeLog(Forest w, Tree t)
        {
            Console.WriteLine($"Writing TreeLog: Forest_{w.Id} Tree_{t.Id}");
            Global.DB.AddTreeLog(
                new TreeLog
                {
                    WoodId = w.Id,
                    TreeId = t.Id,
                    X = t.X,
                    Y = t.Y
                }
                );
        }
        public void SaveTextLog(Forest w)
        {
            Console.WriteLine($"Writing TextLog: Forest_{w.Id}");
            FileStream fs = new FileStream($"ForestLog_id_{w.Id}", FileMode.OpenOrCreate);
            using (StreamWriter writer = new StreamWriter(PathToDocs + $@"\ForestLog_id_{w.Id}.txt"))
            {
                foreach (string s in w.TextLogs)
                    writer.WriteLine(s);
            };
            fs.Close();
        }
    }
}
