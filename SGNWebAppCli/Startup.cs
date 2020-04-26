using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SGNWebAppCli.Data;
using SGNWebAppCli.Services;

namespace SGNWebAppCli
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSection);

            services.AddBlazoredLocalStorage();

            services.AddHttpClient<IReportSerivce<Currency>, ReportService<Currency>>();
            services.AddHttpClient<IReportSerivce<Mode>, ReportService<Mode>>();
            services.AddHttpClient<IReportSerivce<Quality>, ReportService<Quality>>();
            services.AddHttpClient<IReportSerivce<QualityDetail>, ReportService<QualityDetail>>();
            services.AddHttpClient<IReportSerivce<Machine>, ReportService<Machine>>();
            services.AddHttpClient<IReportSerivce<QualityDetailAndMachine>, ReportService<QualityDetailAndMachine>>();
            services.AddHttpClient<IReportSerivce<FileHistory>, ReportService<FileHistory>>();
            services.AddHttpClient<IReportSerivce<SerialNumbersDuplicates>, ReportService<SerialNumbersDuplicates>>();
            services.AddHttpClient<IReportSerivce<User>, ReportService<User>>();

            services.AddBlazoredSessionStorage();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


            services.AddHttpClient<IUserService, UserService>(config =>
              {
                  config.BaseAddress = new Uri("https://localhost:44398/api/Users/");
                  config.DefaultRequestHeaders.Add("User-Agent", "BlazorServer");
              });
            services.AddSingleton<HttpClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
