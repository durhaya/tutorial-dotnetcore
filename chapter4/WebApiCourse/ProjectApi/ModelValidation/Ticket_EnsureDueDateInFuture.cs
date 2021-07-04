using ProjectApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApi.ModelValidation
{
    public class Ticket_EnsureDueDateInFuture : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;
            if (ticket != null && ticket.TicketId == null && ticket.DueDate.HasValue)
            {
                if (ticket.DueDate.Value <= DateTime.Now)
                {
                    return new ValidationResult("Due date should be in future.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
