using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RealTimeChatApp.Domain.Common;

namespace RealTimeChatApp.Domain.Entities
{
    public class User : IdentityUser<Guid> ,IEntityBase
    {
        public User()
        {
            CreatedDate = DateTime.Now;
            IsDeleted = false;
        }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public DateTime CreatedDate { get ; set ; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<UserGroupRole> UsersGroupRoles { get; set; }
    }
}
