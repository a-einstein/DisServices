using System.Linq;

namespace RCS.DIS.Services.DataModel
{
    public partial class DbcProfiel : IEntity
    {
        #region Feed
        public object[] Key()
        {
            // Note order is significant.
            return new object[]
            {
                Jaar,
                SpecialismeCode,
                DiagnoseCode,
                ZorgproductCode,
                ZorgactiviteitCode,
                Versie
            };
        }

        public static int CreateOrUpdate(DbcProfiel feedEntity)
        {
            using (var entities = new Entities())
            {
                var foundEntity = entities.DbcProfiels.Find(feedEntity.Key());

                if (foundEntity == null)
                    entities.DbcProfiels.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    entities.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = entities.SaveChanges();

                return rowsAffected;
            };
        }
        #endregion

        #region Retrieve
        // Arbitrarily collect the Versies here, being the largest table.
        public static string[] Versies()
        {
            using (var dbContext = new Entities())
            {
                // TODO Check efficiency.
                var entities = dbContext.DbcProfiels.Select(entity => entity.Versie).Distinct().ToArray();

                return entities;
            };
        }
        #endregion
    }
}