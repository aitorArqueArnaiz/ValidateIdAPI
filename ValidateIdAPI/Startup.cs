using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ValidateId.Bussines.Interfaces.Basket;
using ValidateId.Bussines.Services.Basket;
using ValidateId.Infrastructure.Data.Repositories;

namespace ValidateIdAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InMemmoryRepository>(opt => opt.UseInMemoryDatabase(databaseName:"ShoppingBaskets"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ValidateIdAPI", Version = "v1" });
            });

            // Add application services.
            var contextOptions = new DbContextOptionsBuilder<InMemmoryRepository>();
            services.Add(new ServiceDescriptor(typeof(IBasketService), new BasketService(new InMemmoryRepository(contextOptions.Options))));

            // Add framework services.
            services.AddMvc(options =>
            {
                options.Filters.Add(new ErrorHandlingFilter());
            });

            // Add logging service
            services.AddLogging(configure => configure.AddConsole());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ValidateIdAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
