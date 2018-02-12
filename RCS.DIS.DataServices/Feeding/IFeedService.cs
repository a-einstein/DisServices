using RCS.DIS.DataServices.DataModel;
using System.ServiceModel;


namespace RCS.DIS.DataServices.Feeding
{
    [ServiceContract]
    public interface IFeedService
    {
        [OperationContract]
        int CreateOrUpdate(Zorgproduct zorgproduct);
    }
}
