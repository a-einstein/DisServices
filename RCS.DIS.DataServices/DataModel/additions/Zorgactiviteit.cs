namespace RCS.DIS.DataServices.DataModel
{
    public partial class Zorgactiviteit : IEntity
    {
        public object[] Key()
        {
            // Note order is significant.
            return new object[]
            {
                ZorgactiviteitCode,
                Versie
            };
        }

        public static int CreateOrUpdate(Zorgactiviteit feedEntity)
        {
            using (var entities = new Entities())
            {
                var foundEntity = entities.Zorgactiviteits.Find(feedEntity.Key());

                if (foundEntity == null)
                    entities.Zorgactiviteits.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    entities.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = entities.SaveChanges();

                return rowsAffected;
            };
        }
    }
}