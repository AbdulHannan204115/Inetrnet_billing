//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cust_enrty.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class charges_info
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public charges_info()
        {
            this.allocates = new HashSet<allocate>();
        }
    
        public int fee_id { get; set; }
        public Nullable<int> charges { get; set; }
        public Nullable<int> discount { get; set; }
        public Nullable<int> total_charges { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<allocate> allocates { get; set; }
    }
}