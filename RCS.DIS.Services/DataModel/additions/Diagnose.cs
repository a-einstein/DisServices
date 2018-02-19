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
            using (var entities = new Entities())
            {
                var foundEntity = entities.Diagnoses.Find(feedEntity.Key());

                if (foundEntity == null)
                    entities.Diagnoses.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    entities.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = entities.SaveChanges();

                return rowsAffected;
            };
        }

        // Would be candidate for an Interface, if statics were allowed.
        public static int OmschrijvingContainsNumber(string searchString)
        {
            using (var entities = new Entities())
            {
                // TODO Check efficiency.
                var result = entities.Diagnoses.Where(diagnose => diagnose.Omschrijving.Contains(searchString)).Count();

                return result;
            };
        }

        // Would be candidate for an Interface, if statics were allowed.
        public static Diagnose[] OmschrijvingContainsEntities(string searchString)
        {
            using (var entities = new Entities())
            {
                // TODO Check efficiency.
                var result = entities.Diagnoses.Where(diagnose => diagnose.Omschrijving.Contains(searchString)).ToArray<Diagnose>();

                return result;
            };
        }
    }
}