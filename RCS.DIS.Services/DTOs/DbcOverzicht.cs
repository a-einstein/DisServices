using System;

namespace RCS.DIS.Services.DTOs
{
    public partial class DbcOverzicht
    {
        public short Jaar { get; set; }
        public string SpecialismeCode { get; set; }
        public int PatientenPerSpecialisme { get; set; }
        public int SubtrajectenPerSpecialisme { get; set; }
        public string DiagnoseCode { get; set; }
        public int PatientenPerDiagnose { get; set; }
        public int SubtrajectenPerDiagnose { get; set; }
        public int ZorgproductCode { get; set; }
        public int PatientenPerZorgproduct { get; set; }
        public int SubtrajectenPerZorgproduct { get; set; }
        public Nullable<decimal> Verkoopprijs { get; set; }
        public System.DateTime Peildatum { get; set; }
        public Nullable<System.DateTime> Bestandsdatum { get; set; }
        public string Versie { get; set; }
    }
}