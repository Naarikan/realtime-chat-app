using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealTimeChatApp.Domain.Common;

namespace RealTimeChatApp.Domain.Entities
{
    public class PrivateChat : EntityBase
    {
        public PrivateChat()
        {
            
        }

        public PrivateChat(Guid user1Id,Guid user2Id)
        {
            User1Id = user1Id;
            User2Id = user2Id;
        }

        public Guid User1Id { get; set; } 
        public User User1 { get; set; } 

        public Guid User2Id { get; set; } 
        public User User2 { get; set; } 

        public ICollection<Message> Messages { get; set; }
    }
}
