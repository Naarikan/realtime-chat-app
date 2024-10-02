using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using RealTimeChatApp.Application.Model;
using RealTimeChatApp.Domain.Entities;


namespace RealTimeChatApp.Infrastructure.SignalR
{
    public class ChatHub : Hub
    {
        //public async Task SendMessageToGroup(string groupName, SendMessageModel message)
        //{
        //    await Clients.Group(groupName).SendAsync("ReceiveMessage", message);
        //}

       
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        
        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
