using System;
using System.Diagnostics;
using System.Linq;

namespace RCS.DIS.Services.DataModel
{
    public partial class Diagnose : Entity
    {
        #region Feed
        public override void Clean()
        {
            // Trim because whitespace encountered.
            DiagnoseCode = DiagnoseCode.Trim();
            SpecialismeCode = SpecialismeCode.Trim();
            Versie = Versie.Trim();
        }

        public override object[] Key()
        {
            // Note order is significant.
            return new object[]
            {
                DiagnoseCode,
                SpecialismeCode,
                Versie
            };
        }

        // Would be candidate for an Interface, if statics were allowed.
        public static int CreateOrUpdate(Diagnose feedEntity)
        {
            using (var dbContext = new Entities())
            {
                feedEntity.Clean();

                var foundEntity = dbContext.Diagnoses.Find(feedEntity.Key());

                if (foundEntity == null)
                    dbContext.Diagnoses.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    dbContext.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = dbContext.SaveChanges();

                return rowsAffected;
            };
        }

        public override void TraceException(Exception exception)
        {
            base.TraceException(exception);

            Trace.WriteLine($"Entity = {nameof(Diagnose)}");

            Trace.WriteLine($"SpecialismeCode = {SpecialismeCode}");
            Trace.WriteLine($"DiagnoseCode = {DiagnoseCode}");
            Trace.WriteLine($"Versie = {Versie}");
        }
        #endregion

        #region Retrieve
        // Would be candidate for an Interface, if statics were allowed.
        public static int OmschrijvingContainsNumber(string searchString)
        {
            using (var dbContext = new Entities())
            {
                // TODO Check efficiency.
                var result = dbContext.Diagnoses.Where(entity => entity.Omschrijving.Contains(searchString)).Count();

                return result;
            };
        }

        // Would be candidate for an Interface, if statics were allowed.
        public static Diagnose[] OmschrijvingContainsEntities(string searchString)
        {
            using (var dbContext = new Entities())
            {
                // TODO Check efficiency.
                var result = dbContext.Diagnoses.Where(entity => entity.Omschrijving.Contains(searchString)).OrderBy(diagnose => diagnose.Omschrijving).ToArray();

                return result;
            };
        }
        #endregion
    }
}