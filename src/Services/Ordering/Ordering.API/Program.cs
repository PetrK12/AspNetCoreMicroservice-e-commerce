using Ordering.API.Extensions;
using Ordering.Application.Exceptions;
using Ordering.Infrastructure.Extensions;
using Ordering.Infrastructure.Persistance;
using MassTransit;
using EventBus.Messages.Common;
using Ordering.API.EventBusConsumer;
using Ordering.API.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddAutoMapper(c => c.AddProfile<MappingProfiles>());
builder.Services.AddScoped<BasketCheckoutConsumer>();
//MassTransit-RabbitMQ
builder.Services.AddMassTransit(configure =>
{
    configure.AddConsumer<BasketCheckoutConsumer>();
    configure.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMqHost"]);
        cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, cfg =>
        {
            cfg.ConfigureConsumer<BasketCheckoutConsumer>(ctx);
        });
    });
});

builder.Services.Configure<MassTransitHostOptions>(options =>
{
    options.WaitUntilStarted = true;
    options.StartTimeout = TimeSpan.FromSeconds(30);
    options.StopTimeout = TimeSpan.FromMinutes(1);
});

var app = builder.Build();
app.MigrateDatabase<OrderContext>((context, service) =>
{
    var logger = service.GetService<ILogger<OrderContextSeed>>();
    OrderContextSeed.SeedAsync(context, logger).Wait();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

