using System;
using System.ComponentModel;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new ObservableUser("Tony Stark");

            user.PropertyChanged += OnUserPropertyChanged;

            user.Username = "Ironman";
        }

        private static void OnUserPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ObservableUser.Username))
            {
                var user = (ObservableUser)sender;
                Console.WriteLine($"Hello {user.Username}");
            }
        }
    }

    public class ObservableUser : INotifyPropertyChanged
    {
        private string _username;

        public ObservableUser(string username)
        {
            _username = username;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;

                // 1. 다중 스레딩 취약
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Username"));

                // 2. 다중 스레딩 안전
                ////var eventHandler = PropertyChanged;

                ////if (eventHandler != null)
                ////    eventHandler.Invoke(this, new PropertyChangedEventArgs("Username"));

                // 3. Null 전파 사용
                ////PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Username"));
            }
        }
    }
}
