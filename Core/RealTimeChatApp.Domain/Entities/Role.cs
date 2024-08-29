using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RealTimeChatApp.Domain.Common;

namespace RealTimeChatApp.Domain.Entities
{
    public class Role : IdentityRole<Guid>, IEntityBase
    {
        public Role()
        {
            CreatedDate = DateTime.Now;
            IsDeleted = false;
        }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
