namespace RCS.DIS.DataServices.DataModel
{
    public partial class Zorgprofielklasse : IEntity
    {
        public object[] Key()
        {
            // Note order is significant.
            return new object[]
            {
                ZorgprofielklasseCode,
                Versie
            };
        }

        public static int CreateOrUpdate(Zorgprofielklasse feedEntity)
        {
            using (var entities = new Entities())
            {
                var foundEntity = entities.Zorgprofielklasses.Find(feedEntity.Key());

                if (foundEntity == null)
                    entities.Zorgprofielklasses.Add(feedEntity);
                // Note this does not take any update into consideration.

                var rowsAffected = entities.SaveChanges();

                return rowsAffected;
            };
        }
    }
}