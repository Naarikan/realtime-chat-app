using RealTimeChatApp.Persistence.Context;
using RealTimeChatApp.AutoMapper;
using RealTimeChatApp.Application;
using RealTimeChatApp.Infrastructure;
using RealTimeChatApp.Infrastructure.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInsfrastructure(builder.Configuration);
builder.Services.AddCustomMapper();
builder.Services.AddApplication();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.WithOrigins("https://localhost:7186")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});



builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");
app.UseAuthentication();

app.UseAuthorization();



app.MapControllers();



app.MapHub<ChatHub>("/chatHub");

app.Run();
