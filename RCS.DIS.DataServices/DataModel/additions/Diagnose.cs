namespace RCS.DIS.DataServices.DataModel
{
    public partial class Diagnose : IEntity
    {
        public object[] Key()
        {
            // Note order is significant.
            return new object[] { DiagnoseCode, SpecialismeCode, Versie };
        }

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
    }
}