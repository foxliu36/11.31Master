using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

namespace KDUOFLib.PET.PO
{
    public class CTargetPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        PETDataSetTableAdapters.TableAdapterManager _myTAM;

        public CTargetPO()
        {
            _myTAM = new PETDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = PETDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_PET_TARGETTableAdapter = new PETDataSetTableAdapters.TB_PET_TARGETTableAdapter();
            _myTAM.TB_PET_TARGETTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
           
        }
        public void QueryDatas(DataTable dt)
        {
            string cmdTxt = @"select * from TB_PET_TARGET order by BRANCHID";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryTargetDatasByReport(DataTable dt)
        {
            string cmdTxt = @"select t.*,g.GROUP_NAME ";
            cmdTxt += @" from TB_PET_TARGET t";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID = t.BRANCHID";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryTargetDatasByReportForBranch(DataTable dt,string group_name)
        {
            string cmdTxt = @"select u.NAME,g.GROUP_ID";
            cmdTxt += @" from TB_EB_USER u";
            cmdTxt += @" inner join TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID";
            cmdTxt += @" inner join TB_EB_JOB_TITLE t on d.TITLE_ID = t.TITLE_ID";
            cmdTxt += @" inner join TB_EB_GROUP g on d.GROUP_ID = g.GROUP_ID";
            cmdTxt += @" where g.GROUP_NAME = '" + group_name + "'";
            cmdTxt += @" and TITLE_NAME = '所長'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryTargetDatasByReportForSec(DataTable dt, string group_name)
        {
            string cmdTxt = @"select u.NAME,g.GROUP_NAME";
            cmdTxt += @" from TB_EB_USER u";
            cmdTxt += @" inner join TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID";
            cmdTxt += @" inner join TB_EB_JOB_TITLE t on d.TITLE_ID = t.TITLE_ID";
            cmdTxt += @" inner join TB_EB_GROUP g on d.GROUP_ID = g.GROUP_ID";
            cmdTxt += @" where g.PARENT_GROUP_ID = '" + group_name + "'";
            cmdTxt += @" and TITLE_NAME = '課長'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        
//        public void InsertData(System.Data.DataRow row)
//        {
//                string cmdTxt = @"INSERT INTO TB_DEMO
//                            (ID,NAME) VALUES(@ID,@NAME)";

//                Utility.SetBasePersistentObjectParameters(this.m_db, row);
//                //this.m_db.AddParameter("@ID", id);
//                //this.m_db.AddParameter("@NAME", name);

//                this.m_db.ExecuteNonQuery(cmdTxt);
//        }

        public void Update(PETDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }
    }
}
