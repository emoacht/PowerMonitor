using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace PowerMonitor
{
	[DataContract(Namespace = "")]
	internal class PowerCompanyList
	{
		/// <summary>
		/// Date when this company list is created
		/// </summary>
		public DateTimeOffset ListDate
		{
			get { return DateTimeOffset.Parse(_listDate, CultureInfo.InvariantCulture); }
			set { _listDate = value.ToString(CultureInfo.InvariantCulture); }
		}
		[DataMember(Order = 0, Name = nameof(ListDate))]
		private string _listDate;

		/// <summary>
		/// Url where the latest company list should be found
		/// </summary>
		[DataMember(Order = 1)]
		public string ListUrl { get; set; }

		/// <summary>
		/// Company list
		/// </summary>
		[DataMember(Order = 2)]
		public PowerCompany[] Companies { get; set; }

		#region Deserialize/Serialize

		public static PowerCompanyList DeserializeList(string source)
		{
			if (string.IsNullOrWhiteSpace(source))
				return null;

			var serializer = new DataContractJsonSerializer(typeof(PowerCompanyList));

			try
			{
				using (var ms = new MemoryStream())
				using (var sw = new StreamWriter(ms))
				{
					sw.Write(source);
					sw.Flush();
					ms.Seek(0, SeekOrigin.Begin);

					return serializer.ReadObject(ms) as PowerCompanyList;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Failed to deserialize company list.\r\n{ex}");
				return null;
			}
		}

		public static string SerializeList(PowerCompanyList companyList)
		{
			if (companyList == null)
				return null;

			var serializer = new DataContractJsonSerializer(typeof(PowerCompanyList));

			try
			{
				using (var ms = new MemoryStream())
				{
					serializer.WriteObject(ms, companyList);

					return Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Failed to serialize company list.\r\n{ex}");
				return null;
			}
		}

		#endregion

		#region Create

		public static PowerCompanyList CreateList()
		{
			var companies = new PowerCompany[]
			{
				new PowerCompany
				(
					name: "北海道電力",
					url: @"http://denkiyoho.hepco.co.jp/area/data/juyo_01_[yyyyMMdd]", // Date part must be replaced with current date.
					interval: 5,
					offset: 250
				),
				new PowerCompany
				(
					name: "東北電力",
					url: @"http://setsuden.tohoku-epco.co.jp/common/demand/juyo_02_[yyyyMMdd].csv", // Date part must be replaced with current date.
					interval: 5,
					offset: 180
				),
				new PowerCompany
				(
					name: "東京電力",
					url: @"http://www.tepco.co.jp/forecast/html/images/juyo-j.csv",
					interval: 5,
					offset: 180
				),
				new PowerCompany
				(
					name: "北陸電力",
					url: @"http://www.rikuden.co.jp/denki-yoho/csv/juyo_05_[yyyyMMdd].csv", // Date part must be replaced with current date.
					interval: 10,
					offset: 200
				),
				new PowerCompany
				(
					name: "中部電力",
					url: @"http://denki-yoho.chuden.jp/denki_yoho_content_data/juyo_cepco003.csv",
					interval: 5,
					offset: 0
				),
				new PowerCompany
				(
					name: "関西電力",
					url: @"http://www.kepco.co.jp/yamasou/juyo1_kansai.csv",
					interval: 5,
					offset: 50
				),
				new PowerCompany
				(
					name: "中国電力",
					url: @"http://www.energia.co.jp/jukyuu/sys/juyo_07_[yyyyMMdd].csv", // Date part must be replaced with current date.
					interval: 5,
					offset: 270
				),
				new PowerCompany
				(
					name: "四国電力",
					url: @"http://www.yonden.co.jp/denkiyoho/juyo_shikoku.csv",
					interval: 5,
					offset: 30
				),
				new PowerCompany
				(
					name: "九州電力",
					url: @"http://www.kyuden.co.jp/power_usages/csv/juyo-hourly-[yyyyMMdd].csv", // Date part must be replaced with current date.
					interval: 5,
					offset: 270
				),
				new PowerCompany
				(
					name: "沖縄電力",
					url: @"http://www.okiden.co.jp/denki/juyo_10_[yyyyMMdd].csv", // Date part must be replaced with current date.
					interval: 5,
					offset: 20
				)
			};

			return new PowerCompanyList
			{
				ListDate = DateTimeOffset.Now,
				ListUrl = @"https://raw.githubusercontent.com/emoacht/PowerMonitor/master/PowerMonitor/companies.json",
				Companies = companies
			};
		}

		#endregion
	}
}