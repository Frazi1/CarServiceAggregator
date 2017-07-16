using System.Windows.Input;

namespace Mvvm.Test.Base
{
    public class StubViewModel : ViewModelBase
    {
        private int _someProperty;

        public int SomeProperty {
            get { return _someProperty; }
            set {
                _someProperty = value;
                NotifyPropertyChanged();
            }
        }

        //public ICommand ChangePropertyCommand {
        //    get { return new RelayCommand(o => ChangeProperty(o)); }
        //}
        public ICommand ChangePropertyCommand { get; set; }

        private void ChangeProperty(object value)
        {
            SomeProperty = (int) value;
        }
    }
}