using RCS.DIS.DataServices.DataModel;

namespace RCS.DIS.DataServices.Feeding
{
    public class FeedService : IFeedService
    {
        public int CreateOrUpdate(Zorgproduct feedZorgproduct)
        {
            using (var entities = new Entities())
            {
                var foundZorgproduct = entities.Zorgproducts.Find(feedZorgproduct.Key());

                if (foundZorgproduct == null)
                    entities.Zorgproducts.Add(feedZorgproduct);
                else if (feedZorgproduct.Peildatum > foundZorgproduct.Peildatum)
                    entities.Entry(foundZorgproduct).CurrentValues.SetValues(feedZorgproduct);

                var rowsAffected = entities.SaveChanges();

                return rowsAffected;
            };
        }

        // Keep this outside the interface.
        // Maybe moved and applied elsewhere too.
        public int Delete(object[] key)
        {
            using (var entities = new Entities())
            {
                var foundZorgproduct = entities.Zorgproducts.Find(key);

                if (foundZorgproduct != null)
                    entities.Zorgproducts.Remove(foundZorgproduct);

                var rowsAffected = entities.SaveChanges();

                return rowsAffected;
            };
        }
    }
}