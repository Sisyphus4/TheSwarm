using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;

namespace The_Swarm
{
    class Zergling : Unit
    {

        public double t1 { get; set; }            //параметр движения
        public double t2 { get; set; }            //параметр движения
        public bool move { get; set; }           //Флаг движения
        Random rnd = new Random();
        public double rx { get; set; }
        public double ry { get; set; }
        public Zergling(Canvas canvas, double x, double y)
            : base(canvas, x, y)
        {
            hp = 300;
            damage = 5;
            t1 = 0;
            rx = rnd.Next(600) + 400;
            ry = rnd.Next(400) + 100;
            move = true;
        }
        public override void Draw()
        {
            img.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Zergling.png"));
            base.Draw();
        }
        public void Move(double px, double py)
        {
            if (move)
            {
                x = px + (rx - px) * t1;
                y = py + (ry - py) * t1;
                t1+=0.002;
                if (Math.Sqrt(Math.Pow(rx-x,2)+Math.Pow(ry-y,2))<10)
                {
                    move=false;
                }
            }
        }
        public int FindTarget(List<Marine> marines)
        {
            int min = 0;
            for (int i = 0; i < marines.Count(); i++)
            { 
                if (Math.Sqrt(Math.Pow(marines[min].x - x, 2) + Math.Pow(marines[min].y - y, 2)) > Math.Sqrt(Math.Pow(marines[i].x - x, 2) + Math.Pow(marines[i].y - y, 2)))
                    min = i;
            }
            return min;
        }
        public void MoveToTarget(List<Marine> marines, double px, double py, int i)
        {
            if (Math.Sqrt(Math.Pow(marines[i].x - x, 2) + Math.Pow(marines[i].y - y, 2)) >10 && !move)
            {
                x = px + (marines[i].x - px) * t2;
                y = py + (marines[i].y - py) * t2;
                t2 += 0.002;
            }
        }
    }
}
