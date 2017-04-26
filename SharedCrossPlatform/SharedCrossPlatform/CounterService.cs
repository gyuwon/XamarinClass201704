#if __IOS__
using UIKit;
#endif

namespace SharedCrossPlatform
{
	public class CounterService
	{
		private int _count = 0;

		public string Message => $"{_count} clicks!";

#if __IOS__
		public UIColor MessageColor => _count % 5 == 0 ? UIColor.Red : null;
#endif

		public void Count() => _count++;
	}
}
