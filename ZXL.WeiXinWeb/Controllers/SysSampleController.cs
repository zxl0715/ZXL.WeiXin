﻿using System;
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


    }
}
