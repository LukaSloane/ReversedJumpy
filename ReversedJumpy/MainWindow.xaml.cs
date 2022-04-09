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

namespace ReversedJumpy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private DispatcherTimer hardcoreTimer;
        private DispatcherTimer woohooTimer;
        private bool dirUp;
        private bool dirLeft;
        private bool active;
        private int distance = 1;
        private int count;


        public MainWindow()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += moveBall;
            hardcoreTimer = new DispatcherTimer();
            hardcoreTimer.Interval = TimeSpan.FromMilliseconds(100);
            hardcoreTimer.Tick += changeBackground;
            woohooTimer = new DispatcherTimer();
            woohooTimer.Interval = TimeSpan.FromSeconds(1);
            woohooTimer.Tick += changeCircleSize;
            

            dirUp = true;
            dirLeft = true;
            active = false;

            count = 0;

            InitializeComponent();

            slider.Minimum = distance;
            slider.Maximum = distance + 20;
        }

        

        private void moveBall(object sender, EventArgs e)
        {
            if(dirUp)
            {
                Canvas.SetTop(circle, Canvas.GetTop(circle) - distance);
                if(Canvas.GetTop(circle) <= 0)
                {
                    dirUp = false;
                }
            }
            else
            {
                Canvas.SetTop(circle, Canvas.GetTop(circle) + distance);
                if (Canvas.GetTop(circle) >= cnv.ActualHeight - circle.Height)
                {
                    dirUp = true;
                }
            }

            if(dirLeft)
            {
                Canvas.SetLeft(circle, Canvas.GetLeft(circle) - distance);
                if(Canvas.GetLeft(circle) <= 0)
                {
                    dirLeft = false;
                }
            }
            else
            {
                Canvas.SetLeft(circle, Canvas.GetLeft(circle) + distance);
                if(Canvas.GetLeft(circle) >= cnv.ActualWidth - circle.Width)
                {
                    dirLeft = true;
                }
                
            }
        }

        private void circle_click(object sender, MouseButtonEventArgs e)
        {
            if (active)
            {
                count++;
                score_count.Content = count;
            }
        }

        

        private void faster_checked(object sender, RoutedEventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if(box.IsChecked == true)
            {
                distance = 5;
                slider.Minimum = distance;
                slider.Maximum = distance + 20;
            }
            else if(box.IsChecked == false)
            {
                distance = 1;
                slider.Minimum = distance;
                slider.Maximum = distance + 20;
                active = false;
                timer.Stop();
            }
            
        }

        private void btn_go_click(object sender, RoutedEventArgs e)
        {

            active = !active;

            if (active)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }
            
            
        }

        private void radio_black_click(object sender, RoutedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if(radio.IsChecked == true)
            {
                circle.Fill = Brushes.Black;
            }
            
        }

        private void radio_white_click(object sender, RoutedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if(radio.IsChecked == true)
            {
                circle.Fill = Brushes.White;
            }
        }

        private void radio_red_click(object sender, RoutedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if (radio.IsChecked == true)
            {
                circle.Fill = Brushes.Red;
            }
        }

        private void radio_special_click(object sender, RoutedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            if(radio.IsChecked == true)
            {
                circle.Fill = new ImageBrush() { ImageSource = new BitmapImage(new Uri("https://media.istockphoto.com/photos/gray-british-cat-kitten-picture-id1086004080?k=20&m=1086004080&s=612x612&w=0&h=tvQKNjBGIsfCmUPR8YVJYfjLrTZ9JINbisKRjMj87IY=")) };
            }
        }

        private void hardcore_checked(object sender, RoutedEventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if(box.IsChecked == true) {
                hardcoreTimer.Start();
            }
            else if(box.IsChecked == false)
            {
                hardcoreTimer.Stop();
            }
        }

        private void changeBackground(object sender, EventArgs e)
        {
            
            Random random = new Random();
            
                cnv.Background = new SolidColorBrush(Color.FromRgb((byte)random.Next(1, 255),
                  (byte)random.Next(1, 255), (byte)random.Next(1, 233)));
            
        }

        private void woohoo_checked(object sender, RoutedEventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if(box.IsChecked == true)
            {
                woohooTimer.Start();
            }
            else
            {
                woohooTimer.Stop();
            }
        }

        private void changeCircleSize(object sender, EventArgs e)
        {
            Random random = new Random();

            int circleSize = random.Next(40, 270);

            circle.Height = circleSize;
            circle.Width = circleSize;
        }


        private void slider_change(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            

            distance = (int)slider.Value;
        }
    }
}
