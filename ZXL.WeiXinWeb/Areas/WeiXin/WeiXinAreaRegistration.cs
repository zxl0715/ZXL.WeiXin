using System.Web.Http;
using System.Web.Mvc;
namespace ZXL.WeiXinWeb.Areas.WeiXin
{
    public class WeiXinAreaRegistration: AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "WeiXin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.Routes.MapHttpRoute(
                "WeiXinProcessor",
                "WeiXin/{controller}",
                new { controller = "Processor" }
            );
        }
    }
}