using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WebApp
{
    public sealed class HTTPClient : HttpClient
    {
        private HTTPClient() { }

        private static HTTPClient _Instance = new HTTPClient();

        public static HTTPClient Instance
        {
            get
            {
                if (_Instance.BaseAddress == null)
                {
                    _Instance.BaseAddress =
                        new Uri(HttpContext.Current.Request.Url.Scheme + "://"
                        + HttpContext.Current.Request.Url.Authority);
                }
                return _Instance;
            }
        }
    }
}