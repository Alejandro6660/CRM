using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Enums
{
    public enum StatusDocument
    {
        [Description("New")]
        Active = 1,
        [Description("Delated")]
        Delated = 2,
    }
}
