using CRM_Service.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Models
{
    public class UserInsertModel
    {

        public string Name { get; set; }
                     
        public string LastName { get; set; }
                     
        public string NameUser { get; set; }
                     
        public string Initials { get; set; }
                     
        public string Email { get; set; }
                     
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
                     
        public string Phone { get; set; }

        public string PhoneEmergency { get; set; }
                     
        public string Address { get; set; }
                     
        public string ZIP { get; set; }

        public string RFC { get; set; }

        public bool IsPayroll { get; set; }

        public DateTime CreatedDate { get; set; }

        public int RolUserId { get; set; }

        public Int64 ImageId { get; set; }
    }
}
