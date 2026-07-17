using System;
using System.Collections.Generic;
using System.Text;

namespace Practiculi.Sevices
{
    internal class Logger : IDisposable
    {
        public Logger()
        {
            Console.WriteLine("[LOG]: App session started.");
        }

        public void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }

        public void Dispose()
        {
            Console.WriteLine("[LOG]: App session ended. Resources released.");
        }
    }
}
