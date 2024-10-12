using Microsoft.EntityFrameworkCore;
using InventoryHub.Data;
using InventoryHub;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InventoryHubContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryHubContext") ?? throw new InvalidOperationException("Connection string 'InventoryHubContext' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapProductItemEndpoints();

app.Run();
