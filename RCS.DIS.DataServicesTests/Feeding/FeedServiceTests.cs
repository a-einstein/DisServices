using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCS.DIS.DataServices.DataModel;
using System;

namespace RCS.DIS.DataServices.Feeding.Tests
{
    [TestClass()]
    public class FeedServiceTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            var zorgproduct = new Zorgproduct()
            {
                // TODO Note this is defined as short, and must have gone wrong somewhere. Correct.
                ZorgproductCode= 1,

                OmschrijvingLatijn= "Percutane coronaire interventie klasse 3 | Met VPLD | Hartoperatie/hart-/longtransplantatie",
                OmschrijvingConsument= "Dotterbehandeling (Met verpleegligdagen) bij / via een hartoperatie of hart-/longtransplantatie",
                DeclaratiecodeVerzekerd= "14B269",
                DeclaratiecodeOnverzekerd= "16B269",
                Peildatum=new DateTime(2018,1,1),
                Bestandsdatum = new DateTime(2018, 1, 15),
                Versie= "1.0"
            };

            var service = new FeedService();

            // HACK to to do initial test. It is depending on a data connection and changes the database.
            // Note that app.config and DataModel.edmx are REFERENCES into the tested project, and that EF had to be referenced too.
            // Note that currently the created record has to be deleted before this test.
            var rowsAffected = service.Insert(zorgproduct);

            Assert.AreEqual(1, rowsAffected);
        }
    }
}