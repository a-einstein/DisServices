using RCS.DIS.Services.DTOs;
using System.ServiceModel;

namespace RCS.DIS.Services.Retrieving
{
    [ServiceContract]
    public interface IRetrieveService
    {
        [OperationContract]
        int DiagnoseOmschrijvingContainsNumber(string searchString);

        [OperationContract]
        Diagnose[] DiagnoseOmschrijvingContainsEntities(string searchString);
    }
}
