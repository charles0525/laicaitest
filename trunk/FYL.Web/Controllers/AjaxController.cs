using FYL.Web.Common;
using FYL.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using FYL.Common;
using System.Text;

namespace FYL.Web.Controllers
{
    public class AjaxController : BaseController
    {
        [ActionName("100000")]
        [HttpPost]
        public JsonResult PostData(PostDataReq req)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { PropertyName = x.Key, ErrorMsg = x.Value.Errors[0].ErrorMessage }).ToList();
                return JsonHelper.ToObject(Entity.Enum.EnumRspStatus.Fail, value: errors).ToJsonResult();
            }
            if (!CheckSign(req))
            {
                return JsonHelper.ToObject(Entity.Enum.EnumRspStatus.Fail, errorMsg: "签名验证失败!").ToJsonResult();
            }

            return JsonHelper.ToObject(Entity.Enum.EnumRspStatus.Success, value: new { name = "测试", age = 10 }).ToJsonResult();
        }

        [ActionName("QueryInfo")]
        public JsonResult Query(QueryLotteryReq req)
        {
            double probability = 0, historyMaxFlawed = 10;//理论出现概率，历史最大披露
            int historyWinningCount = 10;//历史开奖中奖次数
            if (req.LotteryType == "Sd11x5")
            {
                //理论出现概率 待实现
                //CreateQueue();
                probability = 1 * 100 / (11 * 10 * 9 * 8 * 7);

                //历史开奖中的中奖次数
                historyWinningCount = GetHistoryWinningCount(req.LotteryCode);

                //历史最大遗漏  待实现
            }
            return JsonHelper.ToObject(Entity.Enum.EnumRspStatus.Success, value: new { probability, historyWinningCount, historyMaxFlawed }).ToJsonResult();
        }

        /// <summary>
        /// 创建号码所有组合 ,5一个一组
        /// </summary>
        private void CreateQueue()
        {
            //List<string> list = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11" };
            StringBuilder sb = new StringBuilder();
            int[] c = RandomNumbers(5, 1, 11);
            if (c.Length != 0)
            {
                for (int i = 0; i < c.Length; i++)
                {
                    sb.Append(c[i].ToString() + " ");
                }
            }
        }

        /// <summary>
        /// 随机数
        /// </summary>
        /// <param name="ACount">个数</param>
        /// <param name="AMinValue">最小值</param>
        /// <param name="AMaxValue">最大值</param>
        /// <returns></returns>
        private static int[] RandomNumbers(int ACount, int AMinValue, int AMaxValue)
        {
            if (ACount <= 0) return null;
            if (AMaxValue < AMinValue)
                AMinValue = AMaxValue | (AMaxValue = AMinValue) & 0;
            if (ACount > AMaxValue - AMinValue + 1) return null;
            List<int> vValues = new List<int>();
            for (int i = AMinValue; i <= AMaxValue; i++)
                vValues.Add(i);
            int[] Result = new int[ACount];
            Random vRandom = new Random();
            for (int i = 0; i < ACount; i++)
            {
                int j = vRandom.Next(vValues.Count);
                Result[i] = vValues[j];
                vValues.RemoveAt(j);
            }
            return Result;
        }

        /// <summary>
        /// 获取历史中奖次数
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static int GetHistoryWinningCount(string code)
        {
            var cacheData = CacheHelper.Get<string>(ConstValues.CacheKey_HistoryLottery);
            var strCode = $"[{code}]";
            var count = (cacheData.Length - cacheData.Replace(strCode, "").Length) / strCode.Length;
            return count;
        }

        /// <summary>
        /// 签名校验
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        private bool CheckSign(PostDataReq req)
        {
            var paramsList = new SortedList<string, string>();
            paramsList.Add(nameof(req.param1), req.param1);
            paramsList.Add(nameof(req.param2), req.param2);
            paramsList.Add(nameof(req.param3), req.param3);
            //paramsList.Add(nameof(req.sign), req.sign);

            string key = "00000000";//标识key
            var sign = Utils.CreatSign(paramsList, key);
            return req.sign.ToUpper().Equals(sign);
        }
    }
}