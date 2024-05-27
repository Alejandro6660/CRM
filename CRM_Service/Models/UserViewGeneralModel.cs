using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Models
{
    public class UserViewGeneralModel
    {
        public Int64 Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public int RolUserId { get; set; }
    }
}
