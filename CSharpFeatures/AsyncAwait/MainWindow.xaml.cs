using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;

namespace AsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void _clearResult_Click(object sender, RoutedEventArgs e)
        {
            _getResult.Text = string.Empty;
        }

        private void _get_Click(object sender, RoutedEventArgs e)
        {
            _progressIndicator.IsActive = true;

            var response = _httpClient.GetAsync(_uri.Text).Result;

            _getResult.Text = response.IsSuccessStatusCode
                ? response.Content.ReadAsStringAsync().Result
                : $"Error({response.StatusCode})";

            _progressIndicator.IsActive = false;
        }

        private void _getTpl_Click(object sender, RoutedEventArgs e)
        {
            _progressIndicator.IsActive = true;

            _httpClient.GetAsync(_uri.Text)
                .ContinueWith((Task<HttpResponseMessage> t) =>
                {
                    var response = t.Result;
                    return response.IsSuccessStatusCode
                        ? response.Content.ReadAsStringAsync()
                        : Task.FromResult($"Error({response.StatusCode})");
                })
                .Unwrap()
                .ContinueWith((Task<string> t) =>
                {
                    Dispatcher.InvokeAsync(() =>
                    {
                        _getResult.Text = t.Result;
                        _progressIndicator.IsActive = false;
                    });
                });
        }

        private async void _getAwait_Click(object sender, RoutedEventArgs e)
        {
            _progressIndicator.IsActive = true;

            var response = await _httpClient.GetAsync(_uri.Text);

            _getResult.Text = response.IsSuccessStatusCode
                ? await response.Content.ReadAsStringAsync()
                : $"Error({response.StatusCode})";

            _progressIndicator.IsActive = false;
        }
    }
}
