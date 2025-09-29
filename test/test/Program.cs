using RestEase;
using test.Repositories;
using test.Repositories.Interfaces;
using test.Services;
using test.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDbApi>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    var baseUrl = config["DbApi:BaseUrl"];
    return RestClient.For<IDbApi>(baseUrl);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
