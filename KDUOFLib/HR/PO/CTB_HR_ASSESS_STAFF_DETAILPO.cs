using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.HR.PO
{
    public class CTB_HR_ASSESS_STAFF_DETAILPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        HRDataSetTableAdapters.TableAdapterManager _myTAM;

        public CTB_HR_ASSESS_STAFF_DETAILPO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_HR_ASSESS_STAFFDETAILTableAdapter = new HRDataSetTableAdapters.TB_HR_ASSESS_STAFFDETAILTableAdapter();
            _myTAM.TB_HR_ASSESS_STAFFDETAILTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }

        public void DeletebyReject(string p_GUID)
        {
            string cmdTxt = @"delete from TB_HR_ASSESS_STAFFDETAIL where GUID = '" + p_GUID + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public void Delete(string p_DEL_GUID, string p_GUID)
        {
            string cmdTxt = @"delete from TB_HR_ASSESS_STAFFDETAIL where DEL_GUID='" + p_DEL_GUID + "' and GUID = '" + p_GUID + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public DataTable getDatsByID(DataTable p_dt, string p_DEL_GUID, string p_GUID)
        {
            string cmdTxt = @"select * from TB_HR_ASSESS_STAFFDETAIL where DEL_GUID='" + p_DEL_GUID + "' and GUID = '" + p_GUID + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public void updateGUID(string p_GUID,string p_SMID,string p_type,string p_year)
        {
            string cmdTxt = @"update TB_HR_ASSESS_STAFFDETAIL set GUID ='" + p_GUID + "'";
            cmdTxt += @" where SMID = '" + p_SMID + "'";
            cmdTxt += @" and ASSESS_TYPE ='" + p_type + "'";
            cmdTxt += @" and YEAR = '" + p_year + "'";
            
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public void Update(HRDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public DataTable if_ditto(DataTable p_dt, string p_SMID, string p_type, string p_year)
        {
            string cmdTxt = @" select * from TB_HR_ASSESS_STAFFDETAIL";
            cmdTxt += @" where SMID = '" + p_SMID + "'";
            cmdTxt += @" and ASSESS_TYPE ='" + p_type + "'";
            cmdTxt += @" and YEAR = '" + p_year + "'";
            cmdTxt += @" order by Num  ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            return p_dt;
        }

        public void DeletebySMID(string p_SMID, string p_type, string p_year)
        {
            string cmdTxt = @"delete from TB_HR_ASSESS_STAFFDETAIL where SMID='" + p_SMID + "' and ASSESS_TYPE = '" + p_type + "' and YEAR = '" + p_year + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }


    }
}
