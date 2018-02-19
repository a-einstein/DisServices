using System;

namespace RCS.DIS.Services.DTOs
{
    public partial class Zorgproduct
    {
        public int ZorgproductCode { get; set; }
        public string OmschrijvingLatijn { get; set; }
        public string OmschrijvingConsument { get; set; }
        public string DeclaratiecodeVerzekerd { get; set; }
        public string DeclaratiecodeOnverzekerd { get; set; }
        public System.DateTime Peildatum { get; set; }
        public Nullable<System.DateTime> Bestandsdatum { get; set; }
        public string Versie { get; set; }
    }
}