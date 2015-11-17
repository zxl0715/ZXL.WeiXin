using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Linq;
using System.Web.Http.Controllers;
using ZXL.Common;

namespace ZXL.WeiXinWeb.Areas.WeiXin.Filter
{
    public class WXAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 签名Key
        /// </summary>
        private string _wxToken = ConfigurationManager.AppSettings["WXToken"];

        /// <summary>
        /// 是否通过授权
        /// </summary>
        /// <param name="actionContext">上下文</param>
        /// <returns>是否成功</returns>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var requestQueryPairs = actionContext.Request.GetQueryNameValuePairs().ToDictionary(k => k.Key, v => v.Value);
            if (requestQueryPairs.Count == 0
                || !requestQueryPairs.ContainsKey("timestamp")
                || !requestQueryPairs.ContainsKey("signature")
                || !requestQueryPairs.ContainsKey("nonce"))
            {
                return false;
            }

            string[] waitEncryptParamsArray = new[] { _wxToken, requestQueryPairs["timestamp"], requestQueryPairs["nonce"] };

            string waitEncryptParamStr = string.Join("", waitEncryptParamsArray.OrderBy(m => m));

            string encryptStr = HashAlgorithm.SHA1(waitEncryptParamStr);

            return encryptStr.ToLower().Equals(requestQueryPairs["signature"].ToLower());
        }

        /// <summary>
        /// 处理未授权请求
        /// </summary>
        /// <param name="actionContext">上下文</param>
        protected sealed override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(
                HttpStatusCode.Unauthorized, new { status = "sign_error" });
        }
    }
}