//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeliveryTerm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeliveryTerm()
        {
            this.QuoteHdrs = new HashSet<QuoteHdr>();
        }
    
        public int Id { get; set; }
        public string DeliveryTerm1 { get; set; }
        public bool Active { get; set; }
        public Nullable<int> SortOrder { get; set; }
        public string Comment { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuoteHdr> QuoteHdrs { get; set; }
    }
}
