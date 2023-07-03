using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.Results.Bases;

namespace UserApp.AppCore.Results
{
	public class ErrorResult : Result
	{
		public ErrorResult(string message) : base(false, message)
		{
		}

		public ErrorResult() : base(false, "")
		{
		}
	}
}
