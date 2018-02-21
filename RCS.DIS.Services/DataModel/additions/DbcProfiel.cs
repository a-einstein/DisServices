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
            using (var dbContext = new Entities())
            {
                var foundEntity = dbContext.DbcProfiels.Find(feedEntity.Key());

                if (foundEntity == null)
                    dbContext.DbcProfiels.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    dbContext.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = dbContext.SaveChanges();

                return rowsAffected;
            };
        }
        #endregion

        #region Retrieve
        // Arbitrarily collect here, being the largest table.

        public static short[] Jaren()
        {
            using (var dbContext = new Entities())
            {
                // TODO Check efficiency.
                var result = dbContext.DbcProfiels.Select(entity => entity.Jaar).Distinct().ToArray();

                return result;
            };
        }

        public static string[] Versies()
        {
            using (var dbContext = new Entities())
            {
                // TODO Check efficiency.
                var result = dbContext.DbcProfiels.Select(entity => entity.Versie).Distinct().ToArray();

                return result;
            };
        }
        #endregion
    }
}