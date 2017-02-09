using System.Threading.Tasks;
using Belatrix.Connect.Core.Dtos;
using SQLite;

namespace Belatrix.Data
{
	public class BelatrixConnectDatabase
	{
		private readonly SQLiteAsyncConnection _database;
		private const string AuthenticationResponseTable = "AuthenticationResponse";

		public BelatrixConnectDatabase(string path)
		{
			_database = new SQLiteAsyncConnection(path);
			_database.CreateTableAsync<AuthenticationResponse>().Wait();
		}

		public Task<AuthenticationResponse> GetAuthenticationDataAsync()
		{
			return _database.Table<AuthenticationResponse>().FirstOrDefaultAsync();
		}

		public async Task SaveAuthenticationResponse(AuthenticationResponse authenticationResponse)
		{
			await _database.QueryAsync<AuthenticationResponse>($"DELETE FROM {AuthenticationResponseTable}");

			await _database.InsertAsync(authenticationResponse);
		}
	}
}
