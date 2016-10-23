namespace LoggingWithMef
{
    public class Worker
    {
        ILogger log = new NLogger(typeof(Worker).FullName);
        public void DoWork()
        {
            log.Log("DoWork");
        }
    }
}