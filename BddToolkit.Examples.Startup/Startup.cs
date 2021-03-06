using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ITLIBRIUM.BddToolkit.Examples
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<PrePaidAccountRepository, SqlPrePaidAccountRepository>();
            // For us everyone is VIP ;)
            services.AddScoped<RechargePolicy, VipRechargePolicy>();
            services.AddScoped<CommandHandler<Recharge, Recharged>, RechargeHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints
                .MapGet("/", async context => { await context.Response.WriteAsync("BDD toolkit examples"); }));
        }
    }
}