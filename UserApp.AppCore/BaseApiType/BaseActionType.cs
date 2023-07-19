using Microsoft.AspNetCore.Mvc;

namespace UserApp.AppCore.BaseApiType
{
    public static class BaseActionType
	{
		/// <summary>
		/// action resultlarin kontrolünü yapan base metot
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static IActionResult ReturnResponse(object data)
		{
			if (data == null)
			{
				return new BadRequestResult();
			}
			return new OkObjectResult(data);
		}
	}
}
