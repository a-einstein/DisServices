//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RCS.DIS.DataService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zorgproduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zorgproduct()
        {
            this.DbcOverzichts = new HashSet<DbcOverzicht>();
            this.DbcProfiels = new HashSet<DbcProfiel>();
        }
    
        public short ZorgproductCode { get; set; }
        public string OmschrijvingLatijn { get; set; }
        public string OmschrijvingConsument { get; set; }
        public string DeclaratiecodeVerzekerd { get; set; }
        public string DeclaratiecodeOnverzekerd { get; set; }
        public System.DateTime Peildatum { get; set; }
        public Nullable<System.DateTime> Bestandsdatum { get; set; }
        public string Versie { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DbcOverzicht> DbcOverzichts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DbcProfiel> DbcProfiels { get; set; }
    }
}
