using CRM_Service.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Service.Context
{
    public class CRMContext : DbContext
    {
        public CRMContext(DbContextOptions<CRMContext> options): base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<RolUser> RolUsers { get; set; }
    }
}
