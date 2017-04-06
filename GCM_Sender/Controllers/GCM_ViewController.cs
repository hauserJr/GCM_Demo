using GCM_Sender._DB.GetData;
using GCM_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCM_Sender.Controllers
{
    public class GCM_ViewController : Controller
    {

        GetDBFunction GetDB = new GetDBFunction();
        gcmModels _ShowViewModels = new gcmModels();
        // GET: GCM_View
        public ActionResult UserPage()
        {
            _ShowViewModels.UserInfoSelectItem = GetDB.getUserInfo();
            return View(_ShowViewModels);
        }

        [HttpPost]
        public ActionResult ToDoSender(string gcm_user,string gcm_message)
        {
            var returnData = new { IsSuccess = false, Message = "" };
            if (true)
            {//傳送成功
                returnData = new
                {
                    IsSuccess = true,
                    Message = string.Format("已將訊息 {0} 傳送給使用者 {1}", gcm_message, GetDB.getUserName(gcm_user))
                };
            }
            else
            {//傳送失敗
                returnData = new
                {
                    IsSuccess = false,
                    Message = string.Format("無法傳送訊息給 {0}", GetDB.getUserName(gcm_user))
                };
            }
            return Json(returnData);
        }
    }
}