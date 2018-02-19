using System;
using System.Runtime.Serialization;

namespace RCS.DIS.Services.DTOs
{
    [DataContract]
    public partial class Diagnose
    {
        [DataMember]
        public string DiagnoseCode { get; set; }

        [DataMember]
        public string SpecialismeCode { get; set; }

        [DataMember]
        public string Omschrijving { get; set; }

        [DataMember]
        public System.DateTime Peildatum { get; set; }

        [DataMember]
        public Nullable<System.DateTime> Bestandsdatum { get; set; }

        [DataMember]
        public string Versie { get; set; }
    }
}