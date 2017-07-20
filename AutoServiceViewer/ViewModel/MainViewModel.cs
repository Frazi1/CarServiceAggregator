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
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<Order> _orders;
        //private IRepository _repository;
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
            get { return new RelayCommand(o => GetData()); }
        }

        private void GetData()
        {
            if (!RegisterRepository()) return;
            IRepository repository = IocApp.GetRepository(RepositoryType);
            if (repository.ErrorHappened) return;
            SetData(repository.GetOrders(), repository.GetCustomers());
        }

        private void SetData(IEnumerable<Order> orders, IEnumerable<Customer> customers)
        {
            Orders = new ObservableCollection<Order>(orders);
            Customers = new ObservableCollection<Customer>(customers);
        }

        private bool RegisterRepository()
        {
            return IocApp.GetRegistrator(RepositoryType)
                .Register();
        }
    }
}