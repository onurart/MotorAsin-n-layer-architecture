using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using MotorAsinBasketProjectClient.UI.ApiServices;
using MotorAsinBasketProjectClient.UI.Extenisons;
using MotorAsinBasketRobot.Business.EmailService.EmailEntity;
using MotorAsinBasketRobot.Business.EmailService.EmailService;
using MotorAsinBasketRobot.Business.EmailService.IService;
using MotorAsinBasketRobot.Business.Requirements;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context;
using MotorAsinBasketRobotProject.Core.Permissions;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using MotorAsinBasketProjectClient.UI.MemberService;
using Autofac.Core;

var builder = WebApplication.CreateBuilder(args);
// CORS politikalarýný yapýlandýrma
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Kontrolör ve görünüm hizmetlerini ekleme
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt => opt.ResourcesPath = "Resources");
//builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null).AddRazorRuntimeCompilation();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
});
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
);
builder.Services.AddRazorPages().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddSession();
builder.Services.AddCors();
builder.Services.AddAuthorization();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.FromMinutes(30);
});
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddIdentityWithExt();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookieBuilder = new CookieBuilder();

    cookieBuilder.Name = "MotorAssinBasketRobotProjectAppCookie";
    opt.LoginPath = new PathString("/WebLogin/SignIn");
    opt.LogoutPath = new PathString("/Member/logout");
    opt.AccessDeniedPath = new PathString("/Member/AccessDenied");
    opt.Cookie = cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
    opt.SlidingExpiration = true;
});
builder.Services.AddScoped<IMemberService, MemberService>();

builder.Services.AddScoped<IAuthorizationHandler, ExchangeExpireRequirementHandler>();
builder.Services.AddScoped<IAuthorizationHandler, ViolenceRequirementHandler>();
builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("AnkaraPolicy", policy =>
    {
        policy.RequireClaim("city", "ankara");


    });

    options.AddPolicy("ExchangePolicy", policy =>
    {
        policy.AddRequirements(new ExchangeExpireRequirement());


    });

    options.AddPolicy("ViolencePolicy", policy =>
    {
        policy.AddRequirements(new ViolenceRequirement() { ThresholdAge = 18 });


    });

    options.AddPolicy("OrderPermissionReadAndDelete", policy =>
    {

        policy.RequireClaim("permission", Permissions.Order.Read);
        policy.RequireClaim("permission", Permissions.Order.Delete);
        policy.RequireClaim("permission", Permissions.Stock.Delete);

    });



    options.AddPolicy("Permissions.Order.Read", policy =>
    {

        policy.RequireClaim("permission", Permissions.Order.Read);


    });

    options.AddPolicy("Permissions.Order.Delete", policy =>
    {

        policy.RequireClaim("permission", Permissions.Order.Delete);


    });


    options.AddPolicy("Permissions.Stock.Delete", policy =>
    {

        policy.RequireClaim("permission", Permissions.Stock.Delete);


    });




});
builder.Services.AddHttpClient<OfferApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
});
builder.Services.AddHttpClient<ProductCampaingApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
});
builder.Services.AddHttpClient<ClientDocumentApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
});
builder.Services.AddHttpClient<ClientBasketStatusApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
});
builder.Services.AddHttpClient<ClientCustomersApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
});
builder.Services.AddHttpClient<ClientProductApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
});

builder.Services.AddHttpClient<IncomingOrderRequestsApiSevice>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
});



var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseCors("AllowAnyOrigin");

app.UseSession();
app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
