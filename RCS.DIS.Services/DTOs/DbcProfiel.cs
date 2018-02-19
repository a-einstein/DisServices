using System;

namespace RCS.DIS.Services.DTOs
{
    public partial class DbcProfiel
    {
        public short Jaar { get; set; }
        public string SpecialismeCode { get; set; }
        public string DiagnoseCode { get; set; }
        public int ZorgproductCode { get; set; }
        public int Patienten { get; set; }
        public int Subtrajecten { get; set; }
        public string ZorgactiviteitCode { get; set; }
        public int Zorgactiviteiten { get; set; }
        public System.DateTime Peildatum { get; set; }
        public Nullable<System.DateTime> Bestandsdatum { get; set; }
        public string Versie { get; set; }
    }
}