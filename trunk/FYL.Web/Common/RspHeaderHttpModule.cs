﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYL.Web.Common
{
    public class RspHeaderHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += OnPreSendRspHeaders;
        }

        public void Dispose()
        {

        }

        /// <summary>
        /// 移除指定header信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPreSendRspHeaders(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Remove("Server");
        }
    }
}