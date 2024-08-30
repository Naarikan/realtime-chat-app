﻿using System;
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
            
        }

        public string Name { get; set; }
       
        public ICollection<Message>? Messages { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
        public ICollection<UserGroupRole> UsersRoles { get; set; }
       
    }
}