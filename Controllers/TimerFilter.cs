using System;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

public class TimerFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        context.HttpContext.Items["HasIgnoreAction"] = true;
        if (HasIgnoreAction(context)) { return; }

        string action = (string)context.RouteData.Values["action"];
        string controller = (string)context.RouteData.Values["controller"];
        context.HttpContext.Items[controller + "_" + action] = DateTime.Now;
        context.HttpContext.Items["HasIgnoreAction"] = false;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if ((bool)context.HttpContext.Items["HasIgnoreAction"]==false)
        {
            string action = (string)context.RouteData.Values["action"];
            string controller = (string)context.RouteData.Values["controller"];
            DateTime startTime = (DateTime)context.HttpContext.Items[controller + "_" + action];
            DateTime endTime = DateTime.Now;
            TimeSpan diff = endTime.Subtract(startTime);
            string description = String.Format("{0}:{1}:{2}", diff.Hours, diff.Minutes, diff.Seconds);
            double totalSeconds = diff.TotalSeconds;
            using (ActionContext dbContext = new ActionContext())
            {
                ActionPerformance data = new ActionPerformance();
                data.ActionName = action;
                data.ControllerName = controller;
                data.CreatedDate = DateTime.Now;
                data.Description = description;
                data.TotalSeconds = totalSeconds;
                dbContext.ActionPerformance.Add(data);
                dbContext.SaveChanges();
            }
        }
    }

    public bool HasIgnoreAction(ActionExecutingContext context)
    {        
        foreach (var filterDescriptors in ((ControllerActionDescriptor)context.ActionDescriptor).MethodInfo.CustomAttributes)
        {
            if (filterDescriptors.AttributeType == typeof(IgnoreAction))
            {
                return true;
            }
        }
        return false;
    }
}