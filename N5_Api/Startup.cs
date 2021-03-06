using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using N5.Core.Exceptions;
using N5.Core.Interfaces;
using N5.Core.Services;
using N5.Infrastructure.Data;
using N5.Infrastructure.Filters;
using N5.Infrastructure.Repositories;
using System;

namespace N5_Api
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
            services.AddCors();
            //Mapping Profile
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //Ignore LoopHandling, Disable ValidationFilter ApiController
            services.AddControllers(options => {
                options.Filters.Add<GlobalExceptionFilter>();
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            //Dependency Injection
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            //Connection DB
            services.AddDbContext<N5_DBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("N5Connection"))
            );
            //Configure Validation MVC Model
            services.AddMvc(options=> {
                options.Filters.Add <ValidationFilter>();
            }).AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "N5_Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => {
                options.WithOrigins("http://127.0.0.1:5173");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "N5_Api v1"));
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
