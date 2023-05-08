using Booking_Test.Model;
using Booking_Test.Repositories;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Booking_Test.ViewModel
{
    public class CreditCardViewModel : ViewModelBase
    {
        private string _caption;
        private IconChar _icon;
        private CustomerModel _currentCustomer;
        private CreditCardModel _selectedCreditCard;
        private CreditCardModel _creditCard;
        private ObservableCollection<CreditCardModel> _creditCards;
        public int CustomerID { get;}

        private ICustomerRepository customerRepository;
        private ICreditCardRepository creditcardRepository;

        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
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

        public CreditCardModel SelectedCreditCard
        {
            get => _selectedCreditCard;
            set
            {
                _selectedCreditCard = value;
                OnPropertyChanged(nameof(SelectedCreditCard));
                if(SelectedCreditCard != null)
                    CreditCard = SelectedCreditCard;
            }
        }


        public CreditCardModel CreditCard
        {
            get => _creditCard;
            set
            {
                _creditCard = value;
                OnPropertyChanged(nameof(CreditCard));
            }
        }

        public ObservableCollection<CreditCardModel> CreditCards
        {
            get => _creditCards;
            set
            {
                _creditCards = value;
                OnPropertyChanged(nameof(CreditCards));
            }
        }

        //Commands
        public ICommand GetCustomerCommand { get; }
        public ICommand GetCustomerCreditCardCommand { get; }
        public ICommand AddCreditCardCommand { get; }
        public ICommand DeleteCreditCardCommand { get; }
        public ICommand ModifyCreditCardCommand { get; }
        public ICommand ClearInputsCommand { get; }

        //Constructor
        public CreditCardViewModel(int id)
        {
            CustomerID = id;           
            Caption = "CreditCard";
            Icon = IconChar.CreditCard;

            customerRepository = new CustomerRepository();
            creditcardRepository = new CreditCardRepository();
            SelectedCreditCard = new CreditCardModel();
            CreditCard = new CreditCardModel();

            GetCustomerCommand = new ViewModelCommand(ExecuteGetCustomerCommand);
            GetCustomerCreditCardCommand = new ViewModelCommand(ExecuteGetCustomerCreditCardCommand);
            AddCreditCardCommand = new ViewModelCommand(ExecuteAddCreditCardCommand);
            ClearInputsCommand = new ViewModelCommand(ExecuteClearInputsCommand);
            ModifyCreditCardCommand = new ViewModelCommand(ExecuteModifyCreditCardCommand);
            DeleteCreditCardCommand = new ViewModelCommand(ExecuteDeleteCreditCardCommand);

            ExecuteGetCustomerCommand(null);
            ExecuteGetCustomerCreditCardCommand(null);
        }

        private void ExecuteAddCreditCardCommand(object obj)
        {
            if(CreditCard != null)
            {
                creditcardRepository.Add(CreditCard);
                ExecuteGetCustomerCreditCardCommand(null);
            }
        }

        private void ExecuteClearInputsCommand(object obj)
        {
            if (CreditCard != null)
            {
                CreditCard = new CreditCardModel();
            }
        }

        private void ExecuteModifyCreditCardCommand(object obj)
        {
            if (SelectedCreditCard != null)
            {
                creditcardRepository.Edit(CreditCard);
                ExecuteGetCustomerCreditCardCommand(null);
            }
        }

        private void ExecuteDeleteCreditCardCommand(object obj)
        {
            if (SelectedCreditCard != null && CreditCards.Count() > 1)
            {
                creditcardRepository.Remove(SelectedCreditCard.Id);
                ExecuteGetCustomerCreditCardCommand(null);
            }
        }

        private void ExecuteGetCustomerCreditCardCommand(object obj)
        {
            CreditCards = new ObservableCollection<CreditCardModel>();
            CreditCards = creditcardRepository.GetByCustomerId(CustomerID);
            //CreditCards = creditcardRepository.GetAll(CreditCards);
            if (SelectedCreditCard != null)
                CreditCard = SelectedCreditCard;
        }

        private void ExecuteGetCustomerCommand(object obj)
        {
            CurrentCustomer = new CustomerModel();
            CurrentCustomer = customerRepository.GetByCustomerId(CustomerID);
        }
    }
}
