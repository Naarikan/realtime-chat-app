using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealTimeChatApp.Domain.Common;

namespace RealTimeChatApp.Domain.Entities
{
    public class GroupChat :EntityBase
    {
        public GroupChat()
        {
            
        }
        public GroupChat(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
       
        public ICollection<Message>? Messages { get; set; }
        public ICollection<UserGroupRole> UsersGroupRoles { get; set; }
       
    }
}
