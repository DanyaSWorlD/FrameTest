using FrameTest.Components.Model;
using System.Windows.Controls;

namespace FrameTest.Components.View
{
    /// <summary>
    /// Логика взаимодействия для PopupWindow.xaml
    /// </summary>
    public partial class PopupControl : UserControl
    {
        public PopupControl(PopupControlModel model)
        {
            DataContext = model;
            InitializeComponent();
        }
    }
}
