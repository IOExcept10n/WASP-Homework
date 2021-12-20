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

namespace Homework1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Поля для быстрого обащения к кнопкам и быстрой проверки изменения текста с возможностью откатить изменения.
        List<Button> buttons;
        string codeBuffer = "";
        bool flag = false;
        DispatcherTimer timer = new DispatcherTimer();
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            //Инициализируем список кнопок.
            buttons = new List<Button>() { ZeroKey, OneKey, TwoKey, ThreeKey, FourKey, FiveKey, SixKey, SevenKey, EightKey, NineKey, CancelKey, AcceptKey };
            //Инициализируем таймер.
            timer.Interval = TimeSpan.FromSeconds(random.Next(3, 11) + random.NextDouble());
            timer.Tick += SwapButtons;
            timer.Start();
        }

        private void SwapButtons(object sender, EventArgs e)
        {
            List<Button> btnToSwap = buttons.GetRange(0, 10);//Здесь будут кнопки, на которых нужно поменять значение.
            for (int i = 9; i >= 0; i--)
            {
                Button btn = btnToSwap[random.Next(0, i)];
                btn.Background = new SolidColorBrush(Color.FromArgb((byte)random.Next(100, 255), (byte)random.Next(0, 200), (byte)random.Next(0, 200), (byte)random.Next(0, 200)));
                btn.Content = i;
                btnToSwap.Remove(btn);
            }
            timer.Interval = TimeSpan.FromSeconds(random.Next(3, 11) + random.NextDouble());
        }

        /// <summary>
        /// Обработчик нажатия кнопки отмены.
        /// </summary>
        private void CancelKey_Click(object sender, RoutedEventArgs e)
        {
            Code.Text = "";
            buttons.ForEach(x => x.Content = "");
        }
        /// <summary>
        /// Обработчик нажатия кнопки проверки.
        /// </summary>
        private void AcceptKey_Click(object sender, RoutedEventArgs e)
        {
            if (Code.Text == "2314138")
            {
                Code.Text = "Success!";
                Code.Background = new SolidColorBrush(Color.FromArgb(0x87, 0x7E, 0xE0, 0x91));
                Code.IsEnabled = false;
                buttons.ForEach(x => x.IsEnabled = false);
            }
            else Code.Text = "";
        }
        /// <summary>
        /// Обработчик изенения текста (для быстрой проверки символов на цифры).
        /// </summary>
        private void Code_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (flag)
            {
                flag = false;
                return;
            }
            if (!(string.IsNullOrEmpty(Code?.Text) || Code.Text == "Success!" || Code.Text.All(x => char.IsDigit(x))))
            {
                flag = true;
                Code.Text = codeBuffer;
            }
            else codeBuffer = Code.Text;
        }
        /// <summary>
        /// Обработчик ввода (для проверки нажатия клавиши Enter).
        /// </summary>
        private void Code_KeyDown(object sender, KeyEventArgs e)
        {
            int direction = random.Next(0, 4);
            Thickness pos;
            switch (direction)
            { 
                case 0:
                    pos = new Thickness(random.Next(1, 6), 0, 0, 0);
                    break;
                case 1:
                    pos = new Thickness(0, random.Next(1, 6), 0, 0);
                    break;
                case 2:
                    pos = new Thickness(0, 0, random.Next(1, 6), 0);
                    break;
                default:
                    pos = new Thickness(0, 0, 0, random.Next(1, 6));
                    break;
            }
            Code.HorizontalAlignment = HorizontalAlignment.Center;
            Code.VerticalAlignment = VerticalAlignment.Center;
            Code.Margin = pos;
            if (e.Key == Key.Enter) AcceptKey_Click(sender, e);
        }
        /// <summary>
        /// Ввод числа в поле для ввода
        /// </summary>
        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            SwapButtons(sender, null);
            Code.Text += (sender as Button).Content;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Code.Text = InputSlider.Value.ToString();
        }
    }
}
