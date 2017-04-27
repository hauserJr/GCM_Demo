using GCM_Sender._DB.GetData;
using GCM_Sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GCM_Sender_Service;
using KeyValue.Models;

namespace GCM_Sender.Controllers
{
    public class GCM_ViewController : Controller
    {
        Sender _GCM_Sender_Service = new Sender();
        GetDBFunction GetDB = new GetDBFunction();
        gcmModels _ShowViewModels = new gcmModels();
        gcmKeyValue _gcmKeyValue = new gcmKeyValue();
        // GET: GCM_View
        public ActionResult UserPage()
        {
            _ShowViewModels.UserInfoSelectItem = GetDB.getUserInfo();
            return View(_ShowViewModels);
        }

        [HttpPost]
        public ActionResult ToDoSender(List<string> gcm_user,string gcm_message)
        {
            bool sender = _GCM_Sender_Service.SendMessage(_gcmKeyValue.API_Key, gcm_message, gcm_user);
            var returnData = new { IsSuccess = false, Message = "" };
            if (sender)
            {//傳送成功
                returnData = new
                {
                    IsSuccess = true,
                    Message = string.Format("已傳送給使用者")
                };
            }
            else
            {//傳送失敗
                returnData = new
                {
                    IsSuccess = false,
                    Message = string.Format("無法傳送訊息")
                };
            }
            return Json(returnData);
        }
    }
}