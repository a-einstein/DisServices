namespace RCS.DIS.Services.DataModel
{
    public partial class DbcProfiel : IEntity
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
                ZorgactiviteitCode,
                Versie
            };
        }

        public static int CreateOrUpdate(DbcProfiel feedEntity)
        {
            using (var entities = new Entities())
            {
                var foundEntity = entities.DbcProfiels.Find(feedEntity.Key());

                if (foundEntity == null)
                    entities.DbcProfiels.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    entities.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = entities.SaveChanges();

                return rowsAffected;
            };
        }
    }
}