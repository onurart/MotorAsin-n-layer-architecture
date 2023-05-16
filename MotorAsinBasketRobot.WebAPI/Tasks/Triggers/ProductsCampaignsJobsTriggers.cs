using Quartz.Impl;

namespace MotorAsinBasketRobot.WebAPI.Tasks.Triggers
{
    public class ProductsCampaignsJobsTriggers
    {
        public static void ProductsCampaignsJobsStarts()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();
            if (!scheduler.IsStarted)
                scheduler.Start().GetAwaiter().GetResult();
            IJobDetail job = JobBuilder.Create<ProductsCampaignsJobs>()
                                      .WithIdentity("ProductsCampaignsJobs", null)
                                      .Build();
            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity("ProductsCampaignsJobsTriggers", null)
                                             .Build();
            scheduler.ScheduleJob(job, trigger).GetAwaiter().GetResult();
        }
    }
}
