using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Booking_Test.Model;
using Booking_Test.Repositories;
using FontAwesome.Sharp;

namespace Booking_Test.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        // Fields
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        private IUserRepository userRepository;

        // Properties
        public UserAccountModel CurrentUserAccount
        {
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get => _currentChildView;
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
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

        //--> Commands
        public ICommand ShowHomeViewCommand {get;}
        public ICommand ShowReservationViewCommand { get; }
        public ICommand ShowCustomersViewCommand { get; }
        public ICommand ShowUsersViewCommand { get; }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            //Initialize commands
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowReservationViewCommand = new ViewModelCommand(ExecuteShowReservationViewCommand);
            ShowCustomersViewCommand = new ViewModelCommand(ExecuteShowCustomersViewCommand);
            ShowUsersViewCommand = new ViewModelCommand(ExecuteShowUsersViewCommand);

            //Default view
            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteShowReservationViewCommand(object obj)
        {
            CurrentChildView = new ReservationViewModel();
            Caption = "Reservation";
            Icon = IconChar.PhoneVolume;
        }

        private void ExecuteShowUsersViewCommand(object obj)
        {
            CurrentChildView = new UsersViewModel();
            Caption = "Users";
            Icon = IconChar.User;
        }

        private void ExecuteShowCustomersViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Caption = "Customers";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.UserName = user.Username;
                CurrentUserAccount.Displayname = $"{user.Username}, {user.Roll}";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.Displayname = "Invalid user, not logged in!";
                // Hide child views
            }
        }
    }
}
