using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealTimeChatApp.Application.DTOs;
using RealTimeChatApp.Domain.Entities;

namespace RealTimeChatApp.Application.Features.UserGroupRoles.Queries.GetAllGroupsWithLastMessage
{
    public class GetAllGroupsWithLastMessageQueryResponse
    {
       
       public GroupChatDto GroupChat{ get; set; }
       public RoleDto Role{ get; set; }
       
    }
}
