using CryptoMApi.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMApi.Contexto
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Coin> Coin { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
       : base(options)
        {
        }
    }
}
