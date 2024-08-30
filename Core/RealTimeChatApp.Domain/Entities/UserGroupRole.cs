using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealTimeChatApp.Domain.Common;

namespace RealTimeChatApp.Domain.Entities
{
    public class UserGroupRole:EntityBase
    {
        public UserGroupRole()
        {
            
        }

        public UserGroupRole(Guid userId,Guid roleId,Guid groupChatId)
        {
            UserId = userId;
            RoleId = roleId;
            GroupChatId = groupChatId;
        }


        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public Guid GroupChatId { get; set; }


        public User User { get; set; }
        public Role Role { get; set; }
        public GroupChat GroupChat { get; set; }


        
        

    }
}
