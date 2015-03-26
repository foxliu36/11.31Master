using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.HR.PO
{
    public class CTB_HR_PERTPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        HRDataSetTableAdapters.TableAdapterManager _myTAM;

        public CTB_HR_PERTPO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_HR_PERTTableAdapter = new HRDataSetTableAdapters.TB_HR_PERTTableAdapter();
            _myTAM.TB_HR_PERTTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }
        public void Delete(string GUID)
        {
            string cmdTxt = @"delete from TB_HR_PERT where GUID='" + GUID + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public DataTable getDatsBySMID(DataTable p_dt, string p_SMID,string p_ASSESS_TYPE,string p_YEAR)
        {
            string cmdTxt = @"select * from TB_HR_PERT where SMID='" + p_SMID + "' and ASSESS_TYPE= '" + p_ASSESS_TYPE + "'";
            cmdTxt += @" and YEAR='" + p_YEAR + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public DataTable getDatsByID(DataTable p_dt, string p_siteCode, string TASK_ID)
        {
            string cmdTxt = @"select * from TB_HR_PERT where TASK_ID='" + TASK_ID + "' and SITE_CODE = '" + p_siteCode + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public void UpdatebyGUID(DataRow row)
        {
            string cmdTxt = @"update TB_HR_PERT set RANK='" + row["RANK"].ToString() + "', RANK_Y='" + row["RANK_Y"].ToString() + "', SIGNER='" + row["SIGNER"].ToString() + "'";
            cmdTxt += @" where GUID='" + row["GUID"].ToString() + "'";
            cmdTxt += @" and ASSESS_TYPE='" + row["ASSESS_TYPE"].ToString() + "'";
            cmdTxt += @" and SMID='" + row["SMID"].ToString() + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public void Update(HRDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public DataTable check(DataTable p_dt, string p_SMID, string p_type, string p_year)
        {
            string cmdTxt = @" select * from TB_HR_PERT";
            cmdTxt += @" where SMID='" + p_SMID + "'";
            cmdTxt += @" and ASSESS_TYPE='" + p_type + "'";
            cmdTxt += @" and YEAR='" + p_year + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public DataTable Query(DataTable p_dt, string Bdate, string Edate, string p_smid, string p_GruopID,string p_GUID,string p_type)
        {
            string cmdTxt = @" select p.task_id,p.GUID,p.ASSESS_TYPE,g.GROUP_NAME,p.SMID,u.NAME,p.RANK,p.RANK_Y,p.EDIT_DATE,p.SMID+'@'+ p.ASSESS_TYPE+'@'+p.YEAR as keyword";
            cmdTxt += @" from dbo.TB_HR_PERT p";
            cmdTxt += @" left join TB_EB_USER u on u.ACCOUNT=p.SMID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
            cmdTxt += @" where p.EDIT_DATE between '" + Bdate + "' and '" + Edate + "'";
            if (!String.IsNullOrEmpty(p_type))
            {
                cmdTxt += @" and p.ASSESS_TYPE='" + p_type + "'";
            }
            if (!String.IsNullOrEmpty(p_smid))
            {
                cmdTxt += @" and p.SMID='" + p_smid + "'";
            }
            if (!String.IsNullOrEmpty(p_GruopID))
            {
                cmdTxt += @" and g.GROUP_ID in(" + p_GruopID.Substring(0, p_GruopID.Length - 1) + ")";
            }
            if (!String.IsNullOrEmpty(p_GUID))
            {
                cmdTxt += @" and p.GUID='" + p_GUID + "'";
            }

            cmdTxt += @" and e.ORDERS = 0";
            cmdTxt += @" order by GROUP_NAME";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }
    }
}
