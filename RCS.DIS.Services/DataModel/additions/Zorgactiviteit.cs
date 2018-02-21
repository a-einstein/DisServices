using System.Linq;

namespace RCS.DIS.Services.DataModel
{
    public partial class Zorgactiviteit : IEntity
    {
        #region Feed
        public object[] Key()
        {
            // Note order is significant.
            return new object[]
            {
                ZorgactiviteitCode,
                Versie
            };
        }

        public static int CreateOrUpdate(Zorgactiviteit feedEntity)
        {
            using (var dbContext = new Entities())
            {
                var foundEntity = dbContext.Zorgactiviteits.Find(feedEntity.Key());

                if (foundEntity == null)
                    dbContext.Zorgactiviteits.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    dbContext.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = dbContext.SaveChanges();

                return rowsAffected;
            };
        }
        #endregion

        #region Retrieve
        public static int OmschrijvingContainsNumber(string searchString)
        {
            using (var dbContext = new Entities())
            {
                var result = dbContext.Zorgactiviteits.Where(entity => entity.Omschrijving.Contains(searchString)).Count();

                return result;
            };
        }

        public static Zorgactiviteit[] OmschrijvingContainsEntities(string searchString)
        {
            using (var dbContext = new Entities())
            {
                var result = dbContext.Zorgactiviteits.Where(entity => entity.Omschrijving.Contains(searchString)).OrderBy(diagnose => diagnose.Omschrijving).ToArray();

                return result;
            };
        }
        #endregion
    }
}