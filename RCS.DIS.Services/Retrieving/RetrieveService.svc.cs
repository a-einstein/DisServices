using RCS.DIS.Services.Common;
using RCS.DIS.Services.DataModel;
using System;
using System.Linq;

namespace RCS.DIS.Services.Retrieving
{
    public class RetrieveService : Service, IRetrieveService
    {
        public int DiagnoseOmschrijvingContainsNumber(string searchString)
        {
            try
            {
                return Diagnose.OmschrijvingContainsNumber(searchString);
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return 0;
            }
        }

        public Diagnose[] DiagnoseOmschrijvingContainsEntities(string searchString)
        {
            try
            {
                return Diagnose.OmschrijvingContainsEntities(searchString);
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return null;
            }
        }
    }
}
