using FrameTest.Components.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Threading;

namespace FrameTest.Components.Model
{
    public class PopupControlModel : ViewModelBase
    {
        private PopupControl _view;
        private string _text;

        private delegate void ButtonClickedHandler();

        private event ButtonClickedHandler ButtonClicked;

        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }

        public RelayCommand ButtonClick => new RelayCommand(() =>
        {
            ButtonClicked?.Invoke();
        });

        public object GetVIew()
        {
            if (_view == null)
                Application.Current.Dispatcher.Invoke(() => _view = new PopupControl(this));

            return _view;
        }

        public string GetInput()
        {
            var frame = new DispatcherFrame();

            ButtonClicked += () => { frame.Continue = false; };

            Dispatcher.PushFrame(frame);
            return Text;
        }
    }
}