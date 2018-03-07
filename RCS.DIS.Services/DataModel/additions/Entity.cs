using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

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

        protected static string[] SplitOnSpaceOrQuote(string searchString)
        {
            var regEx = new Regex("(\"[^\"]+\")|\\S+", RegexOptions.IgnoreCase);

            var result = regEx.Matches(searchString).Cast<Match>().Select(match => match.Value.Replace("\"", "")).ToArray();

            return result;
        }
    }
}