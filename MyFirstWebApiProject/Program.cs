using Microsoft.EntityFrameworkCore;
using entities.Models;
using Repository;
using Services;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using NLog.Web;
using MyFirstWebApiProject;
using MyFirstWebApiProject.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderItemRepoditory, OrderItemRepoditory>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductsServices, ProductsServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IOrderItemServices, OrderItemServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IRatingServices, RatingServices>();

builder.Host.UseNLog();

//builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<CookwareShopContext>(option => option.UseSqlServer(builder.Configuration["CookWareShop"]));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseErrorHandlingMiddleware();

app.UseRatingMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
