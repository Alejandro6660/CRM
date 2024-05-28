using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Models
{
    public class GetUsersModel
    {
        public Int64 Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Initials { get; set; }

        public string RolUser { get; set; }

    }
}
