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

namespace The_Swarm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            Canvas canva = new Canvas();
            canvas.Height = m.Height-40;
            canvas.Width = m.Width-13;
            Game game = new Game(canvas);
            game.Start();
        }
        /*Путь к классам
         * передача в метод
         * аудио
         * хелсбары
         * условия победы/выигрыша
         * память или время
         * прожектайлы*/
    }
}
