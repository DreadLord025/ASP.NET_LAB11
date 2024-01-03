using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LAB11.Filters;

public class ActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var controllerName = context.RouteData.Values["controller"];
        var actionName = context.RouteData.Values["action"];
        var logMessage = $"Action Method: {actionName} in Controller: {controllerName} was accessed at {DateTime.Now}";
        File.AppendAllText("log.txt", logMessage + Environment.NewLine);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Debug.WriteLine($"Action was accessed at {DateTime.Now}");
    }
}