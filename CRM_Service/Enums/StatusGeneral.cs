using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Enums
{
    public enum StatusGeneral
    {
        [Description("New")]
        Active = 1,
        [Description("Delated")]
        Delated = 2,
        [Description("Revition")]
        Revition = 3,
    }
}
