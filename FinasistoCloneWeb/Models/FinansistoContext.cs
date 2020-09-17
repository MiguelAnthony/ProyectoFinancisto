using FinasistoCloneWeb.Models.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinasistoCloneWeb.Models
{
    public class FinansistoContext: DbContext
    {
    //esto se repite por cada tabla de base de datos
    public DbSet<Account> Accounts { get; set; }


    public FinansistoContext(DbContextOptions<FinansistoContext> options)
            :base(options)
    {
    }
          
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //esto se repite por cada tabla de base de datos
            modelBuilder.ApplyConfiguration(new AccountMap());
        }
    }
}
