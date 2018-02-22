using System;
using System.Diagnostics;

namespace RCS.DIS.Services.DataModel
{
    public abstract class Entity
    {
        // TODO Call this implicitly in postconstruction manner.
        public abstract void Clean();

        public abstract object[] Key();

        public virtual void TraceException(Exception exception)
        {
            Trace.WriteLine(null);
            Trace.WriteLine(DateTime.Now);
            Trace.WriteLine($"exception.Message = {exception.Message}");
        }
    }
}