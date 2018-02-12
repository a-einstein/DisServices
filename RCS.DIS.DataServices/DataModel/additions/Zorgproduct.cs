namespace RCS.DIS.DataServices.DataModel
{
    public partial class Zorgproduct
    {
        public object[] Key()
        {
            // Note order is significant.
            return new object[] { ZorgproductCode, Versie };
        }
    }
}