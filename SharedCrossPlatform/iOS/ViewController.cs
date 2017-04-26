using System;

using UIKit;

namespace SharedCrossPlatform.iOS
{
	public partial class ViewController : UIViewController
	{
		private readonly CounterService _service;

		public ViewController(IntPtr handle) : base(handle)
		{
			_service = new CounterService();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Perform any additional setup after loading the view, typically from a nib.
			Button.AccessibilityIdentifier = "myButton";
			Button.TouchUpInside += delegate
			{
				_service.Count();
				Button.SetTitle(_service.Message, UIControlState.Normal);
				Button.SetTitleColor(_service.MessageColor, UIControlState.Normal);
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
