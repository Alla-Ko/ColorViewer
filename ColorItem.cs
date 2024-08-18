using System.Windows.Media;

namespace ColorViewer
{
    public class ColorItem
    {
        public string ColorCode { get; set; }
        public Brush ColorBrush { get; set; }

        public ColorItem(string colorCode)
        {
            ColorCode = colorCode;
            ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorCode));
        }
        public bool Equals(Color color)
        {
            var brushColor = ((SolidColorBrush)ColorBrush).Color;
            return brushColor == color;
        }
    }
}
