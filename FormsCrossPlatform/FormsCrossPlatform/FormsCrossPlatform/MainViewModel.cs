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
                _viewModel.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(NameField) ||
                        e.PropertyName == nameof(EmailField))
                    {
                        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                    }
                };
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
                => !string.IsNullOrWhiteSpace(_viewModel.NameField)
                && !string.IsNullOrWhiteSpace(_viewModel.EmailField);

            public void Execute(object parameter)
            {
                _viewModel._contacts.Add(new Contact
                {
                    Name = _viewModel.NameField,
                    Email = _viewModel.EmailField
                });

                _viewModel.NameField = string.Empty;
                _viewModel.EmailField = string.Empty;
            }
        }
    }
}
