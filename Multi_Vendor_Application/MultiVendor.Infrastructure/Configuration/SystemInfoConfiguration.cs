using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiVendor.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiVendor.Infrastructure.Configuration
{
    public class SystemInfoConfiguration : IEntityTypeConfiguration<SystemInfo>
    {
        public void Configure(EntityTypeBuilder<SystemInfo> builder)
        {
            builder.ToTable(nameof(SystemInfo));
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.LastUsername).IsRequired();
        }
    }
}
