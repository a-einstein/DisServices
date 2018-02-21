namespace RCS.DIS.Services.DataModel
{
    public partial class Zorgprofielklasse : IEntity
    {
        #region Feed
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
            using (var dbContext = new Entities())
            {
                var foundEntity = dbContext.Zorgprofielklasses.Find(feedEntity.Key());

                if (foundEntity == null)
                    dbContext.Zorgprofielklasses.Add(feedEntity);
                // Note this does not take any update into consideration.

                var rowsAffected = dbContext.SaveChanges();

                return rowsAffected;
            };
        }
        #endregion
    }
}