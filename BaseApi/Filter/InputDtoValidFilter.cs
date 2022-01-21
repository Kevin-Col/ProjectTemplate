using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Model.Emun;
using Model.OutputDto;
using System.Linq;
namespace BaseApi.Filter
{
    public class InputDtoValidFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
                return;
            string errMsg = string.Join(',', context.ModelState.Values.SelectMany(s => s.Errors.Select(ss => ss.ErrorMessage)));
            context.Result = new JsonResult(new ApiResponse<string>(ApiCode.Faild, errMsg, ""));
        }
    }
}
