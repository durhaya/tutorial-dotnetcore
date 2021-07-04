using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApi.Filters
{
    public class Ticket_EnsureEnteredDateActionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ticket = context.ActionArguments["ticket"] as Ticket;
            if (ticket != null
                && !string.IsNullOrWhiteSpace(ticket.Owner)
                && !ticket.EnteredDate.HasValue)
            {
                context.ModelState.AddModelError("EnteredDate", "Entered date is required when the ticket has an owner");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
