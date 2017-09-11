using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Beletskaya.Library.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext():base("Library")
        {
                
        }
        public DbSet<Book> Books { get; set; }
    }
}