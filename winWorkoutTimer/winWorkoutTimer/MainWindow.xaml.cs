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

            
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick +=new EventHandler(timer_Tick);
            InitClock();
            


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
            lblTimerDisplay.Foreground = timer.Format();
            lblTimerDisplay.Content = timer.Print();
        }

        private void btnToggleStart_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch(btn.Content.ToString()){
                case "Start" :
                    timer.Start();
                    btn.Content = "Stop";
                    break;
                case "Stop" :
                    timer.Stop();
                    btn.Content = "Start";
                    break;
                default:
                    break;
            }
            
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ITickable timer = currentTimer as ITickable;
            timer.Reset();
            IPrintable timerToPrint = currentTimer as IPrintable;
            lblTimerDisplay.Content = timerToPrint.Print();
        }

        private void btnClock_Click(object sender, RoutedEventArgs e)
        {
            InitClock();
        }

        private void InitClock()
        {
            currentTimer = new Clock();
            lblTimerDisplay.Content = currentTimer.Print();
            timer.Start();
            btnReset.IsEnabled = false;
            btnToggleStart.IsEnabled = false;
            btnClock.IsEnabled = false;
            btnStopwatch.IsEnabled = true;
            btnEMOM.IsEnabled = true;
            btnCountdown.IsEnabled = true;
        }

        private void btnStopwatch_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            currentTimer = new BaseTimer();
            lblTimerDisplay.Content = currentTimer.Print();
            btnReset.IsEnabled = true;
            btnToggleStart.IsEnabled = true;
            btnToggleStart.Content = "Start";
            btnClock.IsEnabled = true;
            btnStopwatch.IsEnabled = false;
            btnEMOM.IsEnabled = true;
            btnCountdown.IsEnabled = true;
        }

        private void btnEMOM_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            currentTimer = new EMOMTimer();
            lblTimerDisplay.Content = currentTimer.Print();
            btnReset.IsEnabled = true;
            btnToggleStart.IsEnabled = true;
            btnToggleStart.Content = "Start";
            btnClock.IsEnabled = true;
            btnStopwatch.IsEnabled = true;
            btnEMOM.IsEnabled = false;
            btnCountdown.IsEnabled = true;
        }

        private void btnCountdown_Click(object sender, RoutedEventArgs e)
        {
            int seedTime = 0;
            try
            {
                seedTime = int.Parse(tbStartTime.Text);
            }
            catch (Exception)
            {
                seedTime = 0;
            }

            timer.Stop();
            currentTimer = new CountdownTimer(TimeSpan.FromMinutes(seedTime));
            lblTimerDisplay.Content = currentTimer.Print();
            btnReset.IsEnabled = true;
            btnToggleStart.IsEnabled = true;
            btnToggleStart.Content = "Start";
            btnClock.IsEnabled = true;
            btnStopwatch.IsEnabled = true;
            btnEMOM.IsEnabled = true;
            btnCountdown.IsEnabled = false;
        }
    }
}
