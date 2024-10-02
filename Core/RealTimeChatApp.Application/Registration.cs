using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RealTimeChatApp.Application.Beheviors;
using RealTimeChatApp.Application.Encryption;

namespace RealTimeChatApp.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services) {

           

            var assembly = Assembly.GetExecutingAssembly();

            services.AddSignalR();

            services.AddSingleton<InviteCodeManager>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

            services.AddValidatorsFromAssembly(assembly);

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));

        }
    }
}
