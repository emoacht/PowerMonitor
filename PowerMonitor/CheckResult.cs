
namespace PowerMonitor
{
	public enum CheckResult
	{
		/// <summary>
		/// None
		/// </summary>
		None = 0,

		/// <summary>
		/// The power data has been modified and successfully loaded.
		/// </summary>
		Success,

		/// <summary>
		/// The device is not connected to network.
		/// </summary>
		NotConnected,

		/// <summary>
		/// The power data has not been modified since last checking.
		/// </summary>
		NotModified,

		/// <summary>
		/// The checking operation has failed by other reason.
		/// </summary>
		Failed
	}
}