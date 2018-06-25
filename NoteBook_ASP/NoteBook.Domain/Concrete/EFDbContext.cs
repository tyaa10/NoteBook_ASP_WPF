using NoteBook.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<AnOrder> AnOrders { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }

        public EFDbContext()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
