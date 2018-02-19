using System;
using System.Diagnostics;

namespace RCS.DIS.Services.Common
{
    public abstract class Service
    {
        protected static void TraceException(Exception exception)
        {
            // TODO Create separate trace file per service.

            Trace.WriteLine(null);
            Trace.WriteLine($"exception.Message = {exception.Message}");
        }
    }
}