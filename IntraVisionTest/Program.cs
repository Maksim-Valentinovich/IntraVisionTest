using IntraVisionTest.Application;
using IntraVisionTest.Domain;
using IntraVisionTest.Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();


        string? connectionString = builder.Configuration.GetConnectionString("Default");

        builder.Services.AddDbContext<IntraVisionContext>(x => x.UseNpgsql(connectionString));
        
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);//??

        // предварительно
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => options.LoginPath = "/account");
        builder.Services.AddAuthorization();
        builder.Services.AddAutoMapper(typeof(Program), typeof(IntraVisionAppService));
        builder.Services.AddSession();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped(sp => ShopCard.GetCard(sp));// добавил
        
        var services = builder.Services;
        var types = Assembly.GetAssembly(typeof(IntraVisionAppService))!.GetTypes()
            .Where(x => !x.IsAbstract && x.IsClass && typeof(IApplicationService).IsAssignableFrom(x));
        foreach (var type in types)
        {
            builder.Services.AddTransient(type.GetInterface($"I{type.Name}")!, type);
        }
        // предварительно

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSession();

        app.UseRouting();


        app.UseAuthorization();
        app.UseAuthentication();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}