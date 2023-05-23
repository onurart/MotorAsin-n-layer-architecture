var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
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

    var pproductKey = new JobKey("ProductsCampaignsJobs");
    q.AddJob<ProductsCampaignsJobs>(opts => opts.WithIdentity(pproductKey));
    q.AddTrigger(opts => opts
    .ForJob(pproductKey)
    .WithIdentity("ProductsCampaignsJobsTriggers", "null")
    .WithCronSchedule("0 0 23 1/1 * ? *"));

    var jobKey = new JobKey("DocumentsJob");
    q.AddJob<DocumentsJob>(opts => opts.WithIdentity(jobKey));
    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("DocumenTriggers", "null")
 .WithCronSchedule("0 15 23 1/1 * ? *"));

    var basketStatusKey = new JobKey("BasketStatusJob");
    q.AddJob<BasketStatusJob>(opts => opts.WithIdentity(basketStatusKey));
    q.AddTrigger(opts => opts
        .ForJob(basketStatusKey)
        .WithIdentity("BasketStatusTriggers", "null")
     .WithCronSchedule("0 30 23 1/1 * ? *"));


    var customerKey = new JobKey("CustomersJob");
    q.AddJob<CustomersJob>(opts => opts.WithIdentity(customerKey));
    q.AddTrigger(opts => opts
        .ForJob(customerKey)
         .WithIdentity("CustomerTriggers", "null")
      .WithCronSchedule("0 45 23 1/1 * ? *"));

    var productKey = new JobKey("ProductJob");
    q.AddJob<ProductJob>(opts => opts.WithIdentity(productKey));
    q.AddTrigger(opts => opts
    .ForJob(productKey)
    .WithIdentity("ProductTriggers", "null")
    .WithCronSchedule("0 59 23 1/1 * ? *"));


});
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
              .AllowAnyMethod()
              .AllowAnyHeader()
              .SetIsOriginAllowed(origin => true)
              .AllowCredentials());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
