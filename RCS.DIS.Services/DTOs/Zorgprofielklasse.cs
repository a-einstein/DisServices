using System.Runtime.Serialization;

namespace RCS.DIS.Services.DTOs
{
    [DataContract]
    public partial class Zorgprofielklasse
    {
        [DataMember]
        public int ZorgprofielklasseCode { get; set; }

        [DataMember]
        public string Omschrijving { get; set; }

        [DataMember]
        public string Versie { get; set; }
    }
}