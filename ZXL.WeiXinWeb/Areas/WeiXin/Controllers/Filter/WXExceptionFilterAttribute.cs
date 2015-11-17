using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;
using System.Xml;
using ZXL.Common;
using ZXL.Core.WeiXin;
using ZXL.Core.WeiXin.Msg;

namespace ZXL.WeiXinWeb.Areas.WeiXin.Controllers.Filter
{
    public class WXExceptionFilterAttribute : ExceptionFilterAttribute
    {
       
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        { 
           LogHelper.WriteErrorLog("",actionExecutedContext.Exception);

            var requestContent = actionExecutedContext.Request.Content.ReadAsStreamAsync().Result;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(requestContent);

            string userName = xmlDoc.SelectSingleNode("xml/FromUserName").InnerText;
            string efhName = xmlDoc.SelectSingleNode("xml/ToUserName").InnerText;
            var responseContent = MsgService.Instance.ResponseXML(new TextMsg
            {
                FromUserName = efhName,
                MsgType = MsgType.Text,
                Content = "咦，俺有点晕，先休息会。",
                CreateTime = UnixTimestamp.Now.ToNumeric(),
                ToUserName = userName
            }, typeof(TextMsg));

            actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseContent, Encoding.UTF8, "application/xml"),
            };
        }
    }
}