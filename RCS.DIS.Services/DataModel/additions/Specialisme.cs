using System;
using System.Diagnostics;
using System.Linq;

namespace RCS.DIS.Services.DataModel
{
    public partial class Specialisme : Entity
    {
        #region Feed
        public override void Clean()
        {
            // Trim because whitespace encountered.
            SpecialismeCode = SpecialismeCode.Trim();
            Versie = Versie.Trim();
        }

        public override object[] Key()
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
                feedEntity.Clean();

                var foundEntity = dbContext.Specialismes.Find(feedEntity.Key());

                if (foundEntity == null)
                    dbContext.Specialismes.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    dbContext.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = dbContext.SaveChanges();

                return rowsAffected;
            };
        }

        public override void TraceException(Exception exception)
        {
            base.TraceException(exception);

            Trace.WriteLine($"Entity = {nameof(Specialisme)}");

            Trace.WriteLine($"SpecialismeCode = {SpecialismeCode}");
            Trace.WriteLine($"Versie = {Versie}");
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