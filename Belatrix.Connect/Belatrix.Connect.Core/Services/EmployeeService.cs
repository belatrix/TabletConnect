using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Belatrix.Connect.Core.Dtos;

namespace Belatrix.Connect.Core.Services
{
	public class EmployeeService : DataService
	{
		private const string ApiUri = "/api/employee/";

		public EmployeeService()
		{
		}

		public EmployeeService(string token) : base(token)
		{
		}

		public async Task<Employee> Get(int id)
		{
			if (string.IsNullOrEmpty(_token))
			{
				throw new UnauthorizedAccessException("You must login in order access this information.");
			}

			var results = await Get<Employee>(MakeUri(id.ToString()), _token);

			return results;
		}

		public async Task<AuthenticationResponse> Authenticate(string user, string password)
		{
			var results = await Post<AuthenticationResponse>(MakeUri("authenticate"),
				new List<KeyValuePair<string, string>>()
				{
					new KeyValuePair<string, string>("username", user),
					new KeyValuePair<string, string>("password", password)
				});

			return results;
		}

		private static string MakeUri(string parameter)
		{
			return $"{ApiUri}{parameter}/";
		}

		public void AddToken(string dataToken)
		{
			_token = dataToken;
		}
	}
}