using curso.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace curso.api.Filters
{
    public class ValidacaoModelStateCustomizado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var validaCampoViewModelOutput = new ValidaCampoViewModelOutput(context.ModelState.SelectMany(er => er.Value.Errors).Select(s => s.ErrorMessage));
                context.Result = new BadRequestObjectResult(validaCampoViewModelOutput);
            }
        }
    }
}
