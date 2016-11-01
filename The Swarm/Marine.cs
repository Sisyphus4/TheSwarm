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
    class Marine:Unit
    {
        public double t2 { get; set; }            //параметр движения
        public Marine(Canvas canvas, double x, double y):base(canvas, x, y)
        {
            hp = 300;
            damage = 5;
        }
        public override void Draw()
        {
            img.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Marine.png"));
            base.Draw();
        }
        public int FindTarget(List<Zergling> zerglings)
        {
            int min = 0;
            for (int i = 0; i < zerglings.Count(); i++)
            {
                if (Math.Sqrt(Math.Pow(zerglings[min].x - x, 2) + Math.Pow(zerglings[min].y - y, 2)) > Math.Sqrt(Math.Pow(zerglings[i].x - x, 2) + Math.Pow(zerglings[i].y - y, 2)))
                    min = i;
            }
            return min;
        }
        public void MoveToTarget(double px, double py, double lx, double ly)
        {
            if (Math.Sqrt(Math.Pow(lx - x, 2) + Math.Pow(ly - y, 2)) > 10)
            {
                x = px + (lx - px) * t2;
                y = py + (ly - py) * t2;
                t2 += 0.002;
            }
        }
        public void MoveToTarget(List<Zergling> zerglings, double px, double py, int i)
        {
            if (Math.Sqrt(Math.Pow(zerglings[i].x - x, 2) + Math.Pow(zerglings[i].y - y, 2)) > 10)
            {
                x = px + (zerglings[i].x - px) * t2;
                y = py + (zerglings[i].y - py) * t2;
                t2 += 0.002;
            }
        }
    }
}
