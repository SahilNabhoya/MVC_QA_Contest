//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_QA_Contest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Result
    {
        public int test_id { get; set; }
        public Nullable<int> skipped { get; set; }
        public Nullable<int> Total { get; set; }
        public Nullable<int> totalQuestion { get; set; }
        public int id { get; set; }
    
        public virtual testTable testTable { get; set; }
    }
}
