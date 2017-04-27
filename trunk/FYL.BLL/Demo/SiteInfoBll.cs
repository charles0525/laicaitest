﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FYL.Entity.DB;
using FYL.DAL;

namespace FYL.BLL
{
    public class SiteInfoBll
    {
        private SiteInfoDal dal = new SiteInfoDal();

        public SiteInfoEntity Get(int id = 0)
        {
            return dal.Get(id) ?? new SiteInfoEntity();
        }
    }
}
