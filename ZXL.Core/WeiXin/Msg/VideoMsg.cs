using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ZXL.Core.WeiXin.Msg
{
    [XmlRoot("xml")]
    public class VideoMsg : BaseMsg
    {
        public string MediaId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
