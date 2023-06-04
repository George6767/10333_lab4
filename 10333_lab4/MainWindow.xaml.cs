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
using System.Windows.Threading;

namespace _10333_lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Canvas[] canvases = new Canvas[3];
        Hipodrome.UserControl1_Horse[] horses = new Hipodrome.UserControl1_Horse[3];
        DispatcherTimer timer, timerUpdateSpeed;
        Random random = new Random(); 
        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            for(int i=0; i<3; i++)
            {
                canvases[i] = new Canvas();
                Grid.SetRow(canvases[i], i);
                grid.Children.Add(canvases[i]);
                horses[i] = new Hipodrome.UserControl1_Horse(random.Next(20, 50));
                canvases[i].Children.Add(horses[i]);
            }
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(1000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            timerUpdateSpeed = new DispatcherTimer();
            timerUpdateSpeed.Interval = new TimeSpan(0, 0, 2);
            timerUpdateSpeed.Tick += new EventHandler(timertimerUpdateSpeed_Tick);
            timerUpdateSpeed.Start();
        }

        private void timertimerUpdateSpeed_Tick(object? sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                horses[i].UpdateSpeed(random.Next(30, 80));
            }
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                horses[i].XHorse += (float)horses[i].GetSpeed() / 12000f;
            }
        }
    }
}
