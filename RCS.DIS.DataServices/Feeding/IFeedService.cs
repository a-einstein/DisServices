using RCS.DIS.DataServices.DataModel;
using System.ServiceModel;

namespace RCS.DIS.DataServices.Feeding
{
    [ServiceContract]
    interface IFeedService
    {
        [OperationContract]
        int DbcOverzichtCreateOrUpdate(DbcOverzicht entity);

        [OperationContract]
        int DiagnoseCreateOrUpdate(Diagnose entity);

        [OperationContract]
        int SpecialismeCreateOrUpdate(Specialisme entity);

        [OperationContract]
        int ZorgactiviteitCreateOrUpdate(Zorgactiviteit entity);

        [OperationContract]
        int ZorgproductCreateOrUpdate(Zorgproduct entity);

        [OperationContract]
        int ZorgprofielklasseCreateOrUpdate(Zorgprofielklasse entity);
    }
}
