using System.Linq;

namespace RCS.DIS.Services.DataModel
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

        // Arbitrarily collect the Versies here, being the largest table.
        public static string[] Versies()
        {
            using (var dbContext = new Entities())
            {
                // TODO Check efficiency.
                var entities = dbContext.Zorgprofielklasses.Select(entity => entity.Versie).Distinct().ToArray();

                return entities;
            };
        }
    }
}