using System.Windows;

namespace FrameTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowModel();
            InitializeComponent();
        }
    }
}
