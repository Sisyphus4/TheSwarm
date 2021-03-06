﻿using System;
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
    abstract class Unit
    {
        protected Image img = new Image();
        public Canvas canvas { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public int hp { get; set; }
        public int damage { get; set; }
        public Unit(Canvas canvas, double x, double y)
        {
            this.x = x;
            this.y = y;
            this.canvas = canvas;
        }
        public virtual void Draw()
        {
            Canvas.SetLeft(img, x);
            Canvas.SetTop(img, y);
            img.Height = 70;
            img.Width = 50;
            canvas.Children.Add(img);
        }
        public void Clear()
        {
            canvas.Children.Remove(img);
        }

    }
}
