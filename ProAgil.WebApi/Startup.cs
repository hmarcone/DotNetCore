using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using ProAgil.Domain.Entities;
using ProAgil.Infrastructure.DbModels;
using ProAgil.Repository;

namespace ProAgil.WebApi
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
            //services.AddControllers(); usa o System.Text.Json 
            services.AddControllers().AddNewtonsoftJson(); //usa o NewtonsoftJson 
            services.AddDbContext<ProAgilContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProAgilRepository, ProAgilRepository>();

            //Vers�o 4.01 do AutoMapper.Extensions.Microsoft.DependencyInjection
            services.AddAutoMapper();  //services.AddAutoMapper(typeof(Startup)); vers�o 8.0 do AutoMapper.Extensions.Microsoft.DependencyInjection

            //AutoMapper.Mapper.Initialize(cfg => {
            //    cfg.AllowNullDestinationValues = true;
            //    cfg.CreateMap<EventoModel, Evento>(MemberList.None);
            //    cfg.CreateMap<Evento, EventoModel>(MemberList.None);
            //});
            //ToDo: retirar depois
            //services.AddSingleton(Mapper.Configuration);
            //services.AddSingleton<IConfigurationProvider>(AutoMapperConfig.RegisterMappings());
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions(){
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
