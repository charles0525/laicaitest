using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FYL.Common;

namespace FYL.Web.Common
{
    public class LoadHistoryLottery
    {
        static readonly string configFile = System.Web.HttpContext.Current.Server.MapPath("~/ConfigFiles/Sd11x5.txt");

        static LoadHistoryLottery()
        {

        }

        public static string ReadFileContent()
        {
            string content = Utils.ReadFile(configFile);
            return content;
        }

        public static void SetContentToCache()
        {
            var content = ReadFileContent();
            CacheHelper.Insert(ConstValues.CacheKey_HistoryLottery, content, 60 * 24 * 356);
        }
    }
}