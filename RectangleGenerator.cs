using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lab13
{
    public class RectangleGenerator : IControlGenerator
    {
        public FrameworkElement Generate()
        {
            return new Rectangle() {
                Width = 100,
                Height = 20,
                Fill = new SolidColorBrush(Colors.DarkOrchid),
                Margin = new Thickness(0, 5, 0, 5) 
            };
            
        }
    }
}
