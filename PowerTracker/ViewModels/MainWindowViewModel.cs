using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

using PowerMonitor;
using PowerTracker.Common;

namespace PowerTracker.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		public ObservableCollection<CompanyViewModel> Companies { get; } = new ObservableCollection<CompanyViewModel>();

		public double CheckInterval
		{
			get { return _checkInterval; }
			set
			{
				SetProperty(ref _checkInterval, value);
				StartTimer();
			}
		}
		private double _checkInterval = 3;

		private readonly DispatcherTimer _checkTimer = new DispatcherTimer();
		private bool _isChecking;

		public MainWindowViewModel()
		{
			foreach (var company in PowerCompany.Companies)
				Companies.Add(new CompanyViewModel(company));

			_checkTimer.Tick += OnTick;
			StartTimer();
		}

		private void StartTimer()
		{
			if (_isChecking)
				return;

			_checkTimer.Stop();
			_checkTimer.Interval = TimeSpan.Zero;
			_checkTimer.Start();
		}

		private async void OnTick(object sender, EventArgs e)
		{
			try
			{
				_isChecking = true;

				Debug.WriteLine("Tick");

				_checkTimer.Stop();

				await Task.WhenAll(Companies.Select(async x => await x.CheckAsync()));

				_checkTimer.Interval = TimeSpan.FromSeconds(_checkInterval);
				_checkTimer.Start();
			}
			finally
			{
				_isChecking = false;
			}
		}
	}
}