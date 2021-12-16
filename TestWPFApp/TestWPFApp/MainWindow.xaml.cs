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

namespace TestWPFApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer Generator { get; set; } = new DispatcherTimer();
        Random Random { get; set; } = new Random();

        public MainWindow()
        {
            InitializeComponent();
            Generator.Interval = TimeSpan.FromSeconds(3);
            Generator.Tick += Generate;
            Generator.Start();
        }

        private void Generate(object sender, EventArgs e)
        {
            Button btn = new Button();
            Random = new Random();
            btn.Background = new SolidColorBrush(Color.FromArgb((byte)Random.Next(0, 256), (byte)Random.Next(0, 256), (byte)Random.Next(0, 256), (byte)Random.Next(0, 256)));
            btn.Content = "Click me if you can!";
            btn.MouseEnter += RunAway;
            btn.Click += Congratulate;//Первоначальной идеей названия было "ShowHowImShockedThatWowImpossibleHowDidYouClickedThisButton"
            btn.Width = 100; btn.Height = 40;
            Field.Children.Add(btn);
        }

        private void SetPos(Button btn, Point pos)
        {
            bool flag;
            int locX, locY;
            do
            {
                locX = Random.Next(0, (int)Width - 120);
                locY = Random.Next(0, (int)Height - 60);
                if (locX > pos.X && locX < pos.X + 100 && locY > pos.Y && locY < pos.Y + 40) flag = true;
                else flag = false;
            } while (flag);
            Thickness margin = new Thickness(locX, locY, 0, 0);
            btn.Margin = margin;
        }

        private void Congratulate(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wow, ImPoSsIbLe, You clicked this button!!!");
        }

        private void RunAway(object sender, MouseEventArgs e)
        {
            SetPos(sender as Button, e.GetPosition(this));
        }
    }
}
