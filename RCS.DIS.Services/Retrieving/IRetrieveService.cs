using RCS.DIS.Services.DTOs;
using System.ServiceModel;

namespace RCS.DIS.Services.Retrieving
{
    [ServiceContract]
    public interface IRetrieveService
    {
        [OperationContract]
        string[] Versies();

        [OperationContract]
        int DiagnoseOmschrijvingContainsNumber(string searchString);

        [OperationContract]
        Diagnose[] DiagnoseOmschrijvingContainsEntities(string searchString);

        [OperationContract]
        int SpecialismeOmschrijvingContainsNumber(string searchString);

        [OperationContract]
        Specialisme[] SpecialismeOmschrijvingContainsEntities(string searchString);
    }
}
