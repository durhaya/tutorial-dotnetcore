using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApi.Filters
{
    public class Ticket_ValidateDatesActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ticket = context.ActionArguments["ticket"] as Ticket;
            if (ticket != null && !string.IsNullOrWhiteSpace(ticket.Owner))
            {
                bool isValid = true;
                if (!ticket.EnteredDate.HasValue)
                {
                    context.ModelState.AddModelError("EnteredDate", "Entered date is required when the ticket has an owner");
                    isValid = false;
                }
                if (ticket.EnteredDate.HasValue && ticket.DueDate.HasValue
                    && ticket.EnteredDate > ticket.DueDate)
                {
                    context.ModelState.AddModelError("DueDate", "Due date has to later than EnteredDate");
                    isValid = false;
                }
                if (!isValid)
                {
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }
        }
    }
}
