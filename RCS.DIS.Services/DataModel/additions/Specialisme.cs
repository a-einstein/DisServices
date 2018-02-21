using System.Linq;

namespace RCS.DIS.Services.DataModel
{
    public partial class Specialisme : IEntity
    {
        #region Feed
        public object[] Key()
        {
            // Note order is significant.
            return new object[]
            {
                SpecialismeCode,
                Versie
            };
        }

        public static int CreateOrUpdate(Specialisme feedEntity)
        {
            using (var entities = new Entities())
            {
                var foundEntity = entities.Specialismes.Find(feedEntity.Key());

                if (foundEntity == null)
                    entities.Specialismes.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    entities.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

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
                var entities = dbContext.Specialismes.Where(entity => entity.Omschrijving.Contains(searchString)).Count();

                return entities;
            };
        }

        public static Specialisme[] OmschrijvingContainsEntities(string searchString)
        {
            using (var dbContext = new Entities())
            {
                var entities = dbContext.Specialismes.Where(entity => entity.Omschrijving.Contains(searchString)).OrderBy(diagnose => diagnose.Omschrijving).ToArray();

                return entities;
            };
        }
        #endregion
    }
}