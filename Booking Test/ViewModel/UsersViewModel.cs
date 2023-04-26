using Booking_Test.Model;
using Booking_Test.Repositories;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Booking_Test.ViewModel
{
    public class UsersViewModel : ViewModelBase
    {
        // Fields
        private UserModel _user;
        private UserModel _selecteduser;
        private UserModel _currentuser;
        private ObservableCollection<UserModel> _users;
        private string search_username;


        private IUserRepository userRepository;

        // Properties
        public UserModel User
        {
            get => 
                _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public UserModel SelectedUser
        {
            get => _selecteduser;
            set
            {
                _selecteduser = value;
                OnPropertyChanged(nameof(SelectedUser));
                if (SelectedUser != null)
                    User = SelectedUser;
            }
        }

        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public string SearchUsername
        {
            get => search_username;
            set
            {
                search_username = value;
                OnPropertyChanged(nameof(SearchUsername));
            }
        }

        //--> Commands
        public ICommand AddNewUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand FindUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand ClearFieldsCommand { get; }

        public UsersViewModel()
        {
            userRepository = new UserRepository();
            User = new UserModel();

            //Initialize commands
            AddNewUserCommand = new ViewModelCommand(ExecuteAddNewUserCommand);
            UpdateUserCommand = new ViewModelCommand(ExecuteUpdateUserCommand);
            FindUserCommand = new ViewModelCommand(ExecuteFindUserCommand);
            DeleteUserCommand = new ViewModelCommand(ExecuteDeleteUserCommand);
            ClearFieldsCommand = new ViewModelCommand(ExecuteClearFieldsCommand);

            LoadAllUsersData();

        }

        private void ExecuteClearFieldsCommand(object obj)
        {
            if (User != null)
               User = new UserModel();
        }

        private void ExecuteFindUserCommand(object obj)
        {
            if (SearchUsername != null)
            {
                User = userRepository.GetByUsername(SearchUsername);

                if (User != null) SelectedUser = User;
            }
        }

        private void ExecuteDeleteUserCommand(object obj)
        {
            userRepository.Remove(User.Id);
            LoadAllUsersData();
        }

        private void ExecuteUpdateUserCommand(object obj)
        {
            userRepository.Edit(User);
            LoadAllUsersData();
        }

        private void ExecuteAddNewUserCommand(object obj)
        {
            userRepository.Add(User);
            Users.Add(User);
            LoadAllUsersData();
        }

        private void LoadAllUsersData()
        {
            Users = new ObservableCollection<UserModel>();
            userRepository.GetAll(Users);  
            if (SelectedUser != null) 
            {
                User = SelectedUser;
            }
        }
    }
}
