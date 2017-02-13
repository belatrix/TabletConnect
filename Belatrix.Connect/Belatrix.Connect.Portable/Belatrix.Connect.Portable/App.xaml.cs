using Belatrix.Connect.Core.Services;
using Belatrix.Connect.Portable.Interfaces;
using Belatrix.Connect.Portable.Views;
using Belatrix.Data;
using Microsoft.Practices.Unity;
using Prism.Services;
using Prism.Unity;
using DependencyService = Xamarin.Forms.DependencyService;

namespace Belatrix.Connect.Portable
{
	public partial class App : PrismApplication
	{
		private static BelatrixConnectDatabase _database;
		public static BelatrixConnectDatabase Database
		{
			get
			{
				if (_database != null)
				{
					return _database;
				}

				_database = new BelatrixConnectDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("BelatrixConnect.db3"));

				return _database;
			}
		}

		public App(IPlatformInitializer initializer = null) : base(initializer)
		{
			
		}

		protected override void OnInitialized()
		{
			InitializeComponent();

			NavigationService.NavigateAsync(nameof(LoginView));
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<LoginView>();
			Container.RegisterType<IPageDialogService, PageDialogService>();
			Container.RegisterType<IEmployeeService, EmployeeService>();
		}
	}
}
