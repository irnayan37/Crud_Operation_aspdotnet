using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Serilog;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Demo.Web;
using Microsoft.AspNetCore.Identity;
using Demo.Infrastructure.Data;


Log.Logger = new LoggerConfiguration()
               .WriteTo.File("Logs/web-log-.log",
                   rollingInterval: RollingInterval.Day)
                .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
        throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    var migrationAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext));


    #region Autofac Configuration
    //builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    //builder.Host.ConfigureContainer<ContainerBuilder>(ContainerBuilder =>
    //{
    //    ContainerBuilder.RegisterModule(new WebModule(connectionString, migrationAssembly?.FullName));
    //});
    #endregion

    #region Serilog Configuration// Step 2: Replace bootstrap logger with full logger
    builder.Host.UseSerilog((context, lc) => lc
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(context.Configuration)
    );

    #endregion

    // Add services to the container.

    builder.Services.AddScoped(s =>
      new ApplicationDbContext(connectionString, migrationAssembly?.FullName));

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString,
    (x) => x.MigrationsAssembly(migrationAssembly)));

    //IServiceCollection serviceCollection = builder.Services.AddDbContext<ApplicationDbContext>(options =>
    //    options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
    

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();
    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();

    // throw new Exception("Test Error");
    //builder.Services.AddSingleton<IEmailUtililty, HtmlEmailUtility>();
    //builder.Services.AddTransient<IEmailUtililty,HtmlEmailUtility>();
    //builder.Services.AddScoped<IEmailUtililty, HtmlEmailUtility>();
    //builder.Services.AddKeyedScoped<IEmailUtililty, HtmlEmailUtility>("Setup1");//2 ta controller er alada alada setup constructor a dite hbe
    //builder.Services.AddKeyedScoped<IEmailUtililty, EmailUtility>("Setup2");



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
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();
    Log.Information("Starting Application");

    app.Run();
}
catch(Exception ex)
{
    Log.Fatal(ex, "Application Crashed");

}
finally
{
    Log.CloseAndFlush();
}
