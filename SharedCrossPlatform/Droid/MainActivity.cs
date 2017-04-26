using Android.App;
using Android.Widget;
using Android.OS;

namespace SharedCrossPlatform.Droid
{
	[Activity(Label = "SharedCrossPlatform", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		private readonly CounterService _service = new CounterService();

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);

			button.Click += delegate
			{
				_service.Count();
				button.Text = _service.Message;
			};
		}
	}
}

