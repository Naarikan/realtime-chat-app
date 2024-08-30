﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealTimeChatApp.Domain.Entities;

namespace RealTimeChatApp.Persistence.Context
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration _configuration) {

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));









            services.AddIdentityCore<User>(opt => {

                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = false;

            })
               .AddRoles<Role>()
               .AddEntityFrameworkStores<AppDbContext>();
        }
    }
}