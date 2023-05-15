﻿using Quartz.Impl;
namespace MotorAsinBasketRobot.WebAPI.Tasks.Triggers
{
    public class DocumenTriggers
    {
        public static void DocumentStarts()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();
            if (!scheduler.IsStarted)
                scheduler.Start().GetAwaiter().GetResult();
            IJobDetail job = JobBuilder.Create<DocumentsJob>()
                                      .WithIdentity("DocumentsJob", null)
                                      .Build();
            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity("DocumentsTrigger", null)                             
                                             .Build();
            scheduler.ScheduleJob(job, trigger).GetAwaiter().GetResult();
        }
    }
}
