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


namespace The_Swarm
{
    class Mushroom:Building
    {
        public Mushroom(Canvas canvas, int x, int y):base(canvas, x, y)
        {
        }
        public override void Draw(Game game)
        {
            img.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Mushroom.png"));
            img.Height = 200;
            img.Width = 130;
            base.Draw(game);
        }
    }
}
