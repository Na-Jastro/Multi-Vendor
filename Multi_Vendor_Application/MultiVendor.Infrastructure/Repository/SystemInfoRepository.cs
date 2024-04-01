using Microsoft.EntityFrameworkCore;
using MultiVendor.Core.Models;
using MultiVendor.Core.Repositories;
using MultiVendor.Infrastructure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiVendor.Infrastructure.Repository
{
    public class SystemInfoRepository : ISystemInfoRepositories
    {
        private readonly MultiVendorDbContext _context;
        public SystemInfoRepository(MultiVendorDbContext context)
        {
            _context = context;
        }
        public async Task CreateSystemInfoAsync(SystemInfo systemInfo)
        {
            await _context.Set<SystemInfo>().AddAsync(systemInfo);  
        }
        public async Task DeleteSystemInfoAsync(Guid id)
        {
            var systemInfo = await _context.Set<SystemInfo>().FirstOrDefaultAsync(x => x.Id == id);
            if (systemInfo != null)
            {
                _context.Set<SystemInfo>().Remove(systemInfo);
                _context.SaveChanges();
            }
        }
        public async Task<IEnumerable<SystemInfo>> GetAllSystemInfoAsync()
        {
            return await _context.Set<SystemInfo>().Where(p => p.IsActive).ToListAsync();
        }
        public async Task<SystemInfo> GetSystemInfoByIdAysnc(Guid id)
        {
            return await _context.Set<SystemInfo>().FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task UpdateSystemInfoAsync(SystemInfo systemInfo)
        {
            var systemI = await _context.Set<SystemInfo>().FirstOrDefaultAsync(p => p.Id == systemInfo.Id);
            if(systemI != null)
            {
                _context.Update(systemI);
                _context.SaveChanges(true);
            }
        }
    }
}
