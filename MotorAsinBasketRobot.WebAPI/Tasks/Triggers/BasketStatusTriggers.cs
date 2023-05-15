using Quartz.Impl;
namespace MotorAsinBasketRobot.WebAPI.Tasks.Triggers
{
    public class BasketStatusTriggers
    {
        public static void BasketStatusStarts()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();
            if (!scheduler.IsStarted)
                scheduler.Start().GetAwaiter().GetResult();
            IJobDetail job = JobBuilder.Create<BasketStatusJob>()
                                      .WithIdentity("BasketStatusJob", null)
                                      .Build();
            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity("BasketStatusJob",null)
                                             .Build();
            scheduler.ScheduleJob(job, trigger).GetAwaiter().GetResult();
        }
    }
}
