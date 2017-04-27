﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYL.Web.Models
{
    public class RouteItem
    {
        public string PageTitle { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Url { get; set; }
    }
}