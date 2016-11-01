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
    class Pool:Building
    {
        public Button createZergling { get; set; }
        public Pool(Canvas canvas, int x, int y) : base(canvas, x, y) { }
        public override void Draw(Game game)
        {
            img.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Pool.png"));
            img.Height = 240;
            img.Width = 170;
            Image img2 = new Image();           //Создание и отрисовка Кнопки
            img2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Zergling.png"));
            img2.Height = 40;
            img2.Width = 40;
            Button createZergling = new Button();  
            createZergling.Click += game.createZergling_Click; //Событие для производства дрона
            createZergling.Content = img2;
            Canvas.SetLeft(createZergling, x+65);
            Canvas.SetTop(createZergling, y+100);
            Canvas.SetZIndex(createZergling, 1);
            canvas.Children.Add(createZergling);
            base.Draw(game);
        }
    }
    
}
