using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.AppCore.Results.Bases
{
	//todo abstract oldugunda hata aliyorum en son bi bak. bu haliyle calisiyo ama abstract olmasi gerek
	public class Result
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
