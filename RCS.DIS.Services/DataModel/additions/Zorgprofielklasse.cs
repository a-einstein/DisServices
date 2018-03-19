using System;
using System.Diagnostics;

namespace RCS.DIS.Services.DataModel
{
    public partial class Zorgprofielklasse : Entity
    {
        #region Feed
        public override void Clean()
        {
            // Trim because whitespace encountered.
            Versie = Versie.Trim();
        }

        public override object[] Key()
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
            using (var dbContext = new DisDbContext())
            {
                feedEntity.Clean();

                var foundEntity = dbContext.Zorgprofielklasses.Find(feedEntity.Key());

                if (foundEntity == null)
                    dbContext.Zorgprofielklasses.Add(feedEntity);
                // Note this does not take any update into consideration.

                var rowsAffected = dbContext.SaveChanges();

                return rowsAffected;
            };
        }

        public override void TraceException(Exception exception)
        {
            base.TraceException(exception);

            Trace.WriteLine($"Entity = {nameof(Zorgprofielklasse)}");

            Trace.WriteLine($"ZorgprofielklasseCode = {ZorgprofielklasseCode}");
            Trace.WriteLine($"Versie = {Versie}");
        }
        #endregion
    }
}