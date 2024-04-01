using MultiVendor.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiVendor.Core.Repositories
{
    public interface ISystemInfoRepositories
    {
        Task<IEnumerable<SystemInfo>> GetAllSystemInfoAsync();
        Task<SystemInfo> GetSystemInfoByIdAysnc(Guid id);
        Task CreateSystemInfoAsync(SystemInfo systemInfo);
        Task DeleteSystemInfoAsync(Guid id);
        Task UpdateSystemInfoAsync(SystemInfo systemInfo);
    }
}
