using System.Linq;

namespace RCS.DIS.Services.DataModel
{
    public partial class Diagnose : IEntity
    {
        public object[] Key()
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
                var foundEntity = dbContext.Diagnoses.Find(feedEntity.Key());

                if (foundEntity == null)
                    dbContext.Diagnoses.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    dbContext.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = dbContext.SaveChanges();

                return rowsAffected;
            };
        }

        // Would be candidate for an Interface, if statics were allowed.
        public static int OmschrijvingContainsNumber(string searchString)
        {
            using (var dbContext = new Entities())
            {
                // TODO Check efficiency.
                var entities = dbContext.Diagnoses.Where(entity => entity.Omschrijving.Contains(searchString)).Count();

                return entities;
            };
        }

        // Would be candidate for an Interface, if statics were allowed.
        public static Diagnose[] OmschrijvingContainsEntities(string searchString)
        {
            using (var dbContext = new Entities())
            {
                // TODO Check efficiency.
                var entities = dbContext.Diagnoses.Where(entity => entity.Omschrijving.Contains(searchString)).OrderBy(diagnose => diagnose.Omschrijving).ToArray();

                return entities;
            };
        }
    }
}