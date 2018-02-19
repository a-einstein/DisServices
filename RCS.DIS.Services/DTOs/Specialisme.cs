using System;

namespace RCS.DIS.Services.DTOs
{
    public partial class Specialisme
    {
        public string SpecialismeCode { get; set; }
        public string Omschrijving { get; set; }
        public System.DateTime Peildatum { get; set; }
        public Nullable<System.DateTime> Bestandsdatum { get; set; }
        public string Versie { get; set; }
    }
}