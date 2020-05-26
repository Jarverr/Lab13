using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab13
{
     public interface IControlGenerator
    {
        //Control Generate();
        FrameworkElement Generate();
    }
}
