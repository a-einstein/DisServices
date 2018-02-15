using RCS.DIS.DataServices.DataModel;
using System.ServiceModel;

namespace RCS.DIS.DataServices.Feeding
{
    [ServiceContract]
    interface IFeedService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int DbcOverzichtCreateOrUpdate(DbcOverzicht entity);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int DiagnoseCreateOrUpdate(Diagnose entity);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int SpecialismeCreateOrUpdate(Specialisme entity);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int ZorgactiviteitCreateOrUpdate(Zorgactiviteit entity);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int ZorgproductCreateOrUpdate(Zorgproduct entity);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int ZorgprofielklasseCreateOrUpdate(Zorgprofielklasse entity);
    }
}
