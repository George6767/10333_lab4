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

namespace _10333_lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Canvas[] cavases = new Canvas[3];
        Hipodrome.UserControl1_Horse[] horses = new Hipodrome.UserControl1_Horse[3];
        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            for(int i=0; i<3; i++)
            {
                cavases[i] = new Canvas();
                Grid.SetRow(cavases[i], i);
                grid.Children.Add(cavases[i]);
            }
        }
    }
}
