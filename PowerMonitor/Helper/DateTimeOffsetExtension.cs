using System;

namespace PowerMonitor.Helper
{
	internal static class DateTimeOffsetExtension
	{
		/// <summary>
		/// Converts to JST (Japan Standard Time)
		/// </summary>
		/// <param name="original">Original DateTimeOffset</param>
		/// <returns>DateTimeOffset in JST</returns>
		public static DateTimeOffset ToJst(this DateTimeOffset original) => original.ToOffset(TimeSpan.FromHours(9));
	}
}