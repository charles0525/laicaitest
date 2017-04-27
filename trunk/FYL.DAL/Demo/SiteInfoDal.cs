﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FYL.Entity.DB;
using FYL.DAL.Extend;

namespace FYL.DAL
{
    public class SiteInfoDal : BaseDal
    {
        public SiteInfoEntity Get(int id)
        {
            string strSql = string.Empty;
            if (id > 0)
            {
                strSql = "select ID,SiteName from SiteInfo where ID=@id";
            }
            else
            {
                strSql = "select top 1 ID,SiteName from SiteInfo";
            }

            var data = this.TestDb.GetOne<SiteInfoEntity>(strSql, new { id });
            return data;
        }
    }
}
