//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RCS.DIS.DataServices
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zorgactiviteit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zorgactiviteit()
        {
            this.DbcProfiels = new HashSet<DbcProfiel>();
        }
    
        public string ZorgactiviteitCode { get; set; }
        public string Omschrijving { get; set; }
        public short ZorgprofielklasseCode { get; set; }
        public System.DateTime Peildatum { get; set; }
        public Nullable<System.DateTime> Bestandsdatum { get; set; }
        public string Versie { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DbcProfiel> DbcProfiels { get; set; }
        public virtual Zorgprofielklasse Zorgprofielklasse { get; set; }
    }
}
