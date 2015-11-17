using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ZXL.Core.WeiXin
{
    public class MsgService : BaseService<MsgService>
    {
        /// <summary>
        /// 被动响应消息(返回XML)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string ResponseXML(object value, Type type)
        {
            StringWriter sw = new StringWriter();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

            ns.Add("", "");　　//去除前缀和命名空间第一个参数是前缀，第二个参数是命名空间
            XmlSerializer serializer = new XmlSerializer(type);

            serializer.Serialize(sw, value, ns);

            return sw.ToString();
        }
    }
}
