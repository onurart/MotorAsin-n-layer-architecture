using Microsoft.EntityFrameworkCore;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionScopedJobFactory();

   // var pproductKey = new JobKey("ProductsCampaignsJobs");
   // q.AddJob<ProductsCampaignsJobs>(opts => opts.WithIdentity(pproductKey));
   // q.AddTrigger(opts => opts
   // .ForJob(pproductKey)
   // .WithIdentity("ProductsCampaignsJobsTriggers", "null")
   // //.WithCronSchedule("0/20 * * ? * * *"));
   // .WithCronSchedule("0 23 10 1/1 * ? *"));


   // var jobKey = new JobKey("DocumentsJob");
   // q.AddJob<DocumentsJob>(opts => opts.WithIdentity(jobKey));
   // q.AddTrigger(opts => opts
   //     .ForJob(jobKey)
   //     .WithIdentity("DocumenTriggers", "null")
   //.WithCronSchedule("0 35 14 1/1 * ? *"));

   // var basketStatusKey = new JobKey("BasketStatusJob");
   // q.AddJob<BasketStatusJob>(opts => opts.WithIdentity(basketStatusKey));
   // q.AddTrigger(opts => opts
   //     .ForJob(basketStatusKey)
   //     .WithIdentity("BasketStatusTriggers", "null")
   //  .WithCronSchedule("0 57 14 1/1 * ? *"));


   // var customerKey = new JobKey("CustomersJob");
   // q.AddJob<CustomersJob>(opts => opts.WithIdentity(customerKey));
   // q.AddTrigger(opts => opts
   //     .ForJob(customerKey)
   //      .WithIdentity("CustomerTriggers", "null")
   //   .WithCronSchedule("0 15 16 1/1 * ? *"));

   // var productKey = new JobKey("ProductJob");
   // q.AddJob<ProductJob>(opts => opts.WithIdentity(productKey));
   // q.AddTrigger(opts => opts
   // .ForJob(productKey)
   // .WithIdentity("ProductTriggers", "null")
   // .WithCronSchedule("0 50 16 1/1 * ? *"));


});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);


builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
