using Common.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DigiLearn.Web.Infrastructure.RazorUtils
{

    [ValidateAntiForgeryToken]
    public class BaseRazorToast : PageModel
    {
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (context.HandlerMethod.MethodInfo.Name == "OnPost")
                if (!context.ModelState.IsValid)
                {
                    var result = OperationResult.Error(JoinErrors());
                    TempData["SystemAlert"] = JsonConvert.SerializeObject(result);
                    context.Result = Page();
                }

            base.OnPageHandlerExecuting(context);
        }

        protected IActionResult RedirectAndShowAlert(OperationResult result, IActionResult redirectPath, IActionResult errorRedirect)
        {
            TempData["SystemAlert"] = JsonConvert.SerializeObject(result);
            if (result.Status != OperationResultStatus.Success)
                return errorRedirect;

            return redirectPath;
        }

        protected IActionResult RedirectAndShowAlert(OperationResult result, IActionResult redirectPath)
        {
            TempData["SystemAlert"] = JsonConvert.SerializeObject(result);
            if (result.Status != OperationResultStatus.Success)
                return Page();

            return redirectPath;
        }

        protected IActionResult RedirectAndShowAlert(OperationResult<Guid> result, IActionResult redirectPath)
        {
            TempData["SystemAlert"] = JsonConvert.SerializeObject(result);
            if (result.Status != OperationResultStatus.Success)
                return Page();
            return redirectPath;
        }

        protected void SuccessAlert()
        {
            var result = OperationResult.Success();
            TempData["SystemAlert"] = JsonConvert.SerializeObject(result);
        }

        protected void SuccessAlert(string message)
        {
            var result = OperationResult.Success(message);
            TempData["SystemAlert"] = JsonConvert.SerializeObject(result);
        }

        protected void ErrorAlert()
        {
            var result = OperationResult.Error();
            TempData["SystemAlert"] = JsonConvert.SerializeObject(result);
        }

        protected void ErrorAlert(string message)
        {
            var result = OperationResult.Error(message);
            TempData["SystemAlert"] = JsonConvert.SerializeObject(result);
        }

        private string JoinErrors()
        {
            return string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
        }
    }
}