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
    
    public partial class Test
    {
        public int test_id { get; set; }
        public int question_id { get; set; }
        public Nullable<int> answer { get; set; }
        public string id { get; set; }
    
        public virtual Question Question { get; set; }
        public virtual testTable testTable { get; set; }
    }
}
