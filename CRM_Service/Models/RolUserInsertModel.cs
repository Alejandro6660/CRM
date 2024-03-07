using CRM_Service.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Models
{
    public class RolUserInsertModel
    {
        public string Name { get; set; }
        public StatusRol Status { get; set; }
    }
}
