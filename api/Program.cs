
using System.Text.Json;
using FluentValidation;
using service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssembly(typeof(UserService).Assembly);

builder.Services.AddScoped<IUserService, UserService>();



builder.Services.AddControllers();

builder.Services.AddProblemDetails();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
 var result =   scope.ServiceProvider.GetService<IUserService>().GetUsers();
 Console.WriteLine(JsonSerializer.Serialize(result));
}

app.MapControllers();
app.UseCors( opts => {
    opts.AllowAnyOrigin();
    opts.AllowAnyMethod();
    opts.AllowAnyHeader();
});



app.Run();
