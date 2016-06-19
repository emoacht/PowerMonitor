using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PowerMonitor;

namespace PowerChecker
{
	class Program
	{
		static void Main(string[] args)
		{
			Debug.WriteLine(PowerCompany.ExportList(true));

			if (File.Exists(PowerCompany.CompanyFileName))
			{
				var source = File.ReadAllText(PowerCompany.CompanyFileName);
				if (PowerCompany.ImportList(source))
					Debug.WriteLine("Loaded company list.");
			}

			if (PowerCompany.UpdateListAsnyc().Result)
			{
				File.WriteAllText(PowerCompany.CompanyFileName, PowerCompany.ExportList());
				Debug.WriteLine("Saved company list.");
			}

			foreach (var company in PowerCompany.Companies)
				Debug.WriteLine(company.Name);

			Task.WhenAll(PowerCompany.Companies.Select(async x => await x.CheckAsync())).Wait();

			foreach (var company in PowerCompany.Companies.Where(x => x.Data.IsLoaded))
			{
				Debug.WriteLine($"{company.Name}: {company.Data.UsageAmount} ({company.Data.DataTime:HH:mm}) / {company.Data.PeakSupply} -> {company.Data.UsagePercentage:f1}%");
			}
		}
	}
}