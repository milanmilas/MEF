using System;
using System.ComponentModel.Composition;
using System.Diagnostics;

namespace LoggingWithMef.v2
{
    public class Worker2
    {
        //[Import]
        public ILogger2 log { get; set; }

        public void DoWork()
        {
            log.Log("DoWork");
        }
    }
}