using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.EntityFrameworkCore;
using MotorAsinBasketRobot.Business.DependecyResolvers.Autofac;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context;
using Quartz.Impl;
using Quartz;
using MotorAsinBasketRobot.WebAPI.Tasks.Jobs;
using MotorAsinBasketRobot.WebAPI.Tasks.Triggers;

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
    // Just use the name of your job that you created in the Jobs folder.
    var jobKey = new JobKey("DocumentsJob");
    q.AddJob<DocumentsJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("DocumenTriggers")
       //This Cron interval can be described as "run every minute" (when second is zero)
       .WithCronSchedule("0/50 * * ? * * *")
    );
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
