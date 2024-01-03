using Autofac.Extensions.DependencyInjection;
using Autofac;
using DevSkill.Http.Emails;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Data;
using System.Reflection;
using Serilog.Events;
using Blogsite.Infrastructure;
using Blogsite.Membership;
using Blogsite.Infrastructure.DbContexts;

namespace BlogSite.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            var assemblyName = Assembly.GetExecutingAssembly().FullName!;
            var webHostEnvironment = builder.Environment.WebRootPath;

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterModule(new WebModule());
                containerBuilder.RegisterModule(new MembershipModule());
                containerBuilder.RegisterModule(new InfrastructureModule(connectionString, assemblyName, webHostEnvironment));
                //containerBuilder.RegisterModule(new EmailMessagingModule(connectionString, assemblyName));
            });

            //Serilog Configuration
            builder.Host.UseSerilog((ctx, lc) => lc
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(builder.Configuration));

            ////Localhost HTTPS port configuration
            //builder.WebHost
            //.ConfigureKestrel(options =>
            //{
            //    options.ListenLocalhost(49172, opts => opts.UseHttps());
            //    //get your localhost htttps port number from launch settings
            //});

            builder.WebHost.UseUrls("http://*:80");


            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, m => m.MigrationsAssembly(assemblyName)));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            //builder.Services
                //.AddIdentity<ApplicationUser, Role>()
                //.AddEntityFrameworkStores<ApplicationDbContext>()
                //.AddUserManager<UserManager>()
                //.AddRoleManager<RoleManager>()
                //.AddSignInManager<SignInManager>()
                //.AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/Login";
                options.SlidingExpiration = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}