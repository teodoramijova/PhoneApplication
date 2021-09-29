using BusinessLayer;
using BusinessLayerContract;
using DataAccess;
using DataAccessContract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PhonesApp
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
            services.AddControllersWithViews(options => options.EnableEndpointRouting = false);
            services.AddDbContext<DataBaseContext>(cfg =>
            {
                var connString = Configuration.GetConnectionString("connStr");
                cfg.UseSqlServer(connString);
            });

            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITypeRepository, TypeRepository>();

            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITypeService, TypeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default",
                     "{controller}/{action}/{id?}",
                     new
                     {
                         controller = "Phone",
                         Action = "Phones"
                     });
            });
        }
    }
}
