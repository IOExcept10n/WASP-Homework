using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TestWPFApp
{
    /// <summary>
    /// Класс для гистограммы.
    /// </summary>
    public class HorizontalBarGraph : UIElement
    {
        /// <summary>
        /// Внутренний список значений.
        /// </summary>
        private List<int> values;
        /// <summary>
        /// Внутренний список прямоугольников для отрисовки гистограммы.
        /// </summary>
        private List<Rectangle> rows;
        /// <summary>
        /// Внутреннее поле для хранения отступа (координат).
        /// </summary>
        private Thickness margin;
        /// <summary>
        /// Поле для хранения высоты.
        /// </summary>
        private double height;
        /// <summary>
        /// Поле для хранения коэффициента ширины.
        /// </summary>
        private uint widthCoefficient;
        /// <summary>
        /// Список значений. Данные невозможно оперативно поменять, так как изменение данных в списке невозможно отследить.
        /// </summary>
        public List<int> Values
        {
            get { return new List<int>(values); }
            set { SetupRows(value); }
        }
        /// <summary>
        /// Количество строк.
        /// </summary>
        public int AmountOfRows => rows.Count;
        /// <summary>
        /// Отступы элемента.
        /// </summary>
        public Thickness Margin
        {
            get { return margin; }
            set { margin = value; UpdateRows(); }
        }
        /// <summary>
        /// Высота элемента.
        /// </summary>
        public double Height
        {
            get { return height; }
            set { height = value; UpdateRows(); }
        }
        /// <summary>
        /// Коэффициент ширины элемента.
        /// </summary>
        public uint WidthCoefficient
        {
            get { return widthCoefficient; }
            set { widthCoefficient = value; UpdateRows(); }
        }
        /// <summary>
        /// Максимальное значение для одной строки.
        /// </summary>
        public int CapValue { get; set; }
        /// <summary>
        /// Если имеет значение true, то превышение лимита вызывает исключение.
        /// </summary>
        public bool IsHardCap { get; set; }
        /// <summary>
        /// Список основных цветов строк.
        /// </summary>
        public List<Brush> Colors => (from x in rows select x.Fill).ToList();
        /// <summary>
        /// Список цветов границ строк.
        /// </summary>
        public List<Brush> Borders => (from x in rows select x.Stroke).ToList();
        /// <summary>
        /// True, если есть проблемы со значением.
        /// </summary>
        public bool IsDecoy { get; set; }
        /// <summary>
        /// Поле события на изменение числа столбцов.
        /// </summary>
        public readonly RoutedEvent AmountOfRowsChange = EventManager.RegisterRoutedEvent("AmonutOfRowsChange", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(HorizontalBarGraph));
        /// <summary>
        /// Событие на изменение числа столбцов.
        /// </summary>
        public event RoutedEventHandler AmountOfRowsChanged
        {
            add
            {
                AddHandler(AmountOfRowsChange, value);
            }
            remove
            {
                RemoveHandler(AmountOfRowsChange, value);
            }
        }
        /// <summary>
        /// Поле события на достижение лимита одной из строк.
        /// </summary>
        public readonly RoutedEvent ReachCapValue = EventManager.RegisterRoutedEvent("ReachCapValue", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(HorizontalBarGraph));
        /// <summary>
        /// Событие на достижение лимита одной из строк.
        /// </summary>
        public event RoutedEventHandler CapValueReached
        {
            add
            {
                AddHandler(ReachCapValue, value);
            }
            remove
            {
                RemoveHandler(ReachCapValue, value);
            }
        }
        /// <summary>
        /// Создаёт новую гистограмму.
        /// </summary>
        public HorizontalBarGraph()
        {
            rows = new List<Rectangle>();
            values = new List<int>();
        }
        /// <summary>
        /// Метод настройки строк. Осуществляет синхронизацию их количества
        /// </summary>
        /// <param name="values">Новый полученный список значений.</param>
        private void SetupRows(List<int> values)
        {
            if (values.Count != rows.Count)
            {
                rows.Clear();
                foreach (var value in values)
                {
                    ValidateCapValue(value);
                    rows.Add(new Rectangle() { Stroke = new SolidColorBrush(System.Windows.Media.Colors.Black) });
                }
                this.values = new List<int>(values);
                UpdateRows();
                RaiseEvent(new RoutedEventArgs(AmountOfRowsChange, null));
            }
            else
            {
                this.values = new List<int>(values);
                UpdateRows();
            }
        }
        /// <summary>
        /// Метод обновления значений (ширины) строк.
        /// </summary>
        private void UpdateRows()
        {
            Thickness margin = this.margin;
            int i = 0;
            foreach (var row in rows)
            {
                row.HorizontalAlignment = HorizontalAlignment.Left;
                row.VerticalAlignment = VerticalAlignment.Top;
                row.Height = height / AmountOfRows;
                margin.Top += row.Height + 5;
                row.Margin = margin;
                row.Width = values[i++] * WidthCoefficient;
            }
        }
        /// <summary>
        /// Метод для добавления прямоугольников на форму.
        /// </summary>
        /// <param name="oldParent"></param>
        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);
            Grid grid = VisualParent as Grid;
            foreach (var row in rows) grid.Children.Add(row);
        }
        /// <summary>
        /// Проверка на превышение значения.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void ValidateCapValue(int value)
        {
            if (IsHardCap && value > CapValue) throw new ArgumentOutOfRangeException("value", "Cap value has been exceeded!");
            else if (value >= CapValue && CapValue != 0) RaiseEvent(new RoutedEventArgs(ReachCapValue, this));
        }
        /// <summary>
        /// Расставляет случайные цвета для столбцов.
        /// </summary>
        public void Recolor()
        {
            Random rand = new Random();
            foreach (var row in rows)
            {
                row.Stroke = new SolidColorBrush(Color.FromArgb((byte)rand.Next(0, 256), (byte)rand.Next(0, 256), (byte)rand.Next(0, 256), (byte)rand.Next(0, 256)));
                row.Fill = new SolidColorBrush(Color.FromArgb((byte)rand.Next(0, 256), (byte)rand.Next(0, 256), (byte)rand.Next(0, 256), (byte)rand.Next(0, 256)));
            }
        }
        /// <summary>
        /// Получает среднее значение среди значений.
        /// </summary>
        /// <returns></returns>
        public double GetAvg() => values.Average();//System.Linq
        /// <summary>
        /// Получает максимальное значение.
        /// </summary>
        /// <returns></returns>
        public int GetMax() => values.Max();//System.Linq
        /// <summary>
        /// Сортирует гистограмму по возрастанию (хотя на самом деле по убыванию, т.к. значения идут сверху-вниз).
        /// </summary>
        public void Sort()
        {
            if (!IsDecoy)
            {
                values.Sort();
                values.Reverse();
                SetupRows(Values);
            }
        }
        /// <summary>
        /// Немного изменяет видимые прямоугольники по ширине.
        /// </summary>
        public void Reshuffle()
        {
            if (!IsDecoy)
            {
                var rand = new Random();
                foreach (var row in rows)
                {
                    row.Width += rand.Next(-20, 20);
                }
                IsDecoy = true;
            }
        }
        /// <summary>
        /// Нормализует прямоугольники.
        /// </summary>
        public void Correct()
        {
            if (IsDecoy)
            {
                SetupRows(Values);
                IsDecoy = false;
            }
        }
    }
}
