using System.Reactive.Linq;
using System.Threading.Tasks;
using Belatrix.Connect.Core.Dtos;
using Belatrix.Connect.Core.Services;
using Belatrix.Connect.Portable.Model;
using ReactiveUI;

namespace Belatrix.Connect.Portable.ViewModels
{
	public class LoginViewModel : ReactiveObject
	{
		private LoginModel _loginModel;

		public LoginModel LoginModel
		{
			get { return _loginModel; }
			set { this.RaiseAndSetIfChanged(ref _loginModel, value); }
		}

		public ReactiveCommand<LoginModel, AuthenticationResponse> ExecuteLogin { get; protected set; }

		ObservableAsPropertyHelper<bool> _isExecutingLogin;
		public bool SpinnerVisibility => _isExecutingLogin.Value;

		public LoginViewModel()
		{
			ExecuteLogin = ReactiveCommand.CreateFromTask<LoginModel, AuthenticationResponse>(Login);
			this.WhenAnyValue(x => x.LoginModel)
				.Where(x => x.IsValid)
				.InvokeCommand(ExecuteLogin);
		}

		private async Task<AuthenticationResponse> Login(LoginModel model)
		{
			var result = await new EmployeeService().Authenticate(model.UserName, model.Password);

			if (!result.IsValidUser)
			{
				//TODO: Show error to user
			}

			return null;
		}
	}
}
