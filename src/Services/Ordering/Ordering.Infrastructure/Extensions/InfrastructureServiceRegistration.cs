using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Ordering.Application.Contracts.Persistance;
using Ordering.Infrastructure.Repositories;
using Ordering.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Models;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Infrastructure.Mail;

namespace Ordering.Infrastructure.Extensions
{
	public static class InfrastructureServiceRegistration
	{
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddDbContext<OrderContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("OrderingConnectionString"),
                b => b.MigrationsAssembly("Ordering.Infrastructure")));
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            service.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            service.AddTransient<IEmailService, EmailService>();
            return service;
        }
    }
}

