using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TestWPFApp
{
    public class NumberBox : UIElement
    {
        private TextBox textBox = new TextBox();
        private Button up = new Button() { Content = "+"};
        private Button down = new Button() { Content = "-" };
        private double height;
        private double width;
        private int value;
        private Thickness margin;
        private bool recFlag;

        public int Value 
        { 
            get => value; 
            set
            {
                recFlag = true;
                textBox.Text = value.ToString();
                this.value = value;
                ChangeValue();
            }
        }

        public double Height
        {
            get => height;
            set
            {
                height = value;
                textBox.Height = value; up.Height = down.Height = value / 2;
            }
        }

        public double Width
        {
            get => width;
            set
            {
                width = value;
                textBox.Width = value / 3 * 2;
                up.Width = down.Width = value / 3;
            }
        }

        public Thickness Margin
        {
            get => margin;
            set
            {
                margin = value;
                textBox.Margin = value;
                value.Left += textBox.Width + up.Width;
                value.Top -= up.Height;
                up.Margin = value;
                value.Top += up.Height + down.Height;
                down.Margin = value;
            }
        }

        public Brush Foreground
        {
            set
            {
                textBox.Foreground = value;
                up.Foreground = value;
                down.Foreground = value;
            }
        }

        public Brush Background
        {
            set
            {
                textBox.Background = value;
                up.Background = value;
                down.Background = value;
            }
        }

        public NumberBox()
        {
            textBox.TextChanged += ValidateNumbers;
            up.Click += IncreaseValue;
            down.Click += DecreaseValue;
        }

        private void DecreaseValue(object sender, RoutedEventArgs e)
        {
            Value--;
        }

        private void IncreaseValue(object sender, RoutedEventArgs e)
        {
            Value++;
        }

        private void ValidateNumbers(object sender, TextChangedEventArgs e)
        {
            if (recFlag)
            {
                recFlag = false;
                return;
            }
            if (!textBox.Text.All(x => char.IsDigit(x)))
            {
                recFlag = true;
                textBox.Text = value.ToString();
            }
            else if (!int.TryParse(textBox.Text, out value))
            {
                value = 0;
            }
        }

        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);
            Grid grid = VisualParent as Grid;
            grid.Children.Add(textBox);
            grid.Children.Add(up);
            grid.Children.Add(down);
        }

        public readonly RoutedEvent ValueChange = EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(NumberBox));

        public event RoutedEventHandler ValueChanged
        {
            add => AddHandler(ValueChange, value);
            remove => RemoveHandler(ValueChange, value);
        }

        private void ChangeValue() => RaiseEvent(new RoutedEventArgs(ValueChange, this));
    }
}
