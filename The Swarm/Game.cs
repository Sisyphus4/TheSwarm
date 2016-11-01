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
    class Game
    {
        DispatcherTimer GlobalTimer = new DispatcherTimer();
        DispatcherTimer BattleTimer = new DispatcherTimer();
        DispatcherTimer droneTimer = new DispatcherTimer();
        DispatcherTimer zerglingTimer = new DispatcherTimer();
        public int id { get; set; }  //счётчик для дронов
        public int iz { get; set; }  //счётчик для зерглингов
        public int iaz { get; set; } //счётчик для атаки зерглинов
        public int iam { get; set; } //счётчик для атаки маринов
        public int im { get; set; }  //счётчик для маринов
        List<Drone> drones = new List<Drone>();
        List<Zergling> zerglings = new List<Zergling>();
        List<Marine> marines = new List<Marine>();
        List<Mushroom> mushes = new List<Mushroom>();
        Random rnd = new Random();
        Canvas canvas;
        Lair lair;
        Pool pool;
        public int mushres { get; set; } //ресурс грибы

        public Game(Canvas canvas)
        {
            canvas.Background = Brushes.Bisque;
            this.canvas = canvas;
        }
        public void Start()
        {
            id = 0;
            lair = new Lair(canvas, 300, 150, 5000); //создание Логова
            lair.Draw(this);
            pool = new Pool(canvas, 300, 400); //создание Пула
            pool.Draw(this);
            mushes.Add(new Mushroom(canvas, 40, 10));
            mushes[0].Draw(this);   
            mushres = 12000;                //ресы
            Resources.InitRes(mushres, canvas);
            DroneWork();
            ZerglingMovements();
            EnemyAttack();
        }
        public void createDrone_Click(object sender, RoutedEventArgs e)  //Создание Дрона
        {
            if (mushres > 80)
            {
                drones.Add(new Drone(canvas, lair.x + 60, lair.y + 60));
                drones[id].Draw();
                id++;
                mushres -= 80;
                Resources.DrawMushRes(mushres);
            }
            else
            {
                System.Windows.MessageBox.Show("Нам нужно больше грибов");
            }
        }

        public void createZergling_Click(object sender, RoutedEventArgs e)  //Создание Зерглинга
        {
            if (mushres > 50)
            {
                zerglings.Add(new Zergling(canvas, pool.x + 60, pool.y + 60));
                zerglings[iz].Draw();
                iz++;
                mushres -= 50;
                Resources.DrawMushRes(mushres);
            }
            else
            {
                System.Windows.MessageBox.Show("Нам нужно больше грибов");
            }
        }
        #region Работа дронов
        public void DroneWork()                                             
        {
            droneTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            droneTimer.Tick += droneTimer_Tick;
            droneTimer.Start();
        }
        public void droneTimer_Tick(object sender, EventArgs e)                    
        {
            foreach (var item in drones)
            {
                item.Clear();
                item.Move(lair.x+60, lair.y+60, mushes[0].x + 40, mushes[0].y + 40);
                item.Draw();
                if (item.y==lair.y+60)
                {
                    mushres += 10;
                    Resources.DrawMushRes(mushres);
                }
            }
        }
        #endregion


        #region Движение зерглингов
        public void ZerglingMovements()
        {
            zerglingTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            zerglingTimer.Tick += zerglingTimer_Tick;
            zerglingTimer.Start();
        }
        public void zerglingTimer_Tick(object sender, EventArgs e)
        {
            foreach (var item in zerglings)
            {
                item.Clear();
                item.Move(item.x, item.y);
                item.Draw();
            }
        }
        #endregion

        #region Атаки врагов
        public void EnemyAttack()
        {

            GlobalTimer.Interval = new TimeSpan(0,0,0,4);
            GlobalTimer.Tick += GlobalTimer_Tick;
            GlobalTimer.Start();
        }

        void GlobalTimer_Tick(object sender, EventArgs e)
        {
            iaz = 0;
            for (int i = 0; i < 4; i++)
            {
                marines.Add(new Marine(canvas, 1000 + rnd.Next(100), 300 + rnd.Next(100)));
                marines[im].Draw();
                im++;
            }
            BattleTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            BattleTimer.Tick += BattleTimer_Tick;
            BattleTimer.Start();
        }

        void BattleTimer_Tick(object sender, EventArgs e)
        {
            #region Действия маринов

            foreach (var item in marines)
            {
                item.Clear();
                if (zerglings.Count == 0)
                {
                    item.MoveToTarget(item.x, item.y, lair.x+60, lair.y+60);
                    if (Math.Sqrt(Math.Pow(lair.x+60 - item.x, 2) + Math.Pow(lair.y+60 - item.y, 2)) < 10)
                    {
                        lair.hp -= item.damage;
                        if (lair.hp <= 0)
                        {
                            lair.Clear();
                            System.Windows.MessageBox.Show("Вы проиграли");
                            Environment.Exit(0);
                        }
                    }

                }
                else
                {
                    int TargetIndex = item.FindTarget(zerglings);
                    item.MoveToTarget(zerglings, item.x, item.y, TargetIndex);
                    if (Math.Sqrt(Math.Pow(zerglings[TargetIndex].x - item.x, 2) + Math.Pow(zerglings[TargetIndex].y - item.y, 2)) < 10)
                    {
                        zerglings[TargetIndex].hp -= item.damage;
                        if (zerglings[TargetIndex].hp <= 0)
                        {
                            zerglings[TargetIndex].Clear();
                            zerglings.Remove(zerglings[TargetIndex]);
                            iz--;
                        }
                    }
                }
                item.Draw();
            }
            #endregion
            #region Действия зергов
            foreach (var item in zerglings)
            {
                if (marines.Count == 0)
                {
                    foreach (var item2 in zerglings)
                    {
                        item2.t1 = 0;
                        item2.t2 = 0; 
                        item2.move = true;                      
                    }
                    BattleTimer.Stop();
                    break;
                }
                item.Clear();
                int TargetIndex = item.FindTarget(marines);
                item.MoveToTarget(marines, item.x, item.y, TargetIndex);
                if (Math.Sqrt(Math.Pow(marines[TargetIndex].x - item.x, 2) + Math.Pow(marines[TargetIndex].y - item.y, 2)) < 10)
                {
                    marines[TargetIndex].hp -= item.damage;
                    if (marines[TargetIndex].hp <= 0)
                    {
                        marines[TargetIndex].Clear();
                        marines.Remove(marines[TargetIndex]);
                        im--;
                    }
                }
                item.Draw();
            }
            #endregion
        }
        #endregion
    }
}
