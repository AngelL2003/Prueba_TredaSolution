using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Prueba_TredaSolution.Data
{
    public class PTSContext : DbContext
    {
        public PTSContext (DbContextOptions<PTSContext> options)
            : base(options)
        {
        }

        public DbSet<Tienda> Tienda { get; set; } = default!;
    }
}
