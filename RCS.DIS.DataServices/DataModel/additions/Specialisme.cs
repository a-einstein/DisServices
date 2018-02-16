namespace RCS.DIS.Services.DataModel
{
    public partial class Specialisme : IEntity
    {
        public object[] Key()
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
            using (var entities = new Entities())
            {
                var foundEntity = entities.Specialismes.Find(feedEntity.Key());

                if (foundEntity == null)
                    entities.Specialismes.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    entities.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = entities.SaveChanges();

                return rowsAffected;
            };
        }
    }
}