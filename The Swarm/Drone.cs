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
    class Drone : Unit
    {
        public bool side { get; set; }                      //Переменная, отвечающая за направление движения
        public Drone(Canvas canvas, double x, double y):base(canvas, x, y)
        {
            hp = 30;
            side = false;               //пойдёт в сторону гриба
        }
        public override void Draw()
        {
            img.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Drone.png"));
            base.Draw();
        }
        public void Move(double lx, double ly, double mx, double my)
        {

            if (side)                   //Идём в сторону Лейра
            {
                x += 5;
                y = (x - mx) / (lx - mx) * (ly - my) + my;
                if (x - lx == 0 && y - ly == 0)
                {
                    side = false; 
                }
            }
            else                        //Идём в сторону Гриба
            {
                x -= 5;
                y = (x - mx) / (lx-mx) * (ly-my) + my;
                if (x - mx == 0 && y - my == 0)
                {
                    side = true;
                }
            }
        }
    }
}
