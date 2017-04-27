using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace FormsCrossPlatform
{
    public partial class MainPage : ContentPage
    {
        private readonly ObservableCollection<Contact> _contacts;

        public MainPage()
        {
            InitializeComponent();

            _contacts = new ObservableCollection<Contact>();
            _contactList.ItemsSource = _contacts;

            _add.Clicked += (s, e) =>
            {
                _contacts.Add(new Contact
                {
                    Name = _name.Text,
                    Email = _email.Text
                });
            };
        }
    }
}
