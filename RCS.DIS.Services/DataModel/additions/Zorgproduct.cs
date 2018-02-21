using System.Linq;

namespace RCS.DIS.Services.DataModel
{
    public partial class Zorgproduct : IEntity
    {
        #region Feed
        public object[] Key()
        {
            // Note order is significant.
            return new object[]
            {
                ZorgproductCode,
                Versie
            };
        }

        // Would rather put this in interface, which is impossible.
        // TODO Consider some sort of factory class.
        public static int CreateOrUpdate(Zorgproduct feedEntity)
        {
            using (var entities = new Entities())
            {
                var foundEntity = entities.Zorgproducts.Find(feedEntity.Key());

                if (foundEntity == null)
                    entities.Zorgproducts.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    entities.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = entities.SaveChanges();

                return rowsAffected;
            };
        }

        // Currently only for test purposes.
        public static int Delete(object[] key)
        {
            using (var entities = new Entities())
            {
                var foundEntity = entities.Zorgproducts.Find(key);

                if (foundEntity != null)
                    entities.Zorgproducts.Remove(foundEntity);

                var rowsAffected = entities.SaveChanges();

                return rowsAffected;
            };
        }
        #endregion

        #region Retrieve
        public static int OmschrijvingContainsNumber(string searchString)
        {
            using (var dbContext = new Entities())
            {
                var entities = dbContext.Zorgproducts.Where(entity => entity.OmschrijvingConsument.Contains(searchString)|| entity.OmschrijvingLatijn.Contains(searchString)).Count();

                return entities;
            };
        }

        public static Zorgproduct[] OmschrijvingContainsEntities(string searchString)
        {
            using (var dbContext = new Entities())
            {
                var entities = dbContext.Zorgproducts.Where(entity => entity.OmschrijvingConsument.Contains(searchString) || entity.OmschrijvingLatijn.Contains(searchString)).OrderBy(diagnose => diagnose.OmschrijvingConsument).ToArray();

                return entities;
            };
        }
        #endregion
    }
}