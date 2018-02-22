using RCS.DIS.Services.Common;
using RCS.DIS.Services.DataModel;
using System;
using System.ServiceModel;

namespace RCS.DIS.Services.Feeding
{
    public class FeedService : Service, IFeedService
    {
        static FeedService()
        {
            SetupTracing(nameof(FeedService));
        }

        public int DbcOverzichtCreateOrUpdate(DbcOverzicht feedEntity)
        {
            try
            {
                return DbcOverzicht.CreateOrUpdate(feedEntity);
            }
            catch (Exception exception)
            {
                feedEntity.TraceException(exception);

                throw new FaultException($"{nameof(FeedService)} - {nameof(DbcOverzicht)} - {exception.Message}");
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
                feedEntity.TraceException(exception);

                throw new FaultException($"{nameof(FeedService)} - {nameof(DbcProfiel)} - {exception.Message}");
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
                feedEntity.TraceException(exception);

                throw new FaultException($"{nameof(FeedService)} - {nameof(Diagnose)} - {exception.Message}");
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
                feedEntity.TraceException(exception);

                throw new FaultException($"{nameof(FeedService)} - {nameof(Specialisme)} - {exception.Message}");
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
                feedEntity.TraceException(exception);

                throw new FaultException($"{nameof(FeedService)} - {nameof(Zorgactiviteit)} - {exception.Message}");
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
                feedEntity.TraceException(exception);

                throw new FaultException($"{nameof(FeedService)} - {nameof(Zorgproduct)} - {exception.Message}");
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
                feedEntity.TraceException(exception);

                throw new FaultException($"{nameof(FeedService)} - {nameof(Zorgprofielklasse)} - {exception.Message}");
            }
        }
    }
}