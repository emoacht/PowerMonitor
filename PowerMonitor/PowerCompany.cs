using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using PowerMonitor.Helper;

namespace PowerMonitor
{
	[DataContract(Namespace = "")]
	public class PowerCompany
	{
		#region Electric power company data

		/// <summary>
		/// Company name
		/// </summary>
		[DataMember(Order = 0)]
		public string Name { get; private set; }

		/// <summary>
		/// Url where the power data should be found
		/// </summary>
		[DataMember(Order = 1)]
		public string Url { get; private set; }

		/// <summary>
		/// Url where the power forecast should be found
		/// </summary>
		[DataMember(Order = 2)]
		public string ForecastUrl { get; private set; }

		/// <summary>
		/// Update interval of the power data (min)
		/// </summary>
		/// <remarks>This interval will not necessarily match interval of data times.</remarks>
		[DataMember(Order = 3)]
		public int Interval { get; private set; }

		/// <summary>
		/// Offset time length (sec) for delaying the time to check the power data 
		/// </summary>
		/// <remarks>This offset is to absorb the gap between actual update times and the times
		/// which starts from 0 min of each hour and moves at update intervals.</remarks>
		[DataMember(Order = 4)]
		public int Offset { get; private set; }

		#endregion

		public PowerCompany(string name, string url, int interval, int offset) : this(name, url, null, interval, offset)
		{ }

		public PowerCompany(string name, string url, string forecastUrl, int interval, int offset)
		{
			this.Name = name;
			this.Url = url;
			this.ForecastUrl = forecastUrl;
			this.Interval = interval;
			this.Offset = offset;
		}

		#region Check

		/// <summary>
		/// The latest power data
		/// </summary>
		public PowerData Data { get; private set; }

		/// <summary>
		/// The latest time when the power data is checked with success
		/// </summary>
		public DateTimeOffset CheckTime { get; private set; }

		/// <summary>
		/// Checks the power data.
		/// </summary>
		/// <returns>Result of checking operation</returns>
		public async Task<CheckResult> CheckAsync()
		{
			var url = Url.Replace("[yyyyMMdd]", DateTimeOffset.Now.ToJst().ToString("yyyyMMdd"));

			return await CheckAsync(url);
		}

		/// <summary>
		/// Checks the power data.
		/// </summary>
		/// <param name="ifModifiedSince">If-Modified-Since time</param>
		/// <returns>Result of checking operation</returns>
		public async Task<CheckResult> CheckAsync(DateTimeOffset ifModifiedSince)
		{
			var result = await CheckAsync();

			if ((result == CheckResult.NotModified) && (ifModifiedSince < CheckTime))
				return CheckResult.Success;

			return result;
		}

		private async Task<CheckResult> CheckAsync(string url)
		{
			if (!NetworkInterface.GetIsNetworkAvailable())
				return CheckResult.NotConnected;

			try
			{
				using (var client = new HttpClient())
				{
					var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url));
					request.Headers.IfModifiedSince = CheckTime.ToJst();

					var response = await client.SendAsync(request);
					switch (response.StatusCode)
					{
						case HttpStatusCode.OK:
							break;
						case HttpStatusCode.NotModified:
							return CheckResult.NotModified;
						default:
							return CheckResult.Failed;
					}

					using (var stream = await response.Content.ReadAsStreamAsync())
					using (var reader = new StreamReader(stream, Encoding.GetEncoding("Shift-JIS"), true))
					{
						var source = await reader.ReadToEndAsync();

						var data = new PowerData(source);
						if (!data.IsLoaded)
							return CheckResult.Failed;

						this.Data = data;
					}

					CheckTime = DateTimeOffset.Now;
					return CheckResult.Success;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Failed to check power data at {Name}.\r\n {ex}");
				return CheckResult.Failed;
			}
		}

		#endregion

		#region Companies

		/// <summary>
		/// Company list
		/// </summary>
		public static IReadOnlyList<PowerCompany> Companies => _companyList?.Companies;

		private static PowerCompanyList _companyList => _importedCompanyList ?? _defaultCompanyList.Value;

		private static PowerCompanyList _importedCompanyList;

		private static readonly Lazy<PowerCompanyList> _defaultCompanyList =
			new Lazy<PowerCompanyList>(() => PowerCompanyList.DeserializeList(ReadEmbeddedFile(CompanyFileName)));

		/// <summary>
		/// File name of company list
		/// </summary>
		public static readonly string CompanyFileName = "companies.json";

		/// <summary>
		/// Updates company list asynchronously.
		/// </summary>
		/// <returns>True if successfully updated. False if not.</returns>
		public static async Task<bool> UpdateListAsnyc()
		{
			if (!NetworkInterface.GetIsNetworkAvailable())
				return false;

			var listUrl = _companyList?.ListUrl;
			if (string.IsNullOrWhiteSpace(listUrl))
				return false;

			string source;

			using (var client = new HttpClient())
			{
				try
				{
					source = await client.GetStringAsync(listUrl);
				}
				catch (Exception ex)
				{
					Debug.WriteLine($"Failed to update power company list.\r\n{ex}");
					return false;
				}
			}

			return ImportList(source);
		}

		/// <summary>
		/// Imports company list.
		/// </summary>
		/// <param name="source">Source company list in JSON format</param>
		/// <param name="checkListDate">Whether to check the date of company list</param>
		/// <returns>True if successfully imported. False if not.</returns>
		public static bool ImportList(string source, bool checkListDate = true)
		{
			var companyList = PowerCompanyList.DeserializeList(source);
			if (companyList == null)
				return false;

			Debug.WriteLine($"ListDate: {companyList.ListDate}");

			if (checkListDate && (_companyList != null))
			{
				if (companyList.ListDate <= _companyList.ListDate)
					return false;
			}

			_importedCompanyList = companyList;
			return true;
		}

		/// <summary>
		/// Exports company list.
		/// </summary>
		/// <param name="createNewly">Whether to create company list newly</param>
		/// <returns>Company list in JSON format</returns>
		public static string ExportList(bool createNewly = false)
		{
			var companyList = (createNewly || (_companyList == null))
				? PowerCompanyList.CreateList()
				: _companyList;

			return PowerCompanyList.SerializeList(companyList);
		}

		private static string ReadEmbeddedFile(string fileName)
		{
			var qualifiedNameElements = typeof(PowerCompany).AssemblyQualifiedName.Split(',');
			if (qualifiedNameElements.Length < 2)
				return null;

			var assemblyName = qualifiedNameElements[1].Trim();
			var resourceName = $"{assemblyName}.{fileName}";

			try
			{
				var assembly = Assembly.Load(new AssemblyName(assemblyName));

				using (var stream = assembly.GetManifestResourceStream(resourceName))
				using (var reader = new StreamReader(stream))
					return reader.ReadToEnd();
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Failed to load an embedded file.\r\n{ex}");
				return null;
			}
		}

		#endregion
	}
}