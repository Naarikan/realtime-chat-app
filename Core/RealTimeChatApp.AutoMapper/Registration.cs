﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using RealTimeChatApp.Application.Interfaces.AutoMapper;
using RealTimeChatApp.AutoMapper.AutoMapper;



namespace RealTimeChatApp.AutoMapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper,Mapper>();
        }
    }
}
