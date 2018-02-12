using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCS.DIS.DataServices.DataModel;
using System;

namespace RCS.DIS.DataServices.Feeding.Tests
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
            rowsAffected = feedService.Delete(zorgproduct.Key());

            // Should create.
            rowsAffected = feedService.CreateOrUpdate(zorgproduct);

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            var feedService = new FeedService();
            var zorgproduct = Zorgproduct1();
            int rowsAffected = 0;

            // Assure object is present.
            rowsAffected = feedService.CreateOrUpdate(zorgproduct);

            // Give newer date.
            zorgproduct.Peildatum = zorgproduct.Peildatum.AddDays(1);

            // Should update.
            rowsAffected = feedService.CreateOrUpdate(zorgproduct);

            Assert.AreEqual(1, rowsAffected);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var feedService = new FeedService();
            var zorgproduct = Zorgproduct1();
            int rowsAffected = 0;

            // Assure object is present.
            rowsAffected = feedService.CreateOrUpdate(zorgproduct);

            // Should delete.
            rowsAffected = feedService.Delete(zorgproduct.Key());

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
                Versie = "1.0"
            };
        }
    }
}