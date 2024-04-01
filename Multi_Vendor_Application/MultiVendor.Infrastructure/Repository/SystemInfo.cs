using Microsoft.EntityFrameworkCore;
using MultiVendor.Core.Repositories;
using MultiVendor.Infrastructure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiVendor.Infrastructure.Repository
{
    public class SystemInfo : ISystemInfo
    {
        private readonly MultiVendorDbContext _context;

        public SystemInfo(MultiVendorDbContext context)
        {
            _context = context;
        }
        public Task CreateSystemInfoAsync(Core.Models.SystemInfo systemInfo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSystemInfoAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Core.Models.SystemInfo>> GetAllSystemInfoAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Core.Models.SystemInfo> GetSystemInfoByIdAysnc(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSystemInfoAsync(Core.Models.SystemInfo systemInfo)
        {
            throw new NotImplementedException();
        }
    }
}
