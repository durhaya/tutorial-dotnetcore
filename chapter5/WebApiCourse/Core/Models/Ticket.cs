using Core.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Ticket
    {
        public int? TicketId { get; set; }
        [Required]
        public int? ProjectId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [StringLength(50)]
        public string Owner { get; set; }

        [Ticket_EnsureDueDatePresent]
        [Ticket_EnsureFutureDueDateOnCreate]
        [Ticket_EnsureDueDateAfterReportDate]
        public DateTime? DueDate { get; set; }
        
        [Ticket_EnsureReportDatePresent]
        public DateTime? ReportDate { get; set; }

        /// <summary>
        /// when owner is assigned, the due date has to be present
        /// </summary>
        public bool ValidateDueDatePresence()
        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;
            return DueDate.HasValue;
        }

        /// <summary>
        /// when creating a ticket, if due date is entered, it has to be future date
        /// </summary>
        public bool ValidateFutureDueDate()
        {
            if (TicketId.HasValue) return true;
            if (!DueDate.HasValue) return true;
            return (DueDate.Value > DateTime.Now);
        }

        /// <summary>
        /// when owner is assigned, the report date has to be present
        /// </summary>
        public bool ValidateReportDatePresence()
        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;
            return ReportDate.HasValue;
        }

        /// <summary>
        /// when due date and report date is present, then due date has to greater that report date
        /// </summary>
        public bool ValidateDueDateAfterReportDate()
        {
            if (!DueDate.HasValue || !ReportDate.HasValue) return true;
            return DueDate.Value.Date >= ReportDate.Value.Date;
        }
    }
}
