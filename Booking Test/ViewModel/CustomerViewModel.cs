using Booking_Test.Model;
using Booking_Test.Repositories;
using Booking_Test.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace Booking_Test.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {

        //Fields
        private CustomerModel _customer;
        private CustomerModel _currentCustomer;
        private CustomerModel _selectedItem;
        private CustomerModel _searchItem;
        public int CustomerID { get; set; }

        private ICustomerRepository customerRepository;

        // Properties

        public CustomerModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                    if (SelectedItem != null)
                    {
                        Customer = SelectedItem;
                    }
                }
            }
        }

        public CustomerModel SearchItem
        {
            get { return _searchItem; }
            set
            {
                if (_searchItem != value)
                {
                    _searchItem = value;
                    OnPropertyChanged(nameof(SearchItem));
                }
            }
        }

        public CustomerModel CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                _currentCustomer = value;
                OnPropertyChanged(nameof(CurrentCustomer));
            }
        }

        public CustomerModel Customer
        {
            get => _customer;
            set
            {
                _customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }

        private ObservableCollection<CustomerModel> _customers;
        public ObservableCollection<CustomerModel> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        // -> Commands
        public ICommand AddCustomerCommand { get; }
        public ICommand DeleteCustomerCommand { get; }
        public ICommand ShowAllCustomersCommand { get; }
        public ICommand ModifyCustomerCommand { get; }
        public ICommand ClearInputsCommand { get; }
        public ICommand OpenCreditCardWindowCommand { get; }


        // Constructor
        public CustomerViewModel()
        {
            customerRepository = new CustomerRepository();
            Customer = new CustomerModel();
            ShowAllCustomersCommand = new ViewModelCommand(ExecuteShowAllCustomersCommand);
            AddCustomerCommand = new ViewModelCommand(ExecuteAddCustomerCommand);
            ClearInputsCommand = new ViewModelCommand(ExecuteClearInputsCommand);
            ModifyCustomerCommand = new ViewModelCommand(ExecuteModifyCustomerCommand);
            DeleteCustomerCommand = new ViewModelCommand(ExecuteDeleteCustomerCommand);
            OpenCreditCardWindowCommand = new ViewModelCommand(ExecuteOpenCreditCardWindowCommand);

            this.ExecuteShowAllCustomersCommand(null);
        }

        private void ExecuteOpenCreditCardWindowCommand(object obj)
        {
            if (Customer != null)
            {
                CustomerID = Customer.Id;

                Window crediteCardWindow = new CreditCardView();
                var newViewModel = new CreditCardViewModel(CustomerID);
                crediteCardWindow.DataContext = newViewModel;
                crediteCardWindow.Show();
            }
            else
            {
                MessageBox.Show("There is no Customer Selected...");
            }    
        }

        private void ExecuteDeleteCustomerCommand(object obj)
        {
            if (SelectedItem != null)
            {
                customerRepository.Remove(SelectedItem.Id);
            }
            this.ExecuteShowAllCustomersCommand(obj);
        }

        private void ExecuteModifyCustomerCommand(object obj)
        {
            if (Customer != null)
            {
                customerRepository.Edit(Customer);
            }
            this.ExecuteShowAllCustomersCommand(obj);

        }

        private void ExecuteClearInputsCommand(object obj)
        {
            Customer = new CustomerModel();
        }

        private void ExecuteAddCustomerCommand(object obj)
        {
            customerRepository.Add(Customer);
            this.ExecuteShowAllCustomersCommand(obj);
        }

        private void ExecuteShowAllCustomersCommand(object obj)
        {
            Customers = new ObservableCollection<CustomerModel>();
            customerRepository.GetAll(Customers);
            if (SelectedItem != null)
            {
                Customer = SelectedItem;
            }
        }

    }
}
