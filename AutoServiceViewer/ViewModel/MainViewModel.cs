using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataAccess.Model;
using DataAccess.Repository;
using Mvvm;

namespace AutoServiceViewer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Order> _orders;
        private RepositoryType _repositoryType;
        private Order _selectedOrder;

        public MainViewModel()
        {
            Orders = new ObservableCollection<Order>();
        }

        public RepositoryType RepositoryType {
            get { return _repositoryType; }
            set {
                _repositoryType = value;
                NotifyPropertyChanged();
            }
        }

        public Order SelectedOrder {
            get { return _selectedOrder; }
            set {
                _selectedOrder = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Order> Orders {
            get { return _orders; }
            set {
                _orders = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand GetDataCommand {
            get { return new RelayCommand(o => GetData()); }
        }

        private void GetData()
        {
            if (!RegisterRepository()) return;
            IRepository repository = IocApp.GetRepository(RepositoryType);
            if (repository.ErrorHappened) return;
            SetData(repository.GetOrders());
        }

        private void SetData(IEnumerable<Order> orders)
        {
            Orders = new ObservableCollection<Order>(orders);
        }

        private bool RegisterRepository()
        {
            return IocApp.GetRegistrator(RepositoryType)
                .Register();
        }
    }
}