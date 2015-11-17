using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ZXL.WeiXinWeb.Areas.WeiXin.Filter;
namespace ZXL.WeiXinWeb.Areas.WeiXin.Controllers
{
    [WXAuthorize]
    public class ProcessorController : ApiController
    {
        //
        // GET: /Controllers/Processor/

        public HttpResponseMessage Get()
        {
            var requestQueryPairs = Request.GetQueryNameValuePairs().ToDictionary(k => k.Key, v => v.Value);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(requestQueryPairs["echostr"]),
            };
        }

    }
}
