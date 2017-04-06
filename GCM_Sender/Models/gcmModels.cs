using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCM_Sender.Models
{
    public class gcmModels
    {
        public string ytdt_redid { get; set; }
        public string ytdt_name { get; set; }
        public IEnumerable<SelectListItem> UserInfoSelectItem { get; set; }
    }
}