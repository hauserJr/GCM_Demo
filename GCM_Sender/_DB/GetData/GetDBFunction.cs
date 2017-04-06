using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GCM_Sender._DB;
using System.Web.Mvc;
using GCM_Sender.Models;

namespace GCM_Sender._DB.GetData
{

    public class GetDBFunction
    {
        gcmEntities _db = new gcmEntities();
        public List<SelectListItem> getUserInfo()
        {
            List<SelectListItem> UserInfo = new List<SelectListItem>();
            var query = _db.gcm.Select(o => new gcmModels
            {
                ytdt_name = o.YTDT_name,
                ytdt_redid = o.ytdt_redid,
            });
            if (query.Any())
            {
                foreach (var item in query)
                {
                    UserInfo.Add(new SelectListItem()
                    {
                        Text = item.ytdt_name,
                        Value = item.ytdt_redid
                    });
                }
            }
            else
            {
                UserInfo.Add(new SelectListItem()
                {
                    Text = "無任何註冊者",
                    Value = ""
                });
            }
            
            return UserInfo;
        }

        public string getUserName(string redid = null)
        {
            string query = _db.gcm.Where(o => o.ytdt_redid == redid)
                        .Select(o => o.YTDT_name).First();
            return query;
        }
    }

}