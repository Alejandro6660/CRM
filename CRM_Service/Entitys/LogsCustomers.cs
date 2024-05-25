using CRM_Service.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Entitys
{
    public class LogsCustomers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public virtual Customers Customer { get; set; }

        public string? Coment { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Required]
        public StatusCustomer StatusChange { get; set; }
    }
}
