using System.Linq;

namespace RCS.DIS.Services.DataModel
{
    public partial class DbcOverzicht : IEntity
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
                Versie
            };
        }

        public static int CreateOrUpdate(DbcOverzicht feedEntity)
        {
            using (var dbContext = new Entities())
            {
                var foundEntity = dbContext.DbcOverzichts.Find(feedEntity.Key());

                if (foundEntity == null)
                    dbContext.DbcOverzichts.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    dbContext.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = dbContext.SaveChanges();

                return rowsAffected;
            };
        }
        #endregion

        #region Retrieve
        public static int DbcOverzichtNumber(
          int jaar,
          string specialismeCode,
          string diagnoseCode,
          int zorgproductCode,
          string versie)
        {
            using (var dbContext = new Entities())
            {
                var result = dbContext.DbcOverzichts.Where(entity =>
                        entity.Jaar.Equals(jaar) &&
                        entity.SpecialismeCode.Equals(specialismeCode) &&
                        entity.DiagnoseCode.Equals(diagnoseCode) &&
                        entity.ZorgproductCode.Equals(zorgproductCode) &&
                        entity.Versie.Equals(versie)).Count();

                return result;
            };
        }

        public static DbcOverzicht[] DbcOverzichtEntities(
           int jaar,
           string specialismeCode,
           string diagnoseCode,
           int zorgproductCode,
           string versie)
        {
            using (var dbContext = new Entities())
            {
                var result = dbContext.DbcOverzichts.Where(entity =>
                        entity.Jaar.Equals(jaar) &&
                        entity.SpecialismeCode.Equals(specialismeCode) &&
                        entity.DiagnoseCode.Equals(diagnoseCode) &&
                        entity.ZorgproductCode.Equals(zorgproductCode) &&
                        entity.Versie.Equals(versie))
                    .OrderBy
                        (entity => entity.SpecialismeCode).ThenBy
                        (entity => entity.DiagnoseCode).ThenBy
                        (entity => entity.ZorgproductCode)
                    .ToArray();

                return result;
            };
        }
        #endregion
    }
}