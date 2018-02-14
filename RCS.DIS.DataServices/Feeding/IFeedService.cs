using RCS.DIS.DataServices.DataModel;
using System.ServiceModel;

namespace RCS.DIS.DataServices.Feeding
{
    [ServiceContract]
    interface IFeedService
    {
        [OperationContract]
        int ZorgproductCreateOrUpdate(Zorgproduct zorgproduct);

        [OperationContract]
        int SpecialismeCreateOrUpdate(Specialisme specialisme);
    }
}
