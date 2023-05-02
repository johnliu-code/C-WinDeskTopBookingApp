using Booking_Test.Model;
using Booking_Test.Repositories;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Input;
using System.CodeDom.Compiler;

namespace Booking_Test.ViewModel
{
    public class ReservationViewModel : ViewModelBase
    {
        private CustomerModel _currentCustomer;
        private ReservationModel _currentReservation;
        private DateTime _checkinDate;
        private ObservableCollection<CustomerModel> _customers;
        private string _customerName;

        private ObservableCollection<ReservationModel> _reservations;
        private ICustomerRepository customerRepository;
        private IReservationRepository reservationRepository;

        public CustomerModel CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                _currentCustomer = value;
                OnPropertyChanged(nameof(CurrentCustomer));
            }
        }

        public ReservationModel CurrentReservation
        {
            get => _currentReservation;
            set
            {
                _currentReservation = value;
                OnPropertyChanged(nameof(CurrentReservation));
            }
        }
        public ObservableCollection<ReservationModel> Reservations
        {
            get => _reservations;
            set
            {
                _reservations = value;
                OnPropertyChanged(nameof(Reservations));
            }
        }

        public DateTime CheckinDate
        {
            get => _checkinDate;
            set
            {
                _checkinDate = value;
                OnPropertyChanged(nameof(CheckinDate));
            }
        }

        public string CustomerName
        {
            get => _customerName;
            set
            {
                _customerName = value;
                OnPropertyChanged(nameof(CustomerName));
            }
        }

        public ObservableCollection<CustomerModel> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        //Commands
        public ICommand GetCustomerCommand { get; }
        public ICommand GetReservationsCommand { get; }
        public ICommand AddReservationCommand { get; }
        public ICommand DeleteReservationCommand { get; }
        public ICommand ModifyReservationCommand { get; }
        public ICommand ClearInputsCommand { get; }

        //Constructor
        public ReservationViewModel()
        {
            customerRepository = new CustomerRepository();
            reservationRepository = new ReservationRepository();
            CurrentCustomer = new CustomerModel();
            CurrentReservation = new ReservationModel();
            

            GetCustomerCommand = new ViewModelCommand(ExecuteGetCustomerCommand);
            GetReservationsCommand = new ViewModelCommand(ExecuteGetReservationsCommand);
            AddReservationCommand = new ViewModelCommand(ExecuteAddReservationCommand);
            ClearInputsCommand = new ViewModelCommand(ExecuteClearInputsCommand);
            ModifyReservationCommand = new ViewModelCommand(ExecuteModifyReservationCommand);
            DeleteReservationCommand = new ViewModelCommand(ExecuteDeleteReservationCommand);

            CustomerName = "Valdemar";
            ExecuteGetCustomerCommand(null);
            ExecuteGetReservationsCommand(null);
        }

        private void ExecuteGetCustomerCommand(object obj)
        {
            CurrentCustomer = new CustomerModel();
            CurrentCustomer = customerRepository.GetByCustomerId(3);
        }

        private void ExecuteAddReservationCommand(object obj)
        {
            if (CurrentReservation != null)
            {
                reservationRepository.Add(CurrentReservation);
                ExecuteGetReservationsCommand(null);
            }
        }

        private void ExecuteClearInputsCommand(object obj)
        {
            if (CurrentReservation != null)
            {
                CurrentReservation = new ReservationModel();
            }
        }

        private void ExecuteModifyReservationCommand(object obj)
        {
            if (CurrentReservation != null)
            {
                reservationRepository.Edit(CurrentReservation);
                ExecuteGetReservationsCommand(null);
            }
        }

        private void ExecuteDeleteReservationCommand(object obj)
        {
            if (CurrentReservation != null)
            {
                reservationRepository.Remove(CurrentReservation.Id);
                ExecuteGetReservationsCommand(null);
            }
        }

        private void ExecuteGetReservationsCommand(object obj)
        {
            Reservations = new ObservableCollection<ReservationModel>();
            //Reservations = reservationRepository.GetByCustomerId(3);
            Reservations = reservationRepository.GetAll();
        }

    }
}
