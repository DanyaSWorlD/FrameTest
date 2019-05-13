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

        public string Result
        {
            get => _result;
            set => Set(ref _result, value);
        }

        public RelayCommand ButtonClick => new RelayCommand(() =>
        {
            // make button inactive
            ButtonEnabled = false;

            Task.Factory.StartNew(() =>
            {
                // hard work imitation
                Thread.Sleep(1000);

                // creating a control
                var control = new PopupControlModel();

                // getting a view to show in ContentPresenter
                Message = control.GetVIew();
                
                // make text input control visible
                MessageVisible = Visibility.Visible;

                // run a mainLoop stopping function
                Result = control.GetInput();

                // hide text input control
                MessageVisible = Visibility.Collapsed;

                // clear ControlPresenter
                Message = null;

                // hard work imitation
                Thread.Sleep(2000);

                // make button active
                ButtonEnabled = true;
            });
        });
    }
}
