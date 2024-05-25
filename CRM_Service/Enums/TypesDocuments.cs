using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Enums
{
    public enum TypesDocuments
    {
        [Description("Sales")]
        Sales = 1,
        [Description("Quotes")]
        Quotes = 2,
        [Description("Proposals")]
        Proposals = 3,
        [Description("Marketing")]
        Marketing = 4,
        [Description("InternalDocuments")]
        InternalDocuments = 5,
        [Description("Engenier")]
        Engenier = 6,
        [Description("Images")]
        Images = 7,
        [Description("Customers")]
        Customers = 8,
    }
}
