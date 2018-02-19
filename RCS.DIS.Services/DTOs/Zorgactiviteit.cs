using System;

namespace RCS.DIS.Services.DTOs
{
    public partial class Zorgactiviteit
    {
        public string ZorgactiviteitCode { get; set; }
        public string Omschrijving { get; set; }
        public int ZorgprofielklasseCode { get; set; }
        public System.DateTime Peildatum { get; set; }
        public Nullable<System.DateTime> Bestandsdatum { get; set; }
        public string Versie { get; set; }
    }
}