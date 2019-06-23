using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InteractiveUsers.Models
{
    public class ViewModel
    {
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "Text")]
        public string Text { get; set; }
    }
}