﻿using System;
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
            using (var dbContext = new Entities())
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
            using (var dbContext = new Entities())
            {
                var result = dbContext.DbcProfiels.Where(entity =>
                        entity.Jaar.Equals(jaar) &&
                        entity.SpecialismeCode.Equals(specialismeCode) &&
                        entity.DiagnoseCode.Equals(diagnoseCode) &&
                        entity.ZorgproductCode.Equals(zorgproductCode) &&
                        entity.ZorgactiviteitCode.Equals(zorgactiviteitCode) &&
                        entity.Versie.Equals(versie)).Count();

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
            using (var dbContext = new Entities())
            {
                var result = dbContext.DbcProfiels.Where(entity =>
                        entity.Jaar.Equals(jaar) &&
                        entity.SpecialismeCode.Equals(specialismeCode) &&
                        entity.DiagnoseCode.Equals(diagnoseCode) &&
                        entity.ZorgproductCode.Equals(zorgproductCode) &&
                        entity.ZorgactiviteitCode.Equals(zorgactiviteitCode) &&
                        entity.Versie.Equals(versie))
                    .OrderBy
                        (entity => entity.SpecialismeCode).ThenBy
                        (entity => entity.DiagnoseCode).ThenBy
                        (entity => entity.ZorgproductCode).ThenBy
                        (entity => entity.ZorgactiviteitCode)
                    .ToArray();

                return result;
            };
        }

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