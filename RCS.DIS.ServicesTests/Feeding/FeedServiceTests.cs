using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCS.DIS.Services.DataModel;
using System;

namespace RCS.DIS.Services.Feeding.Tests
{
    // HACK to to do initial test. It is depending on a data connection and changes the database.
    // Note that app.config is a renamed COPY of web.config, DataModel.edmx is a REFERENCE into the tested project, and that EF had to be referenced too.

    [TestClass()]
    public class FeedServiceTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            var feedService = new FeedService();
            var zorgproduct = Zorgproduct1();
            int rowsAffected = 0;

            // Assure object not present.
            rowsAffected = Zorgproduct.Delete(zorgproduct.Key());

            // Should create.
            rowsAffected = feedService.ZorgproductCreateOrUpdate(zorgproduct);

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var feedService = new FeedService();
            var zorgproduct = Zorgproduct1();
            int rowsAffected = 0;

            // Assure object is present.
            rowsAffected = feedService.ZorgproductCreateOrUpdate(zorgproduct);

            // Give newer date.
            zorgproduct.Peildatum = zorgproduct.Peildatum.AddDays(1);

            // Should update.
            rowsAffected = feedService.ZorgproductCreateOrUpdate(zorgproduct);

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var feedService = new FeedService();
            var zorgproduct = Zorgproduct1();
            int rowsAffected = 0;

            // Assure object is present.
            rowsAffected = feedService.ZorgproductCreateOrUpdate(zorgproduct);

            // Should delete.
            rowsAffected = Zorgproduct.Delete(zorgproduct.Key());

            Assert.AreEqual(1, rowsAffected);
        }

        private static Zorgproduct Zorgproduct1()
        {
            return new Zorgproduct()
            {
                ZorgproductCode = 979001089,
                OmschrijvingLatijn = "Percutane coronaire interventie klasse 3 | Met VPLD | Hartoperatie/hart-/longtransplantatie",
                OmschrijvingConsument = "Dotterbehandeling (Met verpleegligdagen) bij / via een hartoperatie of hart-/longtransplantatie",
                DeclaratiecodeVerzekerd = "14B269",
                DeclaratiecodeOnverzekerd = "16B269",
                Peildatum = new DateTime(2018, 1, 1),
                Bestandsdatum = new DateTime(2018, 1, 15),
                Versie = "Test 1.0"
            };
        }
    }
}