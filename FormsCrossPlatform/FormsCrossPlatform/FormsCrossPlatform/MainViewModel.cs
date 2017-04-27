using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FormsCrossPlatform
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _nameField;
        private string _emailField;
        private readonly ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>();
        private readonly ICommand _addCommand;

        public MainViewModel()
        {
            _addCommand = new AddContactCommand(this);
        }

        public string NameField
        {
            get { return _nameField; }
            set { Set(ref _nameField, value); }
        }

        public string EmailField
        {
            get { return _emailField; }
            set { Set(ref _emailField, value); }
        }

        public IEnumerable<Contact> Contacts => _contacts;

        public ICommand AddCommand => _addCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private class AddContactCommand : ICommand
        {
            private readonly MainViewModel _viewModel;

            public AddContactCommand(MainViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter) => true;

            public void Execute(object parameter)
            {
                _viewModel._contacts.Add(new Contact
                {
                    Name = _viewModel._nameField,
                    Email = _viewModel._emailField
                });
            }
        }
    }
}
