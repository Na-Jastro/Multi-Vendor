using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiVendor.Core.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateUpdated { get; set; }
        public string LastUsername { get; set; }
    }
}
