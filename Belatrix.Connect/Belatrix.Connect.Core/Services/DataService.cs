using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Belatrix.Connect.Core.Services
{
	public abstract class DataService
	{
		//TODO: Move this string to configuration
		private const string BaseUri = "https://bxconnect.herokuapp.com";
		protected string _token;

		protected DataService()
		{
		}

		protected DataService(string token)
		{
			_token = token;
		}

		public static async Task<T> Get<T>(string queryString, string token)
            where T : class
		{
			var client = new HttpClient
			{
				BaseAddress = new Uri(BaseUri)
			};

			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", token);

			var response = await client.GetAsync(queryString);

			if (response == null)
			{
				return null;
			}

			var json = response.Content.ReadAsStringAsync().Result;
			return JsonConvert.DeserializeObject<T>(json);
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

			if (result == null)
			{
				return null;

			}

			var json = result.Content.ReadAsStringAsync().Result;
			return JsonConvert.DeserializeObject<T>(json);
		}

		protected static string MakeUri(string baseUri, string parameter)
		{
			return $"{baseUri}{parameter}/";
		}
	}
}
