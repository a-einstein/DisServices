using RCS.DIS.DataServices.DataModel;
using System.ServiceModel;

namespace RCS.DIS.DataServices.Feeding
{
    [ServiceContract]
    interface IFeedService
    {
        [OperationContract]
        int CreateOrUpdate(Zorgproduct zorgproduct);
    }
}
