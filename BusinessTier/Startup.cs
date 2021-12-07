using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.BankData;
using BusinessLayer.Data;
using BusinessLayer.Middlepoint;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace REST
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "REST", Version = "v1"});
            });
            //web services
            services.AddSingleton<IUserWebService, UserWebService>();
            services.AddSingleton<IGameWebService, GameWebService>();
            services.AddSingleton<IGameListWebService, GameListWebService>();
            services.AddSingleton<IEventWebService, EventWebService>();
            services.AddSingleton<ICategoryWebService, CategoryWebService>();
            services.AddSingleton<IParticipantWebService, ParticipantWebService>();
            services.AddSingleton<IOrganizerWebService, OrganizerWebService>();
            services.AddSingleton<IEventGameListWebService, EventGameListWebService>();
            services.AddSingleton<IPaymentWebService, PaymentWebService>();
            services.AddSingleton<IOneTimeFeeWebService, OneTimeFeeWebService>();
            services.AddSingleton<IMonthlyFeeWebService, MonthlyFeeWebService>();
            services.AddSingleton<IEventOrganizerWebService, EventOrganizerWebService>();
            
            //middlepoints
            services.AddSingleton<IUserMiddlePoint, UserMiddlePoint>();
            services.AddSingleton<IEventMiddlePoint, EventMiddlePoint>();
            services.AddSingleton<IGameMiddlePoint, GameMiddlePoint>();
            services.AddSingleton<IGameListMiddlePoint, GameListMiddlePoint>();
            services.AddSingleton<IFeeMiddlePoint, FeeMiddlePoint>();
            services.AddSingleton<IEventGameListMiddlePoint, EventGameListMiddlePoint>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "REST v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}