using System;
using System.Runtime.Serialization;

namespace RCS.DIS.Services.DTOs
{
    [DataContract]
    public partial class DbcOverzicht
    {
        [DataMember]
        public short Jaar { get; set; }

        [DataMember]
        public string SpecialismeCode { get; set; }

        [DataMember]
        public int PatientenPerSpecialisme { get; set; }

        [DataMember]
        public int SubtrajectenPerSpecialisme { get; set; }

        [DataMember]
        public string DiagnoseCode { get; set; }

        [DataMember]
        public int PatientenPerDiagnose { get; set; }

        [DataMember]
        public int SubtrajectenPerDiagnose { get; set; }

        [DataMember]
        public int ZorgproductCode { get; set; }

        [DataMember]
        public int PatientenPerZorgproduct { get; set; }

        [DataMember]
        public int SubtrajectenPerZorgproduct { get; set; }

        [DataMember]
        public Nullable<decimal> Verkoopprijs { get; set; }

        [DataMember]
        public System.DateTime Peildatum { get; set; }

        [DataMember]
        public Nullable<System.DateTime> Bestandsdatum { get; set; }

        [DataMember]
        public string Versie { get; set; }
    }
}