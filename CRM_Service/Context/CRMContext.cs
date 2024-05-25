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
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DetailsQuote> DetailsQuotes { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentGrouper> DocumentGroupers { get; set; }
        public DbSet<Incoterm> Incoterms { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RolUser> RolUsers { get; set; }
        public DbSet<LogsCustomer> LogsCustomers { get; set; }
        public DbSet<logsDocument> logsDocuments { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<RelUserPage> RelUserPages { get; set; }
    }
}
