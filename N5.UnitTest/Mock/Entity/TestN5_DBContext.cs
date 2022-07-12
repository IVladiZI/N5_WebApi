using Microsoft.EntityFrameworkCore;
using N5.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.UnitTest.Mock.Entity
{
    public class TestN5_DBContext : N5_DBContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }
        }
    }
}
