using DataAccess;
using DataAccess.Model;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutoServiceViewer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IRepository _repository;
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<Order> _orders;


        public Customer SelectedCustomer { get; set; }
        public Order SelectedOrder { get; set; }

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

        public MainViewModel(IRepository repository)
        {
            Customers = new ObservableCollection<Customer>();
            Orders = new ObservableCollection<Order>();
            _repository = repository;
        }

        public ICommand GetDataCommand => new RelayCommand(o => GetData());

        private void GetData()
        {
            Orders = new ObservableCollection<Order>(_repository.Orders);
            Customers = new ObservableCollection<Customer>(_repository.Customers);
        }

    }
}
