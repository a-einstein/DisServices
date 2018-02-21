using System.Linq;

namespace RCS.DIS.Services.DataModel
{
    public partial class Zorgactiviteit : IEntity
    {
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
            using (var entities = new Entities())
            {
                var foundEntity = entities.Zorgactiviteits.Find(feedEntity.Key());

                if (foundEntity == null)
                    entities.Zorgactiviteits.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    entities.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = entities.SaveChanges();

                return rowsAffected;
            };
        }

        public static int OmschrijvingContainsNumber(string searchString)
        {
            using (var dbContext = new Entities())
            {
                var entities = dbContext.Zorgactiviteits.Where(entity => entity.Omschrijving.Contains(searchString)).Count();

                return entities;
            };
        }

        public static Zorgactiviteit[] OmschrijvingContainsEntities(string searchString)
        {
            using (var dbContext = new Entities())
            {
                var entities = dbContext.Zorgactiviteits.Where(entity => entity.Omschrijving.Contains(searchString)).OrderBy(diagnose => diagnose.Omschrijving).ToArray();

                return entities;
            };
        }
    }
}