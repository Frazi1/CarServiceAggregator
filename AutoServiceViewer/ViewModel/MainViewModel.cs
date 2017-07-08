using System.Collections.ObjectModel;
using System.Windows.Input;
using DataAccess.Model;
using DataAccess.Repository;
using MVVM;

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
            get => _repositoryType;
            set {
                _repositoryType = value;
                NotifyPropertyChanged();
            }
        }

        public Order SelectedOrder {
            get => _selectedOrder;
            set {
                _selectedOrder = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Customer> Customers {
            get => _customers;
            set {
                _customers = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Order> Orders {
            get => _orders;
            set {
                _orders = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand GetDataCommand => new RelayCommand(o => GetData(), o => IocApp.IsRegistered(RepositoryType));

        private void GetData()
        {
            //_repository = IocApp.Container.Resolve<IRepository>();
            _repository = IocApp.GetRepository(RepositoryType);
            Orders = new ObservableCollection<Order>(_repository.Orders);
            Customers = new ObservableCollection<Customer>(_repository.Customers);
        }
    }
}