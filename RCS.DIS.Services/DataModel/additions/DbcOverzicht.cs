namespace RCS.DIS.Services.DataModel
{
    public partial class DbcOverzicht : IEntity
    {
        public object[] Key()
        {
            // Note order is significant.
            return new object[]
            {
                Jaar,
                SpecialismeCode,
                DiagnoseCode,
                ZorgproductCode,
                Versie
            };
        }

        public static int CreateOrUpdate(DbcOverzicht feedEntity)
        {
            using (var entities = new Entities())
            {
                var foundEntity = entities.DbcOverzichts.Find(feedEntity.Key());

                if (foundEntity == null)
                    entities.DbcOverzichts.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    entities.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = entities.SaveChanges();

                return rowsAffected;
            };
        }
    }
}