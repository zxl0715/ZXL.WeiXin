using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using ZXL.BLL;
using ZXL.DAL;
using ZXL.IBLL;
using ZXL.IDAL;

namespace ZXL.Core
{
    public class DependencyRegisterType
    {
        //系统注入
        public static void Container_Sys(ref UnityContainer container)
        {
            container.RegisterType<ISysSampleBLL, SysSampleBLL>();//样例
            container.RegisterType<ISysSampleRepository, SysSampleRepository>();
        }
    }
}
