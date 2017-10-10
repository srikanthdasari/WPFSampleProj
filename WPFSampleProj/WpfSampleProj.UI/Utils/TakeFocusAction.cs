using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace WpfSampleProj.UI.Utils
{
    public class TakeFocusAction: TriggerAction<UIElement>
    {
        protected override void Invoke(object parameter)
        {
            AssociatedObject.Focus();
        }

    }
}
