using System.Threading.Tasks;
using Belatrix.Connect.Core.Dtos;

namespace Belatrix.Connect.Core.Services
{
	public interface IEmployeeService
	{
		Task<AuthenticationResponse> Authenticate(string user, string password);
		Task<Employee> Get(int id);
	}
}
