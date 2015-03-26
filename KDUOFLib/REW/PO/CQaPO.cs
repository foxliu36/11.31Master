using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.REW.PO
{
    public class CQaPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        REWDataSetTableAdapters.TableAdapterManager _myTAM;
        public CQaPO()
        {
            _myTAM = new REWDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = REWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_REW_QATableAdapter = new REWDataSetTableAdapters.TB_REW_QATableAdapter();
            _myTAM.TB_REW_QATableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }
        public void Update(REWDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }
        public void QueryQAByAdmin(DataTable dt, string smid, string closemonth, string status)
        {
            //string cmdTxt = @"select q.*,u.ACCOUNT,u.NAME";
            //cmdTxt += @" from TB_REW_QA q";
            //cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = q.CREATOR";
            //cmdTxt += @" where 1=1";
            //if (!"".Equals(closemonth))
            //{
            //    cmdTxt += @" and q.CLOSEMONTH = '" + closemonth + "'";
            //}
            //if (!"".Equals(smid))
            //{
            //    cmdTxt += @" and u.ACCOUNT  = '" + smid + "'";
            //}
            //if (!"".Equals(status))
            //{
            //    cmdTxt += @" and q.STATUS  = '" + status + "'";
            //}
            //dt.Load(this.m_db.ExecuteReader(cmdTxt));

            string cmdTxt = @"select *";
            cmdTxt += @" from TB_REW_QA";
            cmdTxt += @" where 1=1";
            if (!"".Equals(closemonth))
            {
                cmdTxt += @" and CLOSEMONTH = '" + closemonth + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += @" and CREATOR  = '" + smid + "'";
            }
            if (!"".Equals(status))
            {
                cmdTxt += @" and STATUS  = '" + status + "'";
            }
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        ///未完成，請補SQL
        public void QueryQABySmid(DataTable dt, string smid, string closemonth, string status)
        {
            string cmdTxt = @"select *";
            cmdTxt += @" from TB_REW_QA";
            cmdTxt += @" where 1=1";
            if (!"".Equals(smid))
            {
                cmdTxt += @" and CREATOR = '" + smid + "'";
            }
            if (!"".Equals(closemonth))
            {
                cmdTxt += @" and CLOSEMONTH = '" + closemonth + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += @" and CREATOR  = '" + smid + "'";
            }
            if (!"".Equals(status))
            {
                cmdTxt += @" and STATUS  = '" + status + "'";
            }
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
    }
}
