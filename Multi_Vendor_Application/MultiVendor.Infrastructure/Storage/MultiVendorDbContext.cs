﻿using Ardalis.EFCore.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiVendor.Infrastructure.Storage
{
    public class MultiVendorDbContext : DbContext
    {
        public MultiVendorDbContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Library Ardalis.EFCore.Extensions
            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly(typeof(MultiVendorDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
