using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZXL.WeiXin.Controllers
{
    public class Default2Controller : ApiController
    {
        // GET api/default2
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/default2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/default2
        public void Post([FromBody]string value)
        {
        }

        // PUT api/default2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/default2/5
        public void Delete(int id)
        {
        }
    }
}
