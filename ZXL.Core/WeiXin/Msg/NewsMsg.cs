using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ZXL.Core.WeiXin.Msg
{
    /// <summary>
    /// 图文消息
    /// </summary>
    [XmlRoot("xml")]
    public class NewsMsg : BaseMsg
    {
        public int ArticleCount { get; set; }

        [XmlArray("Articles")]
        [XmlArrayItem("item")]
        public List<NewsInfo> Articles { get; set; }
    }


    public class NewsInfo
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string PicUrl { get; set; }

        public string Url { get; set; }
    }
}
