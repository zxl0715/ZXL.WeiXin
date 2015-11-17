using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml;
using ZXL.Common;
using ZXL.Core.WeiXin;
using ZXL.Core.WeiXin.Msg;
using ZXL.WeiXinWeb.Areas.WeiXin.Filter;
namespace ZXL.WeiXinWeb.Areas.WeiXin.Controllers
{
   
    public class ProcessorController : ApiController
    {
        //
        // GET: /WeiXin/Processor
        /// <summary>
        /// 微信签名校验
        /// </summary>
        /// <returns></returns>
        [WXAuthorize]
        public HttpResponseMessage Get()
        {
            var requestQueryPairs = Request.GetQueryNameValuePairs().ToDictionary(k => k.Key, v => v.Value);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(requestQueryPairs["echostr"]),
            };
        }

        public HttpResponseMessage Post()
        {
            try
            {
                var requestContent = Request.Content.ReadAsStreamAsync().Result;
                //从正文参数中加载微信的请求参数
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(requestContent);

                // LogHelper.WriteLog(string.Format("WX请求XML内容:{0}", xmlDoc.InnerText));

                string msgTypeStr = xmlDoc.SelectSingleNode("xml/MsgType").InnerText;
                string userName = xmlDoc.SelectSingleNode("xml/FromUserName").InnerText;
                string efhName = xmlDoc.SelectSingleNode("xml/ToUserName").InnerText;

                string responseContent;
                MsgType msgType;

                //获取消息类型，若未定义，则返回。
                if (!Enum.TryParse(msgTypeStr, true, out msgType))
                {
                    responseContent = MsgService.Instance.ResponseXML(new TextMsg
                    {
                        FromUserName = efhName,
                        MsgType = MsgType.Text,
                        Content = "俺还小，不知道你在说啥子(⊙_⊙)?",
                        CreateTime = UnixTimestamp.Now.ToNumeric(),
                        ToUserName = userName
                    }, typeof(TextMsg));

                    return new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(responseContent, Encoding.UTF8, "application/xml"),
                    };
                }

                if (msgType == MsgType.Event)
                {
                    return ProcessEvent(xmlDoc, userName, efhName);
                }

                //图灵消息转换为微信响应消息，下一节奉上
                string content = xmlDoc.SelectSingleNode("xml/Content").InnerText;
                // var requestResult = TuLingService.Instance.GetMsgFromResponse(content, userName, efhName);

                var requestResult = MsgService.Instance.ResponseXML(new TextMsg
                {
                    FromUserName = efhName,
                    MsgType = MsgType.Text,
                    Content = "图灵消息转换为微信响应消息",//其实取消订阅是不会发送消息的
                    CreateTime = UnixTimestamp.Now.ToNumeric(),
                    ToUserName = userName
                }, typeof(TextMsg));


                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(requestResult, Encoding.UTF8, "application/xml"),
                };

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private HttpResponseMessage ProcessEvent(XmlDocument xmlDoc, string userName, string efhName)
        {
            string eventValue = xmlDoc.SelectSingleNode("xml/Event").InnerText;

            var responseContent = MsgService.Instance.ResponseXML(new TextMsg
            {
                FromUserName = efhName,
                MsgType = MsgType.Text,
                Content = eventValue.ToLower().Equals("subscribe") ? "lei好哇~" : "大爷，奴家会想你的",//其实取消订阅是不会发送消息的
                CreateTime = UnixTimestamp.Now.ToNumeric(),
                ToUserName = userName
            }, typeof(TextMsg));

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseContent, Encoding.UTF8, "application/xml"),
            };
        }
    }
}
