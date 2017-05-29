using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ETS2_Invoice.Classes.Database;
using Newtonsoft.Json;

namespace ETS2_Invoice.Classes
{
    class Http
    {
        //private static readonly HttpClient Client = new HttpClient();

        public static string Send(string url, NameValueCollection values)
        {
            using (var wb = new WebClientEx())
            {
                wb.Timeout = 4000;
                var response = wb.UploadValues(url, "POST", values);
                return System.Text.Encoding.Default.GetString(response);
            }
        }
    }
}
