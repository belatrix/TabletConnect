using Belatrix.Connect.Portable.Interfaces;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Belatrix.Connect.Portable.Droid.Helpers.FileHelper))]
namespace Belatrix.Connect.Portable.Droid.Helpers
{ 
	public class FileHelper : IFileHelper
	{
		public string GetLocalFilePath(string databaseName)
		{
			var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			return Path.Combine(path, databaseName);
		}
	}
}