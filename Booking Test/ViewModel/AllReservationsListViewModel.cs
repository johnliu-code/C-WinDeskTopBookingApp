using Booking_Test.Model;
using Booking_Test.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Booking_Test.ViewModel
{
    public class AllReservationsListViewModel : ViewModelBase
    {
        private ReservationModel _currentReservation;
        private DateTime _checkinDate;
        private ReservationModel _selectedItem;

        private ObservableCollection<ReservationModel> _reservations;

        private IReservationRepository reservationRepository;

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


        public ReservationModel SelectedItem
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
                        CurrentReservation = SelectedItem;
                    }
                }
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

        //Commands
        public ICommand GetReservationsCommand { get; }
        public ICommand AddReservationCommand { get; }
        public ICommand DeleteReservationCommand { get; }
        public ICommand ModifyReservationCommand { get; }
        public ICommand ClearInputsCommand { get; }

        //Constructor
        public AllReservationsListViewModel()
        {
            reservationRepository = new ReservationRepository();
            CurrentReservation = new ReservationModel();

            GetReservationsCommand = new ViewModelCommand(ExecuteGetReservationsCommand);
            AddReservationCommand = new ViewModelCommand(ExecuteAddReservationCommand);
            ClearInputsCommand = new ViewModelCommand(ExecuteClearInputsCommand);
            ModifyReservationCommand = new ViewModelCommand(ExecuteModifyReservationCommand);
            DeleteReservationCommand = new ViewModelCommand(ExecuteDeleteReservationCommand);

            ExecuteGetReservationsCommand(null);
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
            Reservations = reservationRepository.GetAll();
            if (SelectedItem != null)
            {
                CurrentReservation = SelectedItem;
            }
        }

    }
}
