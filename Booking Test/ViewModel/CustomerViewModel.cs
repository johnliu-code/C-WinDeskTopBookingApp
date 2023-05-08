﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking_Test.Model;
using Booking_Test.Repositories;
using System.Security;
using System.Windows.Input;
using System.Net;
using System.Threading;
using System.Security.Principal;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Booking_Test.View;

using System.Windows;
using System.Windows.Media;

namespace Booking_Test.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {

        //Fields     
        public int _reservationId;
        public string _firstname;
        public string _lastname;
        public int _number;
        public int _customerId;
        public string _phone;
        public string _email;
        public string _address;
        public int _roomNumber;
        private ReservationModel _currentReservation;
        private ReservationModel _selectedItem;
        private ReservationDetailsModel _currentReservationDetails;
        private ReservationDetailsModel _reservationDetail;

        private IReservationRepository reservationRepository;
        private ICustomerRepository customerRepository;
        private ViewModelBase _currentView;

        // Properties

        public ViewModelBase CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
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
                        //Firstname = _selectedItem.Firstname;
                        //Lastname = _selectedItem.Lastname;
                        //Phone = _selectedItem.Phone;
                        //Email = _selectedItem.Email;
                        //Address = _selectedItem.Address;
                        CustomerId = _selectedItem.CustomerId;
                        RoomNumber = _selectedItem.RoomNumber;
                        Number = _selectedItem.Number;
                    }
                }
            }
        }


        public ReservationDetailsModel CurrentReservationDetails
        {
            get => _currentReservationDetails;
            set
            {
                _currentReservationDetails = value;
                OnPropertyChanged(nameof(CurrentReservationDetails));
            }
        }

        public ReservationDetailsModel ReservationDetail
        {
            get => _reservationDetail;
            set
            {
                _reservationDetail = value;
                OnPropertyChanged(nameof(ReservationDetail));
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

        public int ReservationId
        {
            get => _reservationId;
            set
            {
                _reservationId = value;
                OnPropertyChanged(nameof(ReservationId));
            }
        }

        public int CustomerId
        {
            get => _reservationId;
            set
            {
                _reservationId = value;
                OnPropertyChanged(nameof(ReservationId));
            }
        }

        public string Firstname
        {
            get => _firstname;
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }
        public string Lastname
        {
            get => _lastname;
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public int Number
        {
            get => _number;
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        public int RoomNumber
        {
            get => _roomNumber;
            set
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }


        public ObservableCollection<ReservationModel> Reservations { get; set; }
        public ObservableCollection<ReservationModel> ReservationsAll { get; set; }
        public ObservableCollection<ReservationDetailsModel> ReservationsDetails { get; set; }

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
            customerRepository = new CustomerRepository();
            CurrentReservation = new ReservationModel();
            ShowReservationCommand = new ViewModelCommand(ExecuteShowReservationCommand);
            ShowAllReservationCommand = new ViewModelCommand(ExecuteShowAllReservationCommand);
            Reservations = new ObservableCollection<ReservationModel>();
            ReservationsAll = new ObservableCollection<ReservationModel>();
            ReservationsDetails = new ObservableCollection<ReservationDetailsModel>();
          
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
                var reservationSearchedId = SelectedItem.ReservationId;            

                reservationRepository.Remove(reservationSearchedId);

            }
            this.ExecuteShowAllReservationCommand(obj);
        }

        private void ExecuteModifyReservationCommand(object obj)
        {
            if (SelectedItem != null)
            {
                var reservationSearchedId = SelectedItem.ReservationId;
                //CurrentReservation.Firstname = Firstname;
                //CurrentReservation.Lastname = Lastname;
                CurrentReservation.CustomerId = CustomerId;
                CurrentReservation.Number = Number;
                //CurrentReservation.Phone = Phone;
                //CurrentReservation.Email = Email;
                //CurrentReservation.Address = Address;
                CurrentReservation.RoomNumber = RoomNumber;

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
            Firstname = "";
            Lastname = "";
            Number = 0;
            Phone = "";
            Email = "";
            Address = "";
            RoomNumber = 0;
        }

        private void ExecuteAddReservationCommand(object obj)
        {
            CurrentReservation.ReservationId = Guid.NewGuid();
            //CurrentReservation.Firstname = Firstname;
            //CurrentReservation.Lastname = Lastname;
            CurrentReservation.CustomerId = Number;
            CurrentReservation.Number = Number;
            //CurrentReservation.Phone = Phone;
            //CurrentReservation.Email= Email;
            //CurrentReservation.Address= Address;
            CurrentReservation.RoomNumber= RoomNumber;

            reservationRepository.Add(CurrentReservation);

            this.ExecuteShowAllReservationCommand(obj);
        }

        private void ExecuteShowAllReservationCommand(object obj)
        {
            //ReservationsAll.Clear();
            ReservationsDetails.Clear();
            //var reservationsAll = reservationRepository.GetAll();
            //if (reservationsAll.Count > 0)
            var reservations = reservationRepository.GetAll();
            if (reservations.Count > 0)
            {   //foreach (var reservation in reservationsAll)
                foreach (var reservation in reservations)
                {
                    
                    Console.WriteLine($"Reservation ID: {reservation.ReservationId}");
                    Console.WriteLine($"Customer ID: {reservation.CustomerId}");
                    //Console.WriteLine($"First Name: {reservation.Firstname}");
                    //Console.WriteLine($"Last Name: {reservation.Lastname}");
                    Console.WriteLine($"Number of guests: {reservation.Number}");
                    //Console.WriteLine($"Phone number: {reservation.Phone}");
                    //Console.WriteLine($"Email: {reservation.Email}");
                    //Console.WriteLine($"Address: {reservation.Address}");
                    Console.WriteLine($"Room Number: {reservation.RoomNumber}");
                    Console.WriteLine("------------");
                   
                        var customer = customerRepository.GetByCustomerId(reservation.CustomerId);

                        var ReservationDetail = new ReservationDetailsModel();
                        //ReservationsAll.Add(reservation);

                        ReservationDetail.ReservationId = reservation.ReservationId;
                        ReservationDetail.CustomerId = reservation.CustomerId;
                        ReservationDetail.Number = reservation.Number;
                        ReservationDetail.RoomNumber = reservation.RoomNumber;
                        ReservationDetail.Firstname = customer.Firstname;
                        ReservationDetail.Lastname = customer.Lastname;
                        ReservationDetail.Address = customer.Address;
                        ReservationDetail.Phone = customer.Phone;
                        ReservationDetail.Email = customer.Email;

                        Console.WriteLine(ReservationDetail.ReservationId);
                        Console.WriteLine(ReservationDetail.Firstname);
                        Console.WriteLine(ReservationDetail.Lastname);
                        Console.WriteLine(ReservationDetail.Address);


                   
                    ReservationsDetails.Add(ReservationDetail);

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
            ReservationsDetails.Clear();
            if (Firstname == null && Lastname == null)
            {
               MessageBox.Show("First Name and Last Name can't be empty at the same time!");
            }
            else
            {
                var customers = customerRepository.GetByCustomerUsername(Firstname);
                Console.WriteLine($"customers.Count: {customers.Count}");
                if (customers.Count > 0)
                {
                    foreach (var customer in customers)
                    {
                        Console.WriteLine($"yyyyy: {customer.CustomerId}");
                        var reservations = reservationRepository.GetByCustomerId(customer.CustomerId);
                        

                        if (reservations.Count > 0)
                        {
                            foreach (var reservation in reservations)
                            {
                                var existingReservation = Reservations.FirstOrDefault(r => r.ReservationId == reservation.ReservationId);
                                if (existingReservation == null)
                                {
                                    // Reservation does not exist in the collection, add it
                                    //Reservations.Add(reservation);
                                    //CurrentReservation = reservation;

                                    var ReservationDetail = new ReservationDetailsModel();
                                 

                                    ReservationDetail.ReservationId = reservation.ReservationId;
                                    ReservationDetail.CustomerId = reservation.CustomerId;
                                    ReservationDetail.Number = reservation.Number;
                                    ReservationDetail.RoomNumber = reservation.RoomNumber;
                                    ReservationDetail.Firstname = customer.Firstname;
                                    ReservationDetail.Lastname = customer.Lastname;
                                    ReservationDetail.Address = customer.Address;
                                    ReservationDetail.Phone = customer.Phone;
                                    ReservationDetail.Email = customer.Email;

                                    Console.WriteLine(ReservationDetail.ReservationId);
                                    Console.WriteLine(ReservationDetail.Firstname);
                                    Console.WriteLine(ReservationDetail.Lastname);
                                    Console.WriteLine(ReservationDetail.Address);



                                    ReservationsDetails.Add(ReservationDetail);



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
       
    }
}
