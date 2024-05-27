using CRM_Service.Context;
using CRM_Service.Services.IManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Services.Managers
{
    public class General<T, TI> where T : class
    {
        private CRMContext context;
        public General(CRMContext context)
        {
            this.context = context;
        }
        internal async Task<T> GetById(TI id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public static async Task<T> GetObject(CRMContext context, TI id)
        {
            var general = new General<T, TI>(context);
            return await general.GetById(id);
        }
    }
}
