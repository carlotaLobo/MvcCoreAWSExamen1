using Microsoft.EntityFrameworkCore;
using MvcCoreAWSBlank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSBlank.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Coche> Coches { get; set; }
    }
}
