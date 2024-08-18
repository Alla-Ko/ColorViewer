using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ColorViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<ColorItem> Colors { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Colors = new ObservableCollection<ColorItem>();
            DataContext = this;
            ColorListView.Items.Clear();
        }
        private void UpdateRectangleColor()
        {
            byte alpha = (byte)AlphaSlider.Value;
            byte red = (byte)RedSlider.Value;
            byte green = (byte)GreenSlider.Value;
            byte blue = (byte)BlueSlider.Value;
            Color color = Color.FromArgb(alpha, red, green, blue);
            ColorRectangle.Fill = new SolidColorBrush(color);
            if (IsColorInCollection(color))
            {
                AddButton.IsEnabled = false;
            }
            else
            {
                AddButton.IsEnabled = true;
            }
        }
        private bool IsColorInCollection(Color color)
        {
            foreach (var item in Colors)
            {
                if (item.Equals(color))
                {
                    return true;
                }
            }
            return false;
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            switch (sender)
            {
                case CheckBox checkBox when checkBox == AlphaCheckBox:
                    AlphaSlider.Value = 0;
                    break;

                case CheckBox checkBox when checkBox == RedCheckBox:
                    RedSlider.Value = 0;
                    break;

                case CheckBox checkBox when checkBox == GreenCheckBox:
                    GreenSlider.Value = 0;
                    break;

                case CheckBox checkBox when checkBox == BlueCheckBox:
                    BlueSlider.Value = 0;
                    break;

                default:
                    break;
            }
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateRectangleColor();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            var color = ((SolidColorBrush)ColorRectangle.Fill).Color;
            string colorCode = $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
            Colors.Add(new ColorItem(colorCode));
            AddButton.IsEnabled = false;
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var item = button.DataContext as ColorItem;

            if (item != null)
            {
                Colors.Remove(item);
                var color = ((SolidColorBrush)ColorRectangle.Fill).Color;

                if (IsColorInCollection(color))
                {
                    AddButton.IsEnabled = false;
                }
                else
                {
                    AddButton.IsEnabled = true;
                }
            }
        }
    }

}