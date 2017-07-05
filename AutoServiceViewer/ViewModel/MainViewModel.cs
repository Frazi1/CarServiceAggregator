using DataAccess;
using DataAccess.Model;
using MVVM;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using System.Diagnostics;

namespace AutoServiceViewer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IRepository _repository;
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<Order> _orders;
        private Customer _selectedCustomer;
        private Order _selectedOrder;

        public MainViewModel()
        {
            Customers = new ObservableCollection<Customer>();
            Orders = new ObservableCollection<Order>();
            GetDataCommand.CanExecuteChanged += Test;
        }

        private void Test(object sender, EventArgs e)
        {
            Debug.WriteLine("Execute Changed Invoked");
        }

        public Customer SelectedCustomer {
            get { return _selectedCustomer; }
            set {
                _selectedCustomer = value;
                NotifyPropertyChanged();
            }
        }
        public Order SelectedOrder {
            get { return _selectedOrder; }
            set {
                _selectedOrder = value;
                NotifyPropertyChanged();
                SetSelectedCustomer();
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

        public ICommand GetDataCommand => new RelayCommand(o => GetData(), o => IocApp.Container.IsRegistered<IRepository>());



        private void GetData()
        {
            //_repository = IocApp.Container.Resolve<IRepository>();
            //_repository = IocApp.XMLContainer.Resolve<IRepository>();
            //_repository = IocApp.Container.ResolveAll<IRepository>().FirstOrDefault(s => s != null);
            _repository = IocApp.Container.Resolve<IRepository>();
            Orders = new ObservableCollection<Order>(_repository.Orders);
            Customers = new ObservableCollection<Customer>(_repository.Customers);
        }

        private void SetSelectedCustomer()
        {
            SelectedCustomer = Customers.FirstOrDefault(c => c.ID == SelectedOrder?.CustomerID);
        }

        
    }
}
