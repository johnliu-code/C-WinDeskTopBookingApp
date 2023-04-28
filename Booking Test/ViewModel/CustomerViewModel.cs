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
        private ReservationModel _selectedItem;

        private IReservationRepository reservationRepository;
        private ViewModelBase _currentView;

        // Properties

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
                        Reservation = SelectedItem;
                    }
                }
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

        public ReservationModel Reservation
        {
            get => _reservation;
            set
            {
                _reservation = value;
                OnPropertyChanged(nameof(Reservation));
            }
        }
      
        public ObservableCollection<ReservationModel> Reservations { get; set; }
        public ObservableCollection<ReservationModel> ReservationsAll { get; set; }

        // -> Commands
        public ICommand LoginCommand { get; }
        public ICommand AddReservationCommand { get; }
        public ICommand ShowReservationCommand { get; }
        public ICommand DeleteReservationCommand { get; }
        public ICommand ShowAllReservationCommand { get; }
        public ICommand ModifyReservationCommand { get; }
        public ICommand ClearInputsCommand { get; }
        public ICommand QuitReservationCommand { get; }
        //public event Action CloseViewRequested;



        // Constructor
        public CustomerViewModel()
        {
            reservationRepository = new ReservationRepository();
            CurrentReservation = new ReservationModel();
            ShowReservationCommand = new ViewModelCommand(ExecuteShowReservationCommand);
            ShowAllReservationCommand = new ViewModelCommand(ExecuteShowAllReservationCommand);
            Reservations = new ObservableCollection<ReservationModel>();
            ReservationsAll = new ObservableCollection<ReservationModel>();
            AddReservationCommand = new ViewModelCommand(ExecuteAddReservationCommand);
            ClearInputsCommand = new ViewModelCommand(ExecuteClearInputsCommand);
            QuitReservationCommand = new ViewModelCommand(ExecuteQuitReservationCommand);
            ModifyReservationCommand = new ViewModelCommand(ExecuteModifyReservationCommand);
            DeleteReservationCommand = new ViewModelCommand(ExecuteDeleteReservationCommand);

        }

        private void ExecuteDeleteReservationCommand(object obj)
        {
            if (SelectedItem != null)
            {
                var reservationSearchedId = SelectedItem.Id;

                reservationRepository.Remove(reservationSearchedId);

            }
            this.ExecuteShowAllReservationCommand(obj);
        }

        private void ExecuteModifyReservationCommand(object obj)
        {
            if (SelectedItem != null)
            {
                var reservationSearchedId = SelectedItem.Id;
                CurrentReservation = Reservation;

                reservationRepository.Edit(CurrentReservation, reservationSearchedId);

            }
            this.ExecuteShowAllReservationCommand(obj);

        }



        private void ExecuteQuitReservationCommand(object obj)
        {
            Console.WriteLine("Executing QuitReservationCommand");

            var currentControl = obj as UserControl;

            Console.WriteLine(currentControl.ToString());

            if (currentControl != null)
            {
                var mainWindow = Window.GetWindow(currentControl) as MainView;

                if (mainWindow != null)
                {
                    Console.WriteLine("Closing current window and returning to MainView");
                    mainWindow.Content = new MainView();
                }
            }
        }

        private void ExecuteClearInputsCommand(object obj)
        {
            Reservation = new ReservationModel();
        }

        private void ExecuteAddReservationCommand(object obj)
        {
            CurrentReservation = Reservation;

            reservationRepository.Add(CurrentReservation);

            this.ExecuteShowAllReservationCommand(obj);
        }

        private void ExecuteShowAllReservationCommand(object obj)
        {
            //ReservationsAll.Clear();
            Reservations.Clear();
            //var reservationsAll = reservationRepository.GetAll();
            //if (reservationsAll.Count > 0)
            var reservations = reservationRepository.GetAll();
            if (reservations.Count > 0)
            {   //foreach (var reservation in reservationsAll)
                foreach (var reservation in reservations)
                {

                    Console.WriteLine($"Reservation ID: {reservation.ReservationId}");
                    Console.WriteLine($"First Name: {reservation.Firstname}");
                    Console.WriteLine($"Last Name: {reservation.Lastname}");
                    Console.WriteLine($"Number of guests: {reservation.Number}");
                    Console.WriteLine($"Phone number: {reservation.Phone}");
                    Console.WriteLine($"Email: {reservation.Email}");
                    Console.WriteLine($"Address: {reservation.Address}");
                    Console.WriteLine($"Room Number: {reservation.RoomNumber}");
                    Console.WriteLine("------------");
                    CurrentReservation = reservation;
                    //ReservationsAll.Add(reservation);
                    Reservations.Add(reservation);

                }
            }
            else
            {
                // Display a message or clear the CurrentReservation property
                CurrentReservation = null;
            }
        }

        private void ExecuteShowReservationCommand(object obj)
        {
            Reservations.Clear();
            if (Firstname == null && Lastname == null)
            {
                MessageBox.Show("First Name and Last Name can't be empty at the same time!");
            }
            else
            {
                var reservations = reservationRepository.GetByReservationUsername(Firstname);
                if (reservations.Count > 0)
                {
                    foreach (var reservation in reservations)
                    {
                        var existingReservation = Reservations.FirstOrDefault(r => r.ReservationId == reservation.ReservationId);
                        if (existingReservation == null)
                        {
                            // Reservation does not exist in the collection, add it
                            Reservations.Add(reservation);
                            CurrentReservation = reservation;
                        }
                        else
                        {
                            // Reservation already exists in the collection, set it as the current reservation
                            CurrentReservation = existingReservation;
                        }
                    }
                }
                else
                {
                    // Display a message or clear the CurrentReservation property
                    CurrentReservation = null;
                }
            }
        }

    }
}
