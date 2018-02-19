using RCS.DIS.Services.Common;
using RCS.DIS.Services.DataModel;
using System;

namespace RCS.DIS.Services.Feeding
{
    public class FeedService : Service, IFeedService
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
    }
}