using Belatrix.Connect.Portable.Views;
using Prism.Unity;

namespace Belatrix.Connect.Portable
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();

			NavigationService.NavigateAsync("LoginView");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<LoginView>();
		}
	}
}
