using AutoMapper;
using RCS.DIS.Services.Common;
using RCS.DIS.Services.DTOs;
using System;
using System.Linq;

namespace RCS.DIS.Services.Retrieving
{
    public class RetrieveService : Service, IRetrieveService
    {
        #region Construction
        static RetrieveService()
        {
            SetupTracing(nameof(RetrieveService));

            // Turned out necessary to use DTOs to prevent serialization exception.
            // Experimental use of AutoMapper.
            Mapper.Initialize(configuration => { configuration.CreateMap<DataModel.Diagnose, Diagnose>(); });
        }
        #endregion

        #region Versies
        public string[] Versies()
        {
            try
            {
                return DataModel.DbcProfiel.Versies();
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return null;
            }
        }
        #endregion

        #region Diagnoses
        public int DiagnoseOmschrijvingContainsNumber(string searchString)
        {
            try
            {
                return DataModel.Diagnose.OmschrijvingContainsNumber(searchString);
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
                var entities = DataModel.Diagnose.OmschrijvingContainsEntities(searchString);
                var dtos = entities.Select(entity => Mapper.Map<DTOs.Diagnose>(entity));

                return dtos.ToArray();
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return null;
            }
        }
        #endregion

        #region Specialismes
        public int SpecialismeOmschrijvingContainsNumber(string searchString)
        {
            try
            {
                return DataModel.Specialisme.OmschrijvingContainsNumber(searchString);
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return 0;
            }
        }

        public Specialisme[] SpecialismeOmschrijvingContainsEntities(string searchString)
        {
            try
            {
                var entities = DataModel.Specialisme.OmschrijvingContainsEntities(searchString);
                var dtos = entities.Select(entity => Mapper.Map<DTOs.Specialisme>(entity));

                return dtos.ToArray();
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return null;
            }
        }
        #endregion

        #region Zorgactiviteiten
        public int ZorgactiviteitOmschrijvingContainsNumber(string searchString)
        {
            try
            {
                return DataModel.Zorgactiviteit.OmschrijvingContainsNumber(searchString);
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return 0;
            }
        }

        public Zorgactiviteit[] ZorgactiviteitOmschrijvingContainsEntities(string searchString)
        {
            try
            {
                var entities = DataModel.Zorgactiviteit.OmschrijvingContainsEntities(searchString);
                var dtos = entities.Select(entity => Mapper.Map<DTOs.Zorgactiviteit>(entity));

                return dtos.ToArray();
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return null;
            }
        }
        #endregion

        #region Zorgproducten
        public int ZorgproductOmschrijvingContainsNumber(string searchString)
        {
            try
            {
                return DataModel.Zorgproduct.OmschrijvingContainsNumber(searchString);
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return 0;
            }
        }

        public Zorgproduct[] ZorgproductOmschrijvingContainsEntities(string searchString)
        {
            try
            {
                var entities = DataModel.Zorgproduct.OmschrijvingContainsEntities(searchString);
                var dtos = entities.Select(entity => Mapper.Map<DTOs.Zorgproduct>(entity));

                return dtos.ToArray();
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return null;
            }
        }
        #endregion
    }
}
