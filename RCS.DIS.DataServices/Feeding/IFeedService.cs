using RCS.DIS.Services.DataModel;
using System.ServiceModel;

namespace RCS.DIS.Services.Feeding
{
    [ServiceContract]
    interface IFeedService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int DbcOverzichtCreateOrUpdate(DbcOverzicht entity);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int DbcDbcProfielCreateOrUpdate(DbcProfiel entity);

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
