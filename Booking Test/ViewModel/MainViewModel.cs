using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Booking_Test.Model;
using Booking_Test.Repositories;

namespace Booking_Test.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        // Fields
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount
        {
            get => _currentUserAccount;
            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {

                CurrentUserAccount.UserName = user.Username;
                CurrentUserAccount.Displayname = $"Welcome {user.Username}, {user.Roll} :) ";
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
