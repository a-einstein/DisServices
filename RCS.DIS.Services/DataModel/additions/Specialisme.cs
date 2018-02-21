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
            using (var dbContext = new Entities())
            {
                var foundEntity = dbContext.Specialismes.Find(feedEntity.Key());

                if (foundEntity == null)
                    dbContext.Specialismes.Add(feedEntity);
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
                var result = dbContext.Specialismes.Where(entity => entity.Omschrijving.Contains(searchString)).Count();

                return result;
            };
        }

        public static Specialisme[] OmschrijvingContainsEntities(string searchString)
        {
            using (var dbContext = new Entities())
            {
                var result = dbContext.Specialismes.Where(entity => entity.Omschrijving.Contains(searchString)).OrderBy(diagnose => diagnose.Omschrijving).ToArray();

                return result;
            };
        }
        #endregion
    }
}