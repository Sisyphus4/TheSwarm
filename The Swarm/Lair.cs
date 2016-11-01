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
    class Lair:Building
    {

        public Button createDrone { get; set; }
        public Lair(Canvas canvas, int x, int y, int hp) : base(canvas, x, y) 
        {
            this.hp = hp;
        }
        public override void Draw(Game game)
        {
            img.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Lair.png"));
            img.Height = 240;
            img.Width = 170;
            Image img2 = new Image();           //Создание и отрисовка Кнопки
            img2.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\Drone.png"));
            img2.Height = 40;
            img2.Width = 40;
            Button createDrone = new Button();  
            createDrone.Click += game.createDrone_Click; //Событие для производства дрона
            createDrone.Content = img2;
            Canvas.SetLeft(createDrone, x+65);
            Canvas.SetTop(createDrone, y+100);
            Canvas.SetZIndex(createDrone, 1);
            canvas.Children.Add(createDrone);
            base.Draw(game);
        }
    }
}
