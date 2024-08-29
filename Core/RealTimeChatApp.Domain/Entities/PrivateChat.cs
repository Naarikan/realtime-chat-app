﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealTimeChatApp.Domain.Common;

namespace RealTimeChatApp.Domain.Entities
{
    public class PrivateChat : EntityBase
    {
        public Guid User1Id { get; set; } 
        public User User1 { get; set; } 

        public Guid User2Id { get; set; } 
        public User User2 { get; set; } 

        public ICollection<Message> Messages { get; set; }
    }
}
