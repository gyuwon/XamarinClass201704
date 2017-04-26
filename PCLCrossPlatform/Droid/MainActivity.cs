using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;

namespace PCLCrossPlatform.Droid
{
	[Activity(Label = "PCLCrossPlatform", MainLauncher = true, Icon = "@mipmap/icon")]
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
				button.SetTextColor(_service.ShouldMessageBeHighlighted ? Color.LightSalmon : Color.White);
			};
		}
	}
}
