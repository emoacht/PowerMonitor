using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PowerMonitor.Helper;

namespace PowerMonitor
{
	public class PowerData
	{
		#region Electric power data

		/// <summary>
		/// Time when the data is updated (time designated as UPDATE)
		/// </summary>
		public DateTimeOffset UpdateTime { get; private set; }

		/// <summary>
		/// Supply capacity (x10 MW) during peak hours of current date
		/// </summary>
		public double PeakSupply { get; private set; }

		/// <summary>
		/// Time when the latest usage amount is recorded
		/// </summary>
		public DateTimeOffset DataTime { get; private set; }

		/// <summary>
		/// The latest usage amount (x10 MW)
		/// </summary>
		public double UsageAmount { get; private set; }

		/// <summary>
		/// The latest usage percentage (%)
		/// </summary>
		public double UsagePercentage => (0 < PeakSupply)
			? (UsageAmount / PeakSupply * 100D)
			: 0D;

		#endregion

		public PowerData(string source)
		{
			Load(source);
		}

		#region Load

		/// <summary>
		/// Source data retrieved from power company (in csv format)
		/// </summary>
		public string Source { get; private set; }

		/// <summary>
		/// Whether the data is correctly loaded
		/// </summary>
		public bool IsLoaded { get; private set; }

		/// <summary>
		/// The starting part of the header for peak supply section
		/// </summary>
		private static readonly string[] PeakSupplyHeaderStart = new[] { "ピーク時供給力", "需要ピーク時供給力" };

		/// <summary>
		/// The starting part of the header for usage amount section (this must be searched from the bottom)
		/// </summary>
		private const string ActualUsageHeaderStart = "DATE,TIME,当日実績";

		private void Load(string source)
		{
			this.Source = source;

			if (string.IsNullOrWhiteSpace(source))
				return;

			var records = source.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();

			// Get update time.
			var updateFields = records[0].Split();
			if (updateFields.Length >= 2)
			{
				if (DateTimeOffset.TryParse($"{updateFields[0]} {updateFields[1]}", out DateTimeOffset updateTimeBuffer))
					UpdateTime = updateTimeBuffer.ToJst();
			}

			int peakSupplyHeaderIndex = records.FindIndex(x => PeakSupplyHeaderStart.Any(y => x.StartsWith(y)));
			int actualUsageHeaderIndex = records.FindLastIndex(x => x.StartsWith(ActualUsageHeaderStart));

			if ((0 <= peakSupplyHeaderIndex) && (0 <= actualUsageHeaderIndex))
			{
				// Get peak supply.
				var supplyFields = records[peakSupplyHeaderIndex + 1].Split(',');
				if (supplyFields.Length >= 1)
				{
					if (double.TryParse(supplyFields[0], out double peakSupplyBuffer))
						PeakSupply = peakSupplyBuffer;
				}

				DateTimeOffset currentDate = DateTimeOffset.Now.ToJst().Date;

				foreach (var usageRecord in records.Skip(actualUsageHeaderIndex + 1))
				{
					if (string.IsNullOrWhiteSpace(usageRecord))
						break;

					var usageFields = usageRecord.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
					if (usageFields.Length < 3)
						break;

					// Get data time.
					if (DateTimeOffset.TryParse(usageFields[0], out DateTimeOffset dateTimeBuffer))
					{
						dateTimeBuffer = dateTimeBuffer.ToJst();

						// Check if the date is current date.
						if (dateTimeBuffer != currentDate)
							break;

						if (TimeSpan.TryParse(usageFields[1], out TimeSpan timeBuffer))
							DataTime = dateTimeBuffer.Add(timeBuffer);
					}

					// Get usage amount.
					if (double.TryParse(usageFields[2], out double usageAmountBuffer))
					{
						if (usageAmountBuffer <= 0)
							break;

						UsageAmount = usageAmountBuffer;
					}
				}
			}

			IsLoaded = (default(DateTimeOffset) < UpdateTime)
				&& (0 < PeakSupply)
				&& (default(DateTimeOffset) < DataTime)
				&& (0 < UsageAmount);
		}

		#endregion
	}
}