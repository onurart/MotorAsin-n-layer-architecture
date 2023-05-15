using Quartz.Impl;

namespace MotorAsinBasketRobot.WebAPI.Tasks.Triggers
{
    public class ProductTriggers
    {
        public static void ProductStarts()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();
            if (!scheduler.IsStarted)
                scheduler.Start().GetAwaiter().GetResult();
            IJobDetail job = JobBuilder.Create<DocumentsJob>()
                                      .WithIdentity("ProductJob", null)
                                      .Build();
            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity("ProductTriggers", null)
                                             .Build();
            scheduler.ScheduleJob(job, trigger).GetAwaiter().GetResult();
        }
    }
}
