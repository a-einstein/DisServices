using System;
using System.Diagnostics;
using System.IO;
using System.Web.Hosting;

namespace RCS.DIS.Services.Common
{
    public abstract class Service
    {
        protected static void SetupTracing(string fileBasename)
        {
            Trace.AutoFlush = true;

            // Note that neither this nor AppDomain.CurrentDomain.BaseDirectory refers to the bin directory as one might expect.
            var traceDirectory = $"{HostingEnvironment.ApplicationPhysicalPath}\\traces";

            // Creates if needed.
            Directory.CreateDirectory(traceDirectory);

            var traceFile = $"{fileBasename}_{DateTime.Now.ToString("yyyy.MM.dd_HH.mm")}.txt";

            Trace.Listeners.Add(new TextWriterTraceListener($"{traceDirectory}\\{traceFile}"));
        }

        protected static void TraceException(Exception exception)
        {
            // TODO Create separate trace file per service.

            Trace.WriteLine(null);
            Trace.WriteLine(DateTime.Now);
            Trace.WriteLine($"exception.Message = {exception.Message}");
        }
    }
}