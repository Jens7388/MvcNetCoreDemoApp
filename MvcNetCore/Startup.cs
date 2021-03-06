using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcNetCore.Models.Context;
using DataAccess;
using DataAccess.Base;
using MvcNetCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace MvcNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NorthwindContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                 .AddEntityFrameworkStores<NorthwindContext>();
            services.AddControllersWithViews();

            services.AddRazorPages();
            services.AddControllers();

            //Autofac stuff
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<ProductRepository>().As<IRepositoryBase<Product>>();
            builder.RegisterType<RepositoryBase<Category>>().As<IRepositoryBase<Category>>();
            builder.RegisterType<NorthwindContext>().As<DbContext>();
            builder.RegisterType<UserStore>();
            builder.RegisterType<SupplierRepository>().As<IRepositoryBase<Supplier>>();
            builder.Populate(services);

            IContainer container = builder.Build();
            using(ILifetimeScope scope = container.BeginLifetimeScope())
            {
                DbContext service = scope.Resolve<DbContext>();
            }
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.UseDeveloperExceptionPage();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseAuthentication();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}