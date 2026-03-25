using System.Diagnostics;
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

namespace idk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>

      
            int ticker = 1;
            double playerReaction = 0;
            bool TimersTicking = false;

            private readonly DispatcherTimer _lightTimer = new();
            private readonly DispatcherTimer _reactTimer = new();
            private Stopwatch ReactionCounter = new Stopwatch();

            private Random _randomStarter = new Random();

            List<Ellipse> balls;
            public MainWindow()
            {
                InitializeComponent();

                balls = new List<Ellipse>() { _0, _1, _2, _3, _4 };
                _lightTimer.Interval = TimeSpan.FromSeconds(1);
                _lightTimer.Tick += _lightTimer_Tick;
                _reactTimer.Interval = TimeSpan.FromMilliseconds(1);
                _reactTimer.Tick += _reactTimer_Tick;
            }

            private void _reactTimer_Tick(object? sender, EventArgs e)
            {
            TimerLabel.Text = ReactionCounter.Elapsed.Seconds + ":" + ReactionCounter.Elapsed.Milliseconds + "s";
            }
            private void _lightTimer_Tick(object? sender, EventArgs e)
            {
                balls[ticker].Fill = Brushes.DarkGreen;
                ticker++;

                if (ticker == balls.Count)
                {
                    _lightTimer.Stop();
                    RandomStarter();

                }
            }
            private async void RandomStarter()
            {
                int delay = 0;
                delay = _randomStarter.Next(1000, 3001);

                await Task.Delay(delay);
                ReactionCounter.Start(); //fffffffffffff
                _reactTimer.Start();
                foreach (var item in balls)
                {
                    item.Fill = Brushes.DarkRed;
                }
                TimersTicking = true;
            }
           
           
            private void aftermatch()
            {


                TimersTicking = false;
                ticker = 0;
                playerReaction = ReactionCounter.Elapsed.TotalSeconds;
                ReationResults();
            }
            private void ReationResults()
            {
                string whatYaGot = string.Empty;

                if (playerReaction > 1.0) // >1000ms
                {
                    whatYaGot = "You did horrible";
                }
                else if (playerReaction > 0.75)
                {
                    whatYaGot = "I mean, still trash, but at least not THAT bad";
                }
                else if (playerReaction > 0.5)
                {
                    whatYaGot = "You did good I guess...";
                }
                else if (playerReaction > 0.3)
                {
                    whatYaGot = "Dang, you are pretty good";
                }
                else if (playerReaction > 0.2)
                {
                    whatYaGot = "My dear, you are just the GOAT!";
                }
                else if (playerReaction > 0.1)
                {
                    whatYaGot = "Just HOW!?";
                }
                else
                {
                    whatYaGot = "What did you do wrong, bruh?";
                }

                MessageBox.Show(whatYaGot);
            }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            playerReaction = 0;

            ReactionCounter.Reset();
            TimerLabel.Text = ReactionCounter.Elapsed.Seconds + ":" + ReactionCounter.Elapsed.Milliseconds + "s";

            _lightTimer.Start();
            balls[0].Fill = Brushes.DarkGreen;

        }

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            if (TimersTicking)
            {
                ReactionCounter.Stop();
                _reactTimer.Stop();
                TimerLabel.Text = ReactionCounter.Elapsed.Seconds + ":" + ReactionCounter.Elapsed.Milliseconds + "s";
                aftermatch();
            }
            else
            {
            Window: Close();
            }
        }
    }
    }