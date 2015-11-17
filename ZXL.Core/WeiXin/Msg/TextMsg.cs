using System.Xml.Serialization;

namespace ZXL.Core.WeiXin.Msg
{
    /// <summary>
    /// 文本消息
    /// </summary>
    [XmlRoot("xml")]
    public class TextMsg : BaseMsg
    {
        public string Content { get; set; }
    }
}
