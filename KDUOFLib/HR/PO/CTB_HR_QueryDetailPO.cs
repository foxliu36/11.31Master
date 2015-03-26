using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.HR.PO
{
    class CTB_HR_QueryDetailPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        HRDataSetTableAdapters.TableAdapterManager _myTAM;

        public CTB_HR_QueryDetailPO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_HR_PERTTableAdapter = new HRDataSetTableAdapters.TB_HR_PERTTableAdapter();
            _myTAM.TB_HR_PERTTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }

        public DataTable QuerybyAssistanManager(DataTable p_dt, string p_smid, string p_type)
        {
            string cmdTxt = @" select p.*,g.GROUP_NAME,u.NAME";
            cmdTxt += @" from dbo.TB_HR_ASSESS_ASSISTAN_MANAGER p";
            cmdTxt += @" left join TB_EB_USER u on u.ACCOUNT=p.SMID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
            cmdTxt += @" where 1=1 ";
            cmdTxt += @" and e.ORDERS = 0";
            cmdTxt += @" and p.ASSESS_TYPE ='" + p_type + "'";
            cmdTxt += @" and p.SMID ='" + p_smid + "'";
            cmdTxt += @" order by g.GROUP_NAME";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public DataTable QuerybyCOMPTENT(DataTable p_dt, string p_smid)
        {
            string cmdTxt = @" select p.*,g.GROUP_NAME,u.NAME";
            cmdTxt += @" from dbo.TB_HR_ASSESS_COMPTENT_DETAIL p";
            cmdTxt += @" left join TB_EB_USER u on u.ACCOUNT=p.SMID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
            cmdTxt += @" where 1=1 ";
            cmdTxt += @" and e.ORDERS = 0";
            cmdTxt += @" and p.SMID ='" + p_smid + "'";
            cmdTxt += @" order by g.GROUP_NAME";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public DataTable QuerybyGENERAL(DataTable p_dt, string p_smid, string p_type)
        {
            string cmdTxt = @" select p.*,g.GROUP_NAME,u.NAME";
            cmdTxt += @" from dbo.TB_HR_ASSESS_GENERAL p";
            cmdTxt += @" left join TB_EB_USER u on u.ACCOUNT=p.SMID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
            cmdTxt += @" where 1=1 ";
            cmdTxt += @" and e.ORDERS = 0";
            cmdTxt += @" and p.ASSESS_TYPE ='" + p_type + "'";
            cmdTxt += @" and p.SMID ='" + p_smid + "'";
            cmdTxt += @" order by g.GROUP_NAME";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public DataTable QuerybySTAFF(DataTable p_dt, string p_smid, string p_type)
        {
            string cmdTxt = @" select p.*,g.GROUP_NAME,u.NAME";
            cmdTxt += @" from dbo.TB_HR_ASSESS_STAFF p";
            cmdTxt += @" left join TB_EB_USER u on u.ACCOUNT=p.SMID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
            cmdTxt += @" where 1=1 ";
            cmdTxt += @" and e.ORDERS = 0";
            cmdTxt += @" and p.ASSESS_TYPE ='" + p_type + "'";
            cmdTxt += @" and p.SMID ='" + p_smid + "'";
            cmdTxt += @" order by g.GROUP_NAME";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public DataTable QuerybySERVICE(DataTable p_dt, string p_smid, string p_type)
        {
            string cmdTxt = @" select *";
            cmdTxt += @" from dbo.TB_HR_ASSESS_SERVICE ";
            cmdTxt += @" where 1=1 ";
            cmdTxt += @" and ASSESS_TYPE ='" + p_type + "'";
            cmdTxt += @" and ACCOUNT ='" + p_smid + "'";
            cmdTxt += @" order by GROUP_NAME";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }


     
    }
}
