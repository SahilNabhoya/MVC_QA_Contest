using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_QA_Contest.Models
{
    [MetadataType(typeof(TestMetadata))]
    public partial class testTable
    {
        internal class TestMetadata
        {
            [Required(ErrorMessage ="Test name is required")]
            public string test_name { get; set; }
        }
    }
}