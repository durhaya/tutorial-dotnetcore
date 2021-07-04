using ProjectApi.ModelValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApi.Models
{
    public class Ticket
    {
        public int? TicketId { get; set; }
        public int? ProjectId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Owner { get; set; }
        [Ticket_EnsureDueDateForTicketOwner]
        [Ticket_EnsureDueDateInFuture]
        public DateTime? DueDate { get; set; }
        public DateTime? EnteredDate { get; set; }
    }
}
