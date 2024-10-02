using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using RealTimeChatApp.Application.Bases;
using RealTimeChatApp.Application.Interfaces.AutoMapper;
using RealTimeChatApp.Application.Interfaces.UnitOfWorks;
using RealTimeChatApp.Application.Model;
using RealTimeChatApp.Domain.Entities;
using RealTimeChatApp.Infrastructure.SignalR;

namespace RealTimeChatApp.Application.Features.Messages.Command.CreateMessage
{
    public class CreateMessageCommandHandler : BaseHandler, IRequestHandler<CreateMessageCommandRequest, Unit>
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly UserManager<User> _userManager;

        public CreateMessageCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IHubContext<ChatHub> hubContext, UserManager<User> userManager) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _hubContext = hubContext;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(CreateMessageCommandRequest request, CancellationToken cancellationToken)
        {
            
            Message msg = new(request.Content, request.UserId, request.GroupChatId);

            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            
            await unitOfWork.GetWriteRepository<Message>().AddAsync(msg);
            await unitOfWork.SaveAsync();

            
            var message = new SendMessageModel
            {
                UserName = user.UserName,
                Content = request.Content,
                Date = DateTime.Now,
                GroupChatId=request.GroupChatId.ToString(),
            };

           
            await _hubContext.Clients.Group(request.GroupChatId.ToString()).SendAsync("ReceiveMessage", message);

            return Unit.Value;
        }
    }
}
