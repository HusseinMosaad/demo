using OnlineStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entity
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext() : base("StoreConnection")
        {
            
        }

        public IDbSet<Product> Products { get; set; }
    }
}
