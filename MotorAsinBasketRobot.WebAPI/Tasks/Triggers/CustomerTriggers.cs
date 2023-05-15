using Quartz.Impl;

namespace MotorAsinBasketRobot.WebAPI.Tasks.Triggers
{
    public class CustomerTriggers
    {
       public static void CustomerStarts()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();
            if (!scheduler.IsStarted)
                scheduler.Start().GetAwaiter().GetResult();
            IJobDetail job = JobBuilder.Create<CustomersJob>()
                                      .WithIdentity("CustomersJob", null)
                                      .Build();
            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity("CustomerTriggers", null)
                                             .Build();
            scheduler.ScheduleJob(job, trigger).GetAwaiter().GetResult();
        }
    }
}
