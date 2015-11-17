using System;
using System.Collections.Generic;
using System.Text;

namespace ZXL.Common
{

    public class LogHelper
    {
        /* //rootFile
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void WriteInfo(string strInfo)
        {
            if (log.IsInfoEnabled)
            {
                log.Info(strInfo);
            }
        }

        public static void WriterDebugInfo(string strInfo)
        {
            if (log.IsInfoEnabled)
            {
                log.Debug(strInfo);
            }
        }
        */
        private static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");

        private static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");

        public static void WriteLog(string info)
        {

            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        public static void WriteErrorLog(string info, Exception se)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, se);
            
            }
        }

    }
}
