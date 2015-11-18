using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using ZXL.IBLL;
using ZXL.Models.Sys;

namespace ZXL.WeiXinWeb.Controllers
{
    public class SysSampleController : Controller
    {
        //
        // GET: /SysSample/
        /// <summary>
        /// 业务层注入
        /// </summary>
        [Dependency]
        public ISysSampleBLL m_BLL { get; set; }
        public ActionResult Index()
        {
            List<SysSampleModel> list = m_BLL.GetList("");
            return View(list);
        }
 
        public JsonResult GetList()
        {
            List<SysSampleModel> list = m_BLL.GetList("");
            var json = new
            {
                total = list.Count,
                rows = (from r in list
                        select new SysSampleModel()
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Age = r.Age,
                            Bir = r.Bir,
                            Note = r.Note,
                            Photo = r.Photo,
                            CreateTime = r.CreateTime
                        })
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}
