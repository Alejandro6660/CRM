﻿using CRM_Service.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Entitys
{
    public class LogsCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        [ForeignKey("UserId")]
        public Int64 UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("CustomerId")]
        public Int64 CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        public string? Coment { get; set; }

        public DateTime? CreatedDate { get; set; }

        [Required]
        public StatusCustomer StatusChange { get; set; }
    }
}
