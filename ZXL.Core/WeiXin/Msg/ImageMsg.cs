using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ZXL.Core.WeiXin.Msg
{
    [XmlRoot("xml")]
    public class ImageMsg : BaseMsg
    {
        public MediaInfo Image { get; set; }
    }
}
