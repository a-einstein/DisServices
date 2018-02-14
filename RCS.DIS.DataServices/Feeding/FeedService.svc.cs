using RCS.DIS.DataServices.DataModel;

namespace RCS.DIS.DataServices.Feeding
{
    public class FeedService : IFeedService
    {
        public int DbcOverzichtCreateOrUpdate(DbcOverzicht feedEntity)
        {
            return DbcOverzicht.CreateOrUpdate(feedEntity);
        }

        public int DiagnoseCreateOrUpdate(Diagnose feedEntity)
        {
            return Diagnose.CreateOrUpdate(feedEntity);
        }

        public int SpecialismeCreateOrUpdate(Specialisme feedEntity)
        {
            return Specialisme.CreateOrUpdate(feedEntity);
        }

        public int ZorgactiviteitCreateOrUpdate(Zorgactiviteit feedEntity)
        {
            return Zorgactiviteit.CreateOrUpdate(feedEntity);
        }

        public int ZorgproductCreateOrUpdate(Zorgproduct feedEntity)
        {
            return Zorgproduct.CreateOrUpdate(feedEntity);
        }

        public int ZorgprofielklasseCreateOrUpdate(Zorgprofielklasse feedEntity)
        {
            return Zorgprofielklasse.CreateOrUpdate(feedEntity);
        }
    }
}