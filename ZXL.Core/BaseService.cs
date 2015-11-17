using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZXL.Common;

namespace ZXL.Core
{
    public class BaseService<T> where T : class, new()
    {


        private static object sysncObject = new object();

        private static T service = default(T);

        public static T Instance
        {
            get
            {
                if (service == null)
                {
                    lock (sysncObject)
                    {
                        if (service == null)
                        {

                           // LogHelper.WriteLog(typeof(T).ToString());
                            service = new T();
                        }
                    }
                }
                return service;
            }
        }

        protected ResultInfo DoAction(string bussinessName, Action action)
        {
            ResultInfo result = new ResultInfo();
            try
            {
                action();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog("", ex);
                throw;
            }
            return result;
        }

        protected ResultInfo<TOut> DoAction<TOut>(string bussinessName, Func<TOut> action)
        {
            ResultInfo<TOut> result = new ResultInfo<TOut>();
            try
            {
                result.Data = action();
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog("", ex);
                throw;
            }
            return result;
        }
    }
}
