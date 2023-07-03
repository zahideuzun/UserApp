using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.AppCore.Results.Bases
{
	public abstract class Result
	{
		public bool IsSuccessful { get; }
		public string Message { get; set; }

		public Result(bool isSuccessful, string message)
		{
			IsSuccessful = isSuccessful;
			Message = message;
		}
	}
}
