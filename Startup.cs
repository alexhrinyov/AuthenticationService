using AuthenticationService.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region �������� ��� ������������
        public static Guid LogDirectoryId { get; set; }
        public static string LogDirectoryName { get; set; }
        public static string LogDirPath { get; set; }
        public static string txtEventsPath { get; set; }
        public static string txtErrorsPath { get; set; }
        #endregion
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILogger, Logger>();
            services.AddSingleton<IUserRepository, UserRepository>();
            var mapperConfig = new MapperConfiguration((v) =>
            {
                v.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthenticationService", Version = "v1" });
            });

            services.AddAuthentication(options => options.DefaultScheme = "Cookies").AddCookie("Cookies", options =>
            {
                options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
                {
                    OnRedirectToLogin = redirectContext =>
                    {
                        redirectContext.HttpContext.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    }
                };
            });

            LogDirectoryId = Guid.NewGuid();
            LogDirectoryName = LogDirectoryId.ToString();
            
            //�������� ������ � ����� ��� ������� ����������
            if (!Directory.Exists(LogDirectoryName))
            {
                string workingDirectory = Directory.GetCurrentDirectory();
                LogDirPath = Path.Combine(workingDirectory, "Logs", LogDirectoryName);
                Directory.CreateDirectory(LogDirPath);
                txtEventsPath = Path.Combine(LogDirPath, "events.txt");
                txtErrorsPath = Path.Combine(LogDirPath, "errors.txt");
                File.Create(txtEventsPath);
                File.Create(txtErrorsPath);
            }
                

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthenticationService v1"));
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
