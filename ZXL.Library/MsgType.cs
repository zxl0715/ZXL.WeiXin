using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ZXL.Library
{
   public enum MsgType
    {
       [XmlEnum("event")]
       Event,
       [XmlEnum("text")]
       Text,
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
