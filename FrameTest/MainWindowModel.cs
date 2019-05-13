using FrameTest.Components.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace FrameTest
{
    public class MainWindowModel : ViewModelBase
    {
        private Visibility _messageVisible = Visibility.Collapsed;
        private object _message;
        private bool _buttonEnabled = true;
        private string _result;

        public Visibility MessageVisible
        {
            get => _messageVisible;
            set => Set(ref _messageVisible, value);
        }

        public object Message
        {
            get => _message;
            set => Set(ref _message, value);
        }

        public bool ButtonEnabled
        {
            get => _buttonEnabled;
            set => Set(ref _buttonEnabled, value);
        }

        public RelayCommand ButtonClick => new RelayCommand(() =>
        {
            ButtonEnabled = false;

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);

                var control = new PopupControlModel();

                Message = control.GetVIew();
                MessageVisible = Visibility.Visible;

                control.GetInput();

                MessageVisible = Visibility.Collapsed;
                Message = null;

                Thread.Sleep(2000);

                ButtonEnabled = true;
            });
        });
    }
}
