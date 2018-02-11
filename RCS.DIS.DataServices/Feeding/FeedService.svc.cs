using RCS.DIS.DataServices.DataModel;

namespace RCS.DIS.DataServices.Feeding
{
    public class FeedService : IFeedService
    {
        public int Insert(Zorgproduct entity)
        {
            int rowsAffected;

            using (var entities = new Entities())
            {
                // TODO Test if already there and if Peildatum has changed. 
                entities.Zorgproducts.Add(entity);
                rowsAffected = entities.SaveChanges();
            };

            return rowsAffected;
        }
    }
}