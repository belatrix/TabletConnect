using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Belatrix.Connect.Core.Proxies
{
	public class DataService
	{
		//TODO: Move this string to configuration
		private const string BaseUri = "https://bxconnect.herokuapp.com";

		public static async Task<T> Get<T>(string queryString) where T : class
		{
			var client = new HttpClient();
			var response = await client.GetAsync(BaseUri + queryString);

			T data = null;

			if (response != null)
			{
				string json = response.Content.ReadAsStringAsync().Result;
				data = JsonConvert.DeserializeObject<T>(json);
			}

			return data;
		}

		public static async Task<T> Post<T>(string uri, IList<KeyValuePair<string, string>> formParams)
			where T : class
		{
			var client = new HttpClient
			{
				BaseAddress = new Uri(BaseUri)
			};

			var content = new FormUrlEncodedContent(formParams);
			var result = await client.PostAsync(uri, content);

			T data = null;

			if (result != null)
			{
				string json = result.Content.ReadAsStringAsync().Result;
				data = JsonConvert.DeserializeObject<T>(json);
			}

			return data;
		}
	}
}
