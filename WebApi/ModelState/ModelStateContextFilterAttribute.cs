namespace SystemDot.Web.WebApi.ModelState
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using System.Web.Http.ModelBinding;
    using SystemDot.Core;

    public class ModelStateContextFilterAttribute : ActionFilterAttribute
    {
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            CurrentModelStateLocator.Set(GetModelState(actionContext));
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        static ModelStateDictionary GetModelState(HttpActionContext actionContext)
        {
            return actionContext.ControllerContext.Controller.As<ApiController>().ModelState;
        }
    }
}