using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapeclasses
{
    public class BoardContext : DbContext
    {

        public DbSet<Card> Cards { get; set; }


        public BoardContext() : base("AnotherConnection")
        {

        }
    }
}
