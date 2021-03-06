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
    
    public partial class QuoteLineDefault
    {
        public int ID { get; set; }
        public int CatID { get; set; }
        public string OptionID { get; set; }
        public string OptionDescription { get; set; }
        public string UoM { get; set; }
        public int UnitsPerTrailer { get; set; }
        public Nullable<int> TareWeightOption { get; set; }
        public string DrawingNo { get; set; }
        public string PartNo { get; set; }
        public Nullable<double> Hours { get; set; }
        public Nullable<decimal> SellPrice { get; set; }
        public Nullable<decimal> CostMaterial { get; set; }
        public Nullable<int> SortOrder { get; set; }
        public string CommentQuoteLine { get; set; }
        public Nullable<bool> AllowDiscount { get; set; }
        public Nullable<int> QuoteHdrId { get; set; }
        public Nullable<int> CubicCapacityOption { get; set; }
    
        public virtual QuoteHdr QuoteHdr { get; set; }
    }
}
