using Quartz;

namespace MotorAsinBasketRobot.WebAPI.Tasks.Jobs
{
    public class DocumentsJob : IJob
    {
        public DocumentsJob()
        {
            
        }
        public Task Execute(IJobExecutionContext context)
        {
         return Task.CompletedTask;
        }
    }
}
