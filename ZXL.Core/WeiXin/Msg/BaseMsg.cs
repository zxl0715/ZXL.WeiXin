using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ZXL.Core.WeiXin.Msg
{
    public class BaseMsg
    {
        public string ToUserName { get; set; }

        public string FromUserName { get; set; }

        public long CreateTime { get; set; }

        public MsgType MsgType { get; set; }
    }

    public enum MsgType
    {
        [XmlEnum("event")]
        Event,
        [XmlEnum("text")]
        Text,

        //暂时只支持事件、文字和新闻
        [XmlEnum("image")]
        Image,
        [XmlEnum("voice")]
        Voice,
        [XmlEnum("video")]
        Video,
        [XmlEnum("music")]
        Music,
        [XmlEnum("news")]
        News
    }
}
