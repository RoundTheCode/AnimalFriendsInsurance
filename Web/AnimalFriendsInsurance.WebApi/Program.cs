using AnimalFriendsInsurance.Business.Customers.Mapping;
using AnimalFriendsInsurance.Business.Customers.Services;
using AnimalFriendsInsurance.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(CustomerMappingProfile));
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddDbContext<AnimalFriendsInsuranceDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AnimalFriendsInsuranceDataContext"));
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
