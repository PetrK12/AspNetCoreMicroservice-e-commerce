using Basket.API.Data;
using Basket.API.GrpcServices;
using Discount.Grpc.Protos;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using MassTransit;
using Basket.API.Profiles;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Basket.API", Version = "v1" });
});
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<MappingProfiles>();
});

//Redis config
builder.Services.AddStackExchangeRedisCache(options => options.Configuration =
    builder.Configuration.GetValue<string>("CacheSettings:ConnectionString"));
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

//Grpc
builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(options =>
    options.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]));
builder.Services.AddScoped<DiscountGrpcService>();

//MassTransit-RabbitMQ
builder.Services.AddMassTransit(configure =>
{
    configure.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMqHost"]);
    });
});

builder.Services.Configure<MassTransitHostOptions>(options =>
{
    options.WaitUntilStarted = true;
    options.StartTimeout = TimeSpan.FromSeconds(30);
    options.StopTimeout = TimeSpan.FromMinutes(1);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bakset.API v1"));
}

app.UseAuthorization();

app.MapControllers();

app.Run();

