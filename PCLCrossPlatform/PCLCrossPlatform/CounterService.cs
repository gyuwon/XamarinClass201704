namespace PCLCrossPlatform
{
	public class CounterService
	{
		private int _count = 0;

		public string Message => $"{_count} clicks!";

		public bool ShouldMessageBeHighlighted => _count % 5 == 0;

		public void Count() => _count++;
	}
}
