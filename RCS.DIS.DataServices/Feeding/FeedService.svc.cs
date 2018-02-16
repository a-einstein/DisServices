using RCS.DIS.DataServices.DataModel;
using System;
using System.Diagnostics;

namespace RCS.DIS.DataServices.Feeding
{
    public class FeedService : IFeedService
    {
        public int DbcOverzichtCreateOrUpdate(DbcOverzicht feedEntity)
        {
            try
            {
                return DbcOverzicht.CreateOrUpdate(feedEntity);
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return 0;
            }
        }

        public int DbcDbcProfielCreateOrUpdate(DbcProfiel feedEntity)
        {
            try
            {
                return DbcProfiel.CreateOrUpdate(feedEntity);
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return 0;
            }
        }

        public int DiagnoseCreateOrUpdate(Diagnose feedEntity)
        {
            try
            {
                return Diagnose.CreateOrUpdate(feedEntity);
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return 0;
            }
        }

        public int SpecialismeCreateOrUpdate(Specialisme feedEntity)
        {
            try
            {
                return Specialisme.CreateOrUpdate(feedEntity);
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return 0;
            }
        }

        public int ZorgactiviteitCreateOrUpdate(Zorgactiviteit feedEntity)
        {
            try
            {
                return Zorgactiviteit.CreateOrUpdate(feedEntity);
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return 0;
            }
        }

        public int ZorgproductCreateOrUpdate(Zorgproduct feedEntity)
        {
            try
            {
                return Zorgproduct.CreateOrUpdate(feedEntity);
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return 0;
            }
        }

        public int ZorgprofielklasseCreateOrUpdate(Zorgprofielklasse feedEntity)
        {
            try
            {
                return Zorgprofielklasse.CreateOrUpdate(feedEntity);
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return 0;
            }
        }

        private static void TraceException(Exception exception)
        {
            Trace.WriteLine(null);
            Trace.WriteLine($"exception.Message = {exception.Message}");
        }
    }
}