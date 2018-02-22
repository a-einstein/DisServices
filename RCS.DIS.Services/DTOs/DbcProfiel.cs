using System;
using System.Runtime.Serialization;

namespace RCS.DIS.Services.DTOs
{
    [DataContract]
    public partial class DbcProfiel
    {
        [DataMember]
        public short Jaar { get; set; }

        [DataMember]
        public string SpecialismeCode { get; set; }

        [DataMember]
        public string DiagnoseCode { get; set; }

        [DataMember]
        public int ZorgproductCode { get; set; }

        [DataMember]
        public int Patienten { get; set; }

        [DataMember]
        public int Subtrajecten { get; set; }

        [DataMember]
        public string ZorgactiviteitCode { get; set; }

        [DataMember]
        public int Zorgactiviteiten { get; set; }

        [DataMember]
        public System.DateTime Peildatum { get; set; }

        [DataMember]
        public Nullable<System.DateTime> Bestandsdatum { get; set; }

        [DataMember]
        public string Versie { get; set; }
    }
}