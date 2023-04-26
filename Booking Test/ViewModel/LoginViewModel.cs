using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Windows.Input;
using Booking_Test.Model;
using Booking_Test.Repositories;
using System.Net;
using System.Threading;
using System.Security.Principal;

namespace Booking_Test.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private SecureString _password;
        private string _roll;
        private string _permission;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;

        // Properties
        public string Username 
        { 
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString Password 
        { 
            get => _password;
            set 
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }  
        }
        public string Roll 
        { 
            get => _roll;
            set 
            { 
                _roll = value;
                OnPropertyChanged(nameof(Roll));
            }
        }
        public string Permission 
        { 
            get => _permission;
            set 
            { 
                _permission = value;
                OnPropertyChanged(nameof(Permission));
            }
        }
        public string ErrorMessage 
        { 
            get => _errorMessage;
            set 
            { 
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            } 
        }
        public bool IsViewVisible 
        { 
            get => _isViewVisible;
            set 
            { 
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            } 
        }

        // -> Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }


          
        // Constructor
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }

        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrEmpty(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid username or password!";
            }
        }
    }
}
