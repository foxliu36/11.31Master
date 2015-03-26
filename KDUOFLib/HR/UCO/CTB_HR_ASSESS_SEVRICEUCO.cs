using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

namespace KDUOFLib.HR.UCO
{
    public class CTB_HR_ASSESS_SEVRICEUCO
    {
        private HRDataSet HR = new HRDataSet();
        private CTB_HR_ASSESS_SERVICEPO _CTB_HR_ASSESS_SERVICEPO = null;
        private CTB_HR_ASSESS_SERVICEPO CTB_HR_ASSESS_SERVICEPO
        {
            get
            {
                if (_CTB_HR_ASSESS_SERVICEPO == null)
                    _CTB_HR_ASSESS_SERVICEPO = new CTB_HR_ASSESS_SERVICEPO();
                return _CTB_HR_ASSESS_SERVICEPO;
            }
        }

        public DataRow NewRow()
        {
            return HR.TB_HR_ASSESS_SERVICE.NewRow();
        }
        public void Update(DataRow row)
        {
            this.CTB_HR_ASSESS_SERVICEPO.Update(HR);
        }
        public void UpdateByTASKID(DataRow row)
        {
            this.CTB_HR_ASSESS_SERVICEPO.UpdateByTASKID(row);
        }
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                HR.TB_HR_ASSESS_SERVICE.Rows.Add(row);
            this.CTB_HR_ASSESS_SERVICEPO.Update(HR);
        }
        public void DeletebyReject(string taskid)
        {
            this.CTB_HR_ASSESS_SERVICEPO.DeletebyReject(taskid);
        }
        public void Delete(string taskid, string p_siteCode)
        {
            this.CTB_HR_ASSESS_SERVICEPO.Delete(taskid, p_siteCode);
        }

        public DataTable getDatsByID(string ACCOUNT, string p_siteCode,string TASK_ID)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getDatsByID(l_dt, ACCOUNT, p_siteCode, TASK_ID);
        }

        public DataTable getDatabyString(string p_Branch)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getDatabyString(l_dt, p_Branch);
        }

        #region 2013考核
        public DataTable getDatabyEngine(string p_Branch)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getDatabyEngine(l_dt, p_Branch);
        }

        public DataTable getDatabylacquer(string p_Branch)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getDatabylacquer(l_dt, p_Branch);
        }

        public DataTable getDatabyParts(string p_Branch)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getDatabyParts(l_dt, p_Branch);
        }

        public DataTable getDatabyOther(string p_Branch)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getDatabyOther(l_dt, p_Branch);
        }

        public DataTable getDatabyPDS(string p_Branch)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getDatabyPDS(l_dt, p_Branch);
        }

        public DataTable getDatabyService(string p_Branch)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getDatabyService(l_dt, p_Branch);
        }

        public DataTable getDatabyBranch(string p_Branch)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getDatabyBranch(l_dt, p_Branch);
        }
        public DataTable getDataforSevrice(string p_TYPE, string p_GruopName, bool boPost, string p_ASSESS_TYPE, string p_year)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getDataforSevrice(l_dt, p_TYPE, p_GruopName, boPost, p_ASSESS_TYPE,p_year);
        }
        public DataTable getSingerforSevrice(string p_TYPE)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getSingerforSevrice(l_dt, p_TYPE);
        }

        public DataTable Sevrice_Type(string p_Branch,string p_SMID)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.Sevrice_Type(l_dt, p_Branch, p_SMID);
        }

        public DataTable detail_dailog(string p_SITE_CODE, string p_FUNC_NAME, string p_GROUP_NAME, string p_ASSESS_TYPE, string p_year)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.detail_dailog(l_dt, p_SITE_CODE, p_FUNC_NAME, p_GROUP_NAME, p_ASSESS_TYPE,p_year);
        }
        public DataTable detail_dailogforSinger(string p_FUNC_NAME, string p_GROUP_NAME, string p_ASSESS_TYPE, string p_year)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.detail_dailogforSinger(l_dt, p_FUNC_NAME, p_GROUP_NAME, p_ASSESS_TYPE,p_year);
        }

        public DataTable getdatail(string p_Bdate, string p_Edate, string p_smid, string p_GruopID, string p_GUID, string p_type)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getdatail(l_dt, p_Bdate, p_Edate, p_smid, p_GruopID, p_GUID, p_type);
        }
        #endregion

        #region 2013新考核架構
        public DataTable getDatabyHead(string p_Branch)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getDatabyHead(l_dt, p_Branch);
        }

        #endregion

        #region 宏偉製表用
        public DataTable getUserByGroupID(string p_GroupID, string p_smid)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getUserByGroupID(l_dt, p_GroupID, p_smid);
        }
        public DataTable getUserByGroupIDBy所廠(string p_GroupID, string p_smid)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getUserByGroupIDBy所廠(l_dt, p_GroupID, p_smid);
        }
        public DataTable getUserByGroupIDByPrint(string p_GroupID)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getUserByGroupIDByPrint(l_dt, p_GroupID);
        }
        public DataTable getUserByGroupIDByPrint所廠(string p_GroupID)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_ASSESS_SERVICEPO.getUserByGroupIDByPrint所廠(l_dt, p_GroupID);
        }
        #endregion
    }
}
