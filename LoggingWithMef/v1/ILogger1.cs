using System.ComponentModel.Composition;

namespace LoggingWithMef.v1
{
    [InheritedExport]
    public interface ILogger1
    {
        void Log(string message);
    }
}
