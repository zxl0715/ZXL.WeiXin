using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ZXL.Core.WeiXin.Msg
{
    [XmlRoot("xml")]
    public class VoiceMsg : BaseMsg
    {
        public MediaInfo Voice { get; set; }
    }
}
