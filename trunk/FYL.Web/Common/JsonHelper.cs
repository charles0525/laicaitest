using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FYL.Entity.Enum;

namespace FYL.Web.Common
{
    public class JsonHelper
    {
        public static object ToObject(EnumRspStatus result, string errorMsg = "", object value = null)
        {
            return new { result = result.GetHashCode(), errorMsg, value };
        }
    }
}
