using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_QA_Contest.Custom_Model
{
    public class QuestionList
    {
        public int SelectedQuestionId { get; set; }
        public List<SelectListItem> Questions { get; set; }
    }
}