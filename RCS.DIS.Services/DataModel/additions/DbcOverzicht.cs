using System;
using System.Diagnostics;
using System.Linq;

namespace RCS.DIS.Services.DataModel
{
    public partial class DbcOverzicht : Entity
    {
        public override void Clean()
        {
            // Trim because whitespace encountered.
            SpecialismeCode = SpecialismeCode.Trim();
            DiagnoseCode = DiagnoseCode.Trim();
            Versie = Versie.Trim();
        }

        #region Feed
        public override object[] Key()
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
                feedEntity.Clean();

                var foundEntity = dbContext.DbcOverzichts.Find(feedEntity.Key());

                if (foundEntity == null)
                    dbContext.DbcOverzichts.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    dbContext.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = dbContext.SaveChanges();

                return rowsAffected;
            };
        }

        public override void TraceException(Exception exception)
        {
            base.TraceException(exception);

            Trace.WriteLine($"Entity = {nameof(DbcOverzicht)}");

            Trace.WriteLine($"Jaar = {Jaar}");
            Trace.WriteLine($"SpecialismeCode = {SpecialismeCode}");
            Trace.WriteLine($"DiagnoseCode = {DiagnoseCode}");
            Trace.WriteLine($"ZorgproductCode = {ZorgproductCode}");
            Trace.WriteLine($"Versie = {Versie}");
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