using Azure;
using CRM_Service.Entitys;
using CRM_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Services.IManagers
{
    public interface IGeneralManager<T, TI> 
    {
        Task<CRM_Service.Entitys.Response> Create(TI poco);
        Task<CRM_Service.Entitys.Response> Delete(Int64 Id);
    }
}
  