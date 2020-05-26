using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab13
{
    public class PanelFiller : IPanelFiller
    {
        public IDataProvider _dataProvider { get; set; }
        public IControlGenerator _controlGenerator { get; private set; }

        public PanelFiller(IControlGenerator controlGenerator, IDataProvider data)
        {
            _controlGenerator = controlGenerator;
            _dataProvider = data;
        }

        public void Fill(Panel panel)
        {
            var numer = _dataProvider.GetData();
            for (int i = 0; i < numer; i++)
            {
                panel.Children.Add(_controlGenerator.Generate());
            }
        }
    }
}
