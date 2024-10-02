using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealTimeChatApp.Application.DTOs;

namespace RealTimeChatApp.Application.Features.Messages.Queries.GetGroupMessages
{
    public class GetAllMessagesQueryResponse
    {
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public UserMessageDto User { get; set; }
    }
}
