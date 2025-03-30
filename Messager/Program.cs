using Messager.Data;
using Messager.Messager.Repositories;
using Messager.Messager.Services;
using Messager.Messager.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var services = builder.Services;
builder.Services.AddDbContext<ChatContext>(options => 
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IMessageRepository, MessageRepository>();
services.AddScoped<IMessageService, MessageService>();
services.AddControllers();

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();

app.Run();