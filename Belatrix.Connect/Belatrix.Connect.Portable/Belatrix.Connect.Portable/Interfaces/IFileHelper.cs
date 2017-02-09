using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.Connect.Portable.Interfaces
{
	public interface IFileHelper
	{
		string GetLocalFilePath(string databaseName);
	}
}
