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
    static class Resources
    {
        static Label mushvalue = new Label();
        static Canvas respanel = new Canvas();
        public static void InitRes(int mushres, Canvas canvas)
        {
            #region Создание канвы
            respanel.Background = Brushes.Coral;
            Canvas.SetLeft(respanel, 200);
            Canvas.SetTop(respanel, 0);
            respanel.Height = 50;
            respanel.Width = 800;
            canvas.Children.Add(respanel);
            #endregion
            #region Отрисовка
            Image img = new Image();
            Canvas.SetLeft(img, 20);
            Canvas.SetTop(img, 5);
            img.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\images\\mushres.png"));
            img.Height = 40;
            img.Width = 40;
            respanel.Children.Add(img);
            #endregion
            mushvalue.FontSize = 25;
            Canvas.SetLeft(mushvalue, 57);
            Canvas.SetTop(mushvalue, 5);
            mushvalue.Height = 70;
            mushvalue.Width = 100;
            DrawMushRes(mushres);
        }
        public static void DrawMushRes(int mushres)  //Отображение ресурса
        {
            mushvalue.Content = mushres;
            respanel.Children.Remove(mushvalue);
            respanel.Children.Add(mushvalue);
        }
    }
}
