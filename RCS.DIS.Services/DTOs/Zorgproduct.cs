using System;
using System.Runtime.Serialization;

namespace RCS.DIS.Services.DTOs
{
    [DataContract]
    public partial class Zorgproduct
    {
        [DataMember]
        public int ZorgproductCode { get; set; }

        [DataMember]
        public string OmschrijvingLatijn { get; set; }

        [DataMember]
        public string OmschrijvingConsument { get; set; }

        [DataMember]
        public string DeclaratiecodeVerzekerd { get; set; }

        [DataMember]
        public string DeclaratiecodeOnverzekerd { get; set; }

        [DataMember]
        public System.DateTime Peildatum { get; set; }

        [DataMember]
        public Nullable<System.DateTime> Bestandsdatum { get; set; }

        [DataMember]
        public string Versie { get; set; }
    }
}