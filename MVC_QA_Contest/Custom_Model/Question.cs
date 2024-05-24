using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_QA_Contest.Models
{
    [MetadataType(typeof(QuestionMetadata))]
    public partial class Question
    {
        internal class QuestionMetadata
        {
            public int id { get; set; }

            [Required]
            public string question1 { get; set; }
            [Required]
            public string option_1 { get; set; }
            [Required]
            public string option_2 { get; set; }
            [Required]
            public string option_3 { get; set; }
            [Required]
            public string option_4 { get; set; }
            [Required]
            public int answer { get; set; }


        }
        [NotMapped]
        public int Uans {  get; set; }

    }
}