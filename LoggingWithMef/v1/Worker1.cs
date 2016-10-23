using System.ComponentModel.Composition;

namespace LoggingWithMef.v1
{
    public class Worker1
    {
        [Import]
        public ILogger1 log { get; set; }

        public void DoWork()
        {
            log.Log("DoWork");
        }
    }
}