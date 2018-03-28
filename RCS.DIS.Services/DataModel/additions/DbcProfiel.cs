using System;
using System.Diagnostics;
using System.Linq;

namespace RCS.DIS.Services.DataModel
{
    public partial class DbcProfiel : Entity
    {
        #region Feed
        public override void Clean()
        {
            // Trim because whitespace encountered.
            SpecialismeCode = SpecialismeCode.Trim();
            DiagnoseCode = DiagnoseCode.Trim();
            ZorgactiviteitCode = ZorgactiviteitCode.Trim();
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
                ZorgactiviteitCode,
                Versie
            };
        }

        public static int CreateOrUpdate(DbcProfiel feedEntity)
        {
            using (var dbContext = new DisDbContext())
            {
                feedEntity.Clean();

                var foundEntity = dbContext.DbcProfiels.Find(feedEntity.Key());

                if (foundEntity == null)
                    dbContext.DbcProfiels.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    dbContext.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = dbContext.SaveChanges();

                return rowsAffected;
            };
        }

        public override void TraceException(Exception exception)
        {
            base.TraceException(exception);

            Trace.WriteLine($"Entity = {nameof(DbcProfiel)}");

            Trace.WriteLine($"Jaar = {Jaar}");
            Trace.WriteLine($"SpecialismeCode = {SpecialismeCode}");
            Trace.WriteLine($"DiagnoseCode = {DiagnoseCode}");
            Trace.WriteLine($"ZorgproductCode = {ZorgproductCode}");
            Trace.WriteLine($"ZorgactiviteitCode = {ZorgactiviteitCode}");
            Trace.WriteLine($"Versie = {Versie}");
        }
        #endregion

        #region Retrieve
        public static int DbcProfielNumber(
           int jaar,
           string specialismeCode,
           string diagnoseCode,
           int zorgproductCode,
           string zorgactiviteitCode,
           string versie)
        {
            using (var dbContext = new DisDbContext())
            {
                var result = KeysQuery(
                    jaar,
                    specialismeCode,
                    diagnoseCode,
                    zorgproductCode,
                    zorgactiviteitCode,
                    versie,
                    dbContext)
                .Count();

                return result;
            };
        }

        public static DbcProfiel[] DbcProfielEntities(
           int jaar,
           string specialismeCode,
           string diagnoseCode,
           int zorgproductCode,
           string zorgactiviteitCode,
           string versie)
        {
            using (var dbContext = new DisDbContext())
            {
                var result = KeysQuery(
                    jaar,
                    specialismeCode,
                    diagnoseCode,
                    zorgproductCode,
                    zorgactiviteitCode,
                    versie,
                    dbContext)
                .OrderBy
                    (entity => entity.SpecialismeCode).ThenBy
                    (entity => entity.DiagnoseCode).ThenBy
                    (entity => entity.ZorgproductCode).ThenBy
                    (entity => entity.ZorgactiviteitCode)
                .ToArray();

                return result;
            };
        }

        private static IQueryable<DbcProfiel> KeysQuery(
            int jaar,
            string specialismeCode,
            string diagnoseCode,
            int zorgproductCode,
            string zorgactiviteitCode,
            string versie,
            DisDbContext dbContext)
        {
            var query =
                from entity in dbContext.DbcProfiels
                where
                    // Note that the Equal function is not valid here.
                    entity.Jaar == jaar &&
                    entity.SpecialismeCode == specialismeCode &&
                    entity.DiagnoseCode == diagnoseCode &&
                    entity.ZorgproductCode == zorgproductCode &&
                    entity.ZorgactiviteitCode == zorgactiviteitCode &&
                    entity.Versie == versie
                select entity;

            return query;
        }
        #endregion
    }
}