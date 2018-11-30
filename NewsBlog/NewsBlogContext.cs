using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBlog
{
    public class NewsBlogContext : DbContext
    {
        public NewsBlogContext() : base("DefaultConnection") { }

        public DbSet<CollectionItem> MyCollection { get; set; }
    }
}
