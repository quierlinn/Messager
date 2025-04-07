using Messager.Data;
using Messager.Messager.Repositories;
using Messager.Messager.Services;
using Messager.Messager.Services.Abstractions;
using Messager.Messager.UnitOfWork;
using Messager.Messager.UnitOfWork.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var services = builder.Services;
services.AddDbContext<ChatContext>(options => 
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IMessageRepository, MessageRepository>();

services.AddScoped<IUnitOfWork, UnitOfWork>();

services.AddScoped<IUserService, UserService>();
services.AddScoped<IMessageService, MessageService>();

services.AddProblemDetails();

services.AddControllers();

var app = builder.Build();
app.UseMiddleware<MessengerExceptionHandlerMiddleware>();
app.UseExceptionHandler();
app.UseAuthorization();
app.MapControllers();

app.Run();