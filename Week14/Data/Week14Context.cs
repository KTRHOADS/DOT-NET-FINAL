using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Week14.Models;

namespace Week14.Models
{
    public class Week14Context : DbContext
    {
        public Week14Context (DbContextOptions<Week14Context> options)
            : base(options)
        {
        }

        public DbSet<Week14.Models.Hymn> Hymn { get; set; }

        public DbSet<Week14.Models.Member> Member { get; set; }

        public DbSet<Week14.Models.Bishopric> Bishopric { get; set; }

        public DbSet<Week14.Models.Meeting> Meeting { get; set; }
    }
}
