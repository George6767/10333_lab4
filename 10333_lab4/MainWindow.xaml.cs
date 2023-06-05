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
        bool flStart = false;
        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            for(int i=0; i<3; i++)
            {
                canvases[i] = new Canvas();
                Grid.SetRow(canvases[i], i);
                grid.Children.Add(canvases[i]);
            }
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(1000);
            timer.Tick += new EventHandler(timer_Tick);


            timerUpdateSpeed = new DispatcherTimer();
            timerUpdateSpeed.Interval = new TimeSpan(0, 0, 2);
            timerUpdateSpeed.Tick += new EventHandler(timertimerUpdateSpeed_Tick);

        }
        private void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                canvases[i].Children.Clear();
                horses[i] = new Hipodrome.UserControl1_Horse(random.Next(20, 50));
                canvases[i].Children.Add(horses[i]);

            }
            timer.Start();
            timerUpdateSpeed.Start();
        }

        private void timertimerUpdateSpeed_Tick(object? sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                horses[i].UpdateSpeed(random.Next(30, 80));
            }
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
        if(flStart == false)
            {
                flStart = true;
                Start();
            }
            if (timer.IsEnabled)
            {
                ((Button)sender).Content = "Start";
                timer.IsEnabled = false;
                timerUpdateSpeed.IsEnabled = false;
            }
            else
            {
                ((Button)sender).Content = "Pause";
                timer.IsEnabled = true; 
                timerUpdateSpeed.IsEnabled = true;
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            Start();
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++) 
            {
                int k = 0; // postion of horse
                for (int j = 0; j < 3; j++)
                {
                    if (horses[i].XHorse <= horses[j].XHorse)
                        k++;
                }
                horses[i].UpdatePosition(k);
                horses[i].XHorse += (float)horses[i].GetSpeed() / 1000f;
            }
        }
    }
}
