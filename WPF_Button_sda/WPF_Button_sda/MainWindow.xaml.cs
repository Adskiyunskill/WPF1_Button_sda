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

namespace WPF_Button_sda
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Random r;
            r = new Random();
           

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            button1.SetValue(Canvas.LeftProperty, p.X - button1.ActualWidth / 2);
            button1.SetValue(Canvas.TopProperty, p.Y - button1.ActualHeight / 2);
            if ((string)button2.Content == "Изменить")
            {
                button2.Content = " ";
                button2.MouseMove += button2_MouseMove;
                button2.Click += button2_Click;
                button2.Click -= button2_Click2;
            }    
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            Random r = new Random();
            if (Keyboard.IsKeyDown(Key.LeftCtrl)
            || Keyboard.IsKeyDown(Key.RightCtrl)
            || Keyboard.IsKeyDown(Key.Space))
                return;
            Point p = e.GetPosition(this);
            Canvas.SetLeft(button2, r.NextDouble() *
                ((Content as Canvas).ActualWidth - 5));
            Canvas.SetTop(button2, r.NextDouble() *
                ((Content as Canvas).ActualHeight - 5));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            button2.Content = "Изменить";
            button2.MouseMove -= button2_MouseMove;
            button2.Click -= button2_Click2;
            
        }

        private void button2_Click2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Normal ?
                WindowState.Maximized : WindowState.Normal;

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var c = Content as Canvas;
            for (int i = 0; i < 2; i++ )
            {
                var b = FindName("button" + (i + 1)) as Button;
                if (Canvas.GetLeft(b) > c.ActualWidth ||
                    Canvas.GetTop(b) > c.ActualHeight)
                {
                    Canvas.SetLeft(b, 10 + i * (b.ActualWidth + 10));
                    Canvas.SetTop(b, 10);
                }
            }
        }
    }
}
