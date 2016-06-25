using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PowerMonitor;
using PowerTracker.Common;

namespace PowerTracker.ViewModels
{
	public class CompanyViewModel : BindableBase
	{
		private readonly PowerCompany _company;

		public CompanyViewModel(PowerCompany company)
		{
			this._company = company;
		}

		public string Name => _company.Name;

		public int PeakSupply
		{
			get { return _peakSupply; }
			set { SetProperty(ref _peakSupply, value); }
		}
		private int _peakSupply;

		public int UsageAmount
		{
			get { return _usageAmount; }
			set { SetProperty(ref _usageAmount, value); }
		}
		private int _usageAmount;

		public double UsagePercentage
		{
			get { return _usagePercentage; }
			set { SetProperty(ref _usagePercentage, value); }
		}
		private double _usagePercentage;

		public DateTimeOffset DataTime
		{
			get { return _dataTime; }
			set { SetProperty(ref _dataTime, value); }
		}
		private DateTimeOffset _dataTime;

		public ObservableCollection<DateTimeOffset> DataUpdateTimes { get; } = new ObservableCollection<DateTimeOffset>();

		private DateTimeOffset _updateTimeLast;

		public async Task CheckAsync()
		{
			var checkTime = DateTimeOffset.Now;

			if (await _company.CheckAsync() != CheckResult.Success)
				return;

			if (_updateTimeLast == _company.Data.UpdateTime)
				return;

			if (_updateTimeLast > default(DateTimeOffset))
			{
				DataUpdateTimes.Insert(0, checkTime.ToOffset(TimeSpan.FromHours(9))); // JST
			}
			_updateTimeLast = _company.Data.UpdateTime;

			this.PeakSupply = (int)Math.Round((_company.Data?.PeakSupply).GetValueOrDefault(), MidpointRounding.AwayFromZero);
			this.UsageAmount = (int)Math.Round((_company.Data?.UsageAmount).GetValueOrDefault(), MidpointRounding.AwayFromZero);
			this.UsagePercentage = (_company.Data?.UsagePercentage).GetValueOrDefault();
			this.DataTime = (_company.Data?.DataTime).GetValueOrDefault();

			Debug.WriteLine($"Updated: {Name}");
		}
	}
}