using System;
using System.Diagnostics;
using System.Linq;

namespace RCS.DIS.Services.DataModel
{
    public partial class DbcOverzicht : Entity
    {
        #region Feed
        public override void Clean()
        {
            // Trim because whitespace encountered.
            SpecialismeCode = SpecialismeCode.Trim();
            DiagnoseCode = DiagnoseCode.Trim();
            Versie = Versie.Trim();
        }

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
            using (var dbContext = new DisDbContext())
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
            using (var dbContext = new DisDbContext())
            {
                var result = KeysQuery(
                    jaar,
                    specialismeCode,
                    diagnoseCode,
                    zorgproductCode,
                    versie,
                    dbContext)
                .Count();

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
            using (var dbContext = new DisDbContext())
            {
                 var result = KeysQuery(
                    jaar,
                    specialismeCode,
                    diagnoseCode,
                    zorgproductCode,
                    versie,
                    dbContext)
                .OrderBy
                    (entity => entity.SpecialismeCode).ThenBy
                    (entity => entity.DiagnoseCode).ThenBy
                    (entity => entity.ZorgproductCode)
                .ToArray();

                return result;
            };
        }

        private static IQueryable<DbcOverzicht> KeysQuery(
            int jaar,
            string specialismeCode,
            string diagnoseCode,
            int zorgproductCode,
            string versie, 
            DisDbContext dbContext)
        {
            var query =
                from entity in dbContext.DbcOverzichts
                where
                    // Note that the Equal function is not valid here.
                    entity.Jaar == jaar &&
                    entity.SpecialismeCode == specialismeCode &&
                    entity.DiagnoseCode == diagnoseCode &&
                    entity.ZorgproductCode == zorgproductCode &&
                    entity.Versie == versie
                select entity;

            return query;
        }

        // Arbitrarily collect here, being the smaller of the 2 overview tables.

        public static short[] Jaren()
        {
            using (var dbContext = new DisDbContext())
            {
                // TODO Check efficiency.
                var result = dbContext.DbcOverzichts.Select(entity => entity.Jaar).Distinct().ToArray();

                return result;
            };
        }

        public static string[] Versies()
        {
            using (var dbContext = new DisDbContext())
            {
                // TODO Check efficiency.
                var result = dbContext.DbcOverzichts.Select(entity => entity.Versie).Distinct().ToArray();

                return result;
            };
        }
        #endregion
    }
}