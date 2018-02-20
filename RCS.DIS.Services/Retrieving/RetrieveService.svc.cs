using AutoMapper;
using RCS.DIS.Services.Common;
using RCS.DIS.Services.DTOs;
using System;
using System.Linq;

namespace RCS.DIS.Services.Retrieving
{
    public class RetrieveService : Service, IRetrieveService
    {
        static RetrieveService()
        {
            SetupTracing(nameof(RetrieveService));

            // Turned out necessary to use DTOs to prevent serialization exception.
            // Experimental use of AutoMapper.
            Mapper.Initialize(configuration => { configuration.CreateMap<DataModel.Diagnose, Diagnose>(); });
        }

        public string[] Versies()
        {
            try
            {
                return DataModel.Zorgprofielklasse.Versies();
            }
            catch (Exception exception)
            {
                TraceException(exception);
                return null;
            }
        }

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
    }
}
