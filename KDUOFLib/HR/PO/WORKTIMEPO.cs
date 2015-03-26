using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.HR.PO
{
    public class WORKTIMEPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        HRDataSetTableAdapters.TableAdapterManager _myTAM;
        public WORKTIMEPO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_HR_WORKTIMETableAdapter = new HRDataSetTableAdapters.TB_HR_WORKTIMETableAdapter();
            _myTAM.TB_HR_WORKTIMETableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }
        public void Update(HRDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public void QueryParentGroupIDBySmid(DataTable dt, string smid)
        {
            string cmdTxt = @"select u.*, g.GROUP_NAME, g.GROUP_ID, g.PARENT_GROUP_ID ";
            cmdTxt += @"from TB_EB_USER u ";
            cmdTxt += @"inner join TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID ";
            cmdTxt += @"inner join TB_EB_GROUP g on d.GROUP_ID = g.GROUP_ID ";
            cmdTxt += @"where 1=1 ";
            cmdTxt += @"and  u.USER_GUID ='" + smid + @"' ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryBySmid(DataTable dt, string smid)
        {
            string cmdTxt = @"select * from TB_HR_WORKTIME where ACCOUNT ='" + smid + @"' ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void getDatasByAccountReport(DataTable dt, string creatBdate, string creatEdate, string brandid, string smid)
        {
            string cmdTxt = @"select r.GUID,g.GROUP_NAME,r.NAME,r.ACCOUNT,r.YEAR,r.MONTH,r.DAY,r.TIME_GO_TO_WORK,r.TIME_OFF_WORK,r.OPPS1,r.OPPS2,r.OPPS3,r.OPPS4,r.R_TIME_GO_TO_WORK,r.R_TIME_OFF_WORK,r.INSTER_TIME from TB_HR_WORKTIME r";
            cmdTxt += @" inner join TB_EB_USER u on r.ACCOUNT = u.ACCOUNT";
            cmdTxt += @" inner join TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on d.GROUP_ID = g.GROUP_ID";
            cmdTxt += @" where 1=1";
            if (!"".Equals(creatBdate) || !"".Equals(creatEdate))
            {
                //string BY = creatBdate.Substring(0, 4);
                //string BM = creatBdate.Substring(5, 2);
                //string BD = creatBdate.Substring(8, 2);
                //string EY = creatEdate.Substring(0, 4);
                //string EM = creatEdate.Substring(5, 2);
                //string ED = creatEdate.Substring(8, 2);
                //cmdTxt += @" and r.YEAR BETWEEN " + BY + " AND " + EY + "";
                //cmdTxt += @" and r.MONTH BETWEEN " + BM + " AND " + EM + "";
                //cmdTxt += @" and r.DAY BETWEEN " + BD + " AND " + ED + "";

                string NEWcreatBdate = creatBdate.Substring(0, 4) + creatBdate.Substring(5, 2) + creatBdate.Substring(8, 2);
                string NEWcreatEdate = creatEdate.Substring(0, 4) + creatEdate.Substring(5, 2) + creatEdate.Substring(8, 2);
                cmdTxt += @" and r.YMD BETWEEN '" + NEWcreatBdate + "' AND '" + NEWcreatEdate + "'";
            }
            if (!"".Equals(brandid))
            {
                cmdTxt += @" and (g.PARENT_GROUP_ID ='" + brandid + "'";
                cmdTxt += @" or  g.GROUP_ID ='" + brandid + "')";
                if (brandid == "d9f98002-38a6-f1ce-929b-270e7bdbdc50")
                {
                    cmdTxt += @" and g.GROUP_NAME !='F52民族營業所'";
                }



                //if (brandid == "9386ca5e-9826-448c-8b01-0f88460de097")
                //{
                //    cmdTxt += @" or g.GROUP_NAME ='F52民族營業所'";
                //}
            }
            if (!"".Equals(smid))
            {
                cmdTxt += @" and r.ACCOUNT ='" + smid + "'";

            }

            cmdTxt += @" order by g.GROUP_NAME,r.YMD,r.NAME";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void DelByUID(DataTable dt, string GUID)
        {
            string cmdTxt = @"Delete From TB_HR_WORKTIME Where GUID ='" + GUID + @"' ";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

    }
}
