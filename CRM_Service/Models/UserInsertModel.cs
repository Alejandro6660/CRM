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

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Phone { get; set; }
        public string? Addres { get; set; }
        public int RolUserId { get; set; }
        public string? Image { get; set; }
    }
}
