using RCS.DIS.DataServices.DataModel;

namespace RCS.DIS.DataServices.Feeding
{
    public class FeedService : IFeedService
    {
        public int ZorgproductCreateOrUpdate(Zorgproduct feedEntity)
        {
            return Zorgproduct.CreateOrUpdate(feedEntity);
        }

        public int SpecialismeCreateOrUpdate(Specialisme feedEntity)
        {
            return Specialisme.CreateOrUpdate(feedEntity);
        }
    }
}