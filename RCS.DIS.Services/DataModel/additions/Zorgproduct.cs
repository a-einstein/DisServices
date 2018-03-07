using System;
using System.Diagnostics;
using System.Linq;

namespace RCS.DIS.Services.DataModel
{
    public partial class Zorgproduct : Entity
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
                ZorgproductCode,
                Versie
            };
        }

        // Would rather put this in interface, which is impossible.
        // TODO Consider some sort of factory class.
        public static int CreateOrUpdate(Zorgproduct feedEntity)
        {
            using (var dbContext = new Entities())
            {
                feedEntity.Clean();

                var foundEntity = dbContext.Zorgproducts.Find(feedEntity.Key());

                if (foundEntity == null)
                    dbContext.Zorgproducts.Add(feedEntity);
                else if (feedEntity.Peildatum > foundEntity.Peildatum)
                    dbContext.Entry(foundEntity).CurrentValues.SetValues(feedEntity);

                var rowsAffected = dbContext.SaveChanges();

                return rowsAffected;
            };
        }

        // Currently only for test purposes.
        public static int Delete(object[] key)
        {
            using (var dbContext = new Entities())
            {
                var foundEntity = dbContext.Zorgproducts.Find(key);

                if (foundEntity != null)
                    dbContext.Zorgproducts.Remove(foundEntity);

                var rowsAffected = dbContext.SaveChanges();

                return rowsAffected;
            };
        }

        public override void TraceException(Exception exception)
        {
            base.TraceException(exception);

            Trace.WriteLine($"Entity = {nameof(Zorgproduct)}");

            Trace.WriteLine($"ZorgproductCode = {ZorgproductCode}");
            Trace.WriteLine($"Versie = {Versie}");
        }
        #endregion

        #region Retrieve
        public static int OmschrijvingContainsNumber(string searchString)
        {
            using (var dbContext = new Entities())
            {
                var result = ContainsAllQuery(searchString, dbContext).Count();

                return result;
            };
        }

        public static Zorgproduct[] OmschrijvingContainsEntities(string searchString)
        {
            using (var dbContext = new Entities())
            {
                var result = ContainsAllQuery(searchString, dbContext).ToArray();

                return result;
            };
        }

        private static IQueryable<Zorgproduct> ContainsAllQuery(string searchString, Entities dbContext)
        {
            string[] searchSubstrings = SplitOnSpaceOrQuote(searchString);

            var query =
                from record in dbContext.Zorgproducts
                where searchSubstrings.All(subString =>
                    record.OmschrijvingConsument.Contains(subString) ||
                    record.OmschrijvingLatijn.Contains(subString))
                select record;

            return query;
        }
        #endregion
    }
}