using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LAB11.Filters;

public class UserCounterFilter : IActionFilter
{
    private static int uniqueUserCount;
    private static readonly HashSet<string> uniqueUsers = new();

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var userName = context.HttpContext.User.Identity.Name;
        if (uniqueUsers.Add(userName))
        {
            uniqueUserCount++;
            File.WriteAllText("userCount.txt", $"Unique User Count: {uniqueUserCount}");
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Debug.WriteLine(uniqueUserCount);
    }
}