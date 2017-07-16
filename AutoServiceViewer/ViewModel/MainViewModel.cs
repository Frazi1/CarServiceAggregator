using System.Collections.ObjectModel;
using System.Windows.Input;
using DataAccess.Model;
using DataAccess.Repository;
using Mvvm;

namespace AutoServiceViewer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<Order> _orders;
        private IRepository _repository;
        private RepositoryType _repositoryType;
        private Order _selectedOrder;

        public MainViewModel()
        {
            Customers = new ObservableCollection<Customer>();
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

        public ObservableCollection<Customer> Customers {
            get { return _customers; }
            set {
                _customers = value;
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
            get { return new RelayCommand(o => GetData(), o => IocApp.IsRegistered(RepositoryType)); }
        }

        private void GetData()
        {
            ClearData();
            _repository = IocApp.GetRepository(RepositoryType);
            if (_repository.ErrorHappened) return;
            var orders = _repository.GetOrders();
            var customers = _repository.GetCustomers();
            Orders = new ObservableCollection<Order>(orders);
            Customers = new ObservableCollection<Customer>(customers);
        }

        private void ClearData()
        {
            Orders.Clear();
            Customers.Clear();
        }
    }
}