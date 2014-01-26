using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace winWorkoutTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPrintable currentTimer;
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            
            currentTimer = new Clock();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick +=new EventHandler(timer_Tick);
            timer.Start();

        }
        protected void timer_Tick(object sender, EventArgs e)
        {
            var timer = currentTimer as ITickable;
            timer.Tick();
            PrintTimer();
        }

        private void PrintTimer()
        {
            var timer = currentTimer as IPrintable;
            lblTimerDisplay.Content = timer.Print();
        }
    }
}
