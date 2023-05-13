using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using MotorAsinBasketRobot.Business.DependecyResolvers.Autofac;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context;
using Quartz.Impl;
using Quartz;
using MotorAsinBasketRobot.WebAPI.Tasks.Jobs;
using MotorAsinBasketRobot.WebAPI.Tasks.Triggers;
using MotorAsinBasketRobot.Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionScopedJobFactory();
    var jobKey = new JobKey("DocumentsJob");
    q.AddJob<DocumentsJob>(opts => opts.WithIdentity(jobKey));
    q.AddTrigger(opts => opts
        .ForJob(jobKey)
         .WithIdentity("DocumentsJob", "null")
      .WithIdentity("DocumenTriggers")
   .WithCronSchedule("0/5 * * ? * * *"));


    var basketStatusKey = new JobKey("BasketStatusJob");
    q.AddJob<BasketStatusJob>(opts => opts.WithIdentity(basketStatusKey));
    q.AddTrigger(opts => opts
        .ForJob(basketStatusKey)
         .WithIdentity("BasketStatusJob", "null")
    .WithCronSchedule("0/5 * * ? * * *"));


    var customerKey = new JobKey("CustomersJob");
    q.AddJob<CustomersJob>(opts => opts.WithIdentity(customerKey));
    q.AddTrigger(opts => opts
        .ForJob(customerKey)
         .WithIdentity("CustomersJob", "null")
             .WithCronSchedule("0/5 * * ? * * *"));// 1 saniye


    //var ProductCampaignKey = new JobKey("ProductCampaignJob");
    //q.AddJob<ProductCampaignsJob>(opts => opts.WithIdentity(ProductCampaignKey));
    //q.AddTrigger(opts => opts
    //    .ForJob(ProductCampaignKey)
    //     .WithIdentity("DocumenTriggers", "null")
    //.WithCronSchedule("0/5 * * ? * * *"));// 1 saniye
    ////.WithCronSchedule("0 */5 * ? * * *"));






});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
