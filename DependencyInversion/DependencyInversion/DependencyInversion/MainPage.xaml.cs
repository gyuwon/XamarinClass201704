using Xamarin.Forms;

namespace DependencyInversion
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            _speak.Clicked += (s, e) =>
            {
                var tts = DependencyService.Get<ITextToSpeech>();
                tts?.Speak(_speech.Text);
            };
        }
    }
}
