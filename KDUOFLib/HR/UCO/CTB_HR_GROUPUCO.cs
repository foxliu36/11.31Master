using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

namespace KDUOFLib.HR.UCO
{
    public class CTB_HR_GROUPUCO
    {
        private HRDataSet HR = new HRDataSet();
        private CTB_HR_GROUPPO _CTB_HR_GROUPPO = null;
        private CTB_HR_GROUPPO CTB_HR_GROUPPO
        {
            get
            {
                if (_CTB_HR_GROUPPO == null)
                    _CTB_HR_GROUPPO = new CTB_HR_GROUPPO();
                return _CTB_HR_GROUPPO;
            }
        }

        public DataRow NewRow()
        {
            return HR.TB_EB_GROUP.NewRow();
        }

        public DataTable getDatsByID(string p_GroupID)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_GROUPPO.getDatsByID(l_dt, p_GroupID);
        }

        public string getstringByID(string p_GroupID)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_GROUPPO.getstringByID(l_dt, p_GroupID);
        }

        public string getSMIDbyType(string p_GroupID, string p_Type)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_GROUPPO.getSMIDbyType(l_dt, p_GroupID, p_Type);
        }

        public double amount(string p_GroupID)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_GROUPPO.amount(l_dt, p_GroupID);
        }

        public bool Post(string p_SMID,string p_post)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_GROUPPO.Post(l_dt, p_SMID, p_post);
        }

        # region 2013考核
        public string getGroupIDbySMID(string p_SMID, string p_Group_Name, string p_LEV)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_GROUPPO.getGroupIDbySMID(l_dt, p_SMID, p_Group_Name, p_LEV);
        }

        public string getAllGroupByID(string p_GroupID, string p_LEV)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_GROUPPO.getAllGroupByID(l_dt, p_GroupID, p_LEV);
        }

        public DataTable getDats(string p_Branch, string p_TITLE_NAME, string p_FUNC_NAME, string p_GroupID, string p_userName, bool p_SameGroup, string p_NotGroupID)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_GROUPPO.getDats(l_dt, p_Branch, p_TITLE_NAME, p_FUNC_NAME, p_GroupID, p_userName, p_SameGroup, p_NotGroupID);
        }

        public DataTable DoubleBranch(string p_Branch, string p_Branch2, string p_TITLE_NAME, string p_TITLE_NAME2, string p_FUNC_NAME, string p_FUNC_NAME2)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_GROUPPO.DoubleBranch(l_dt, p_Branch, p_Branch2, p_TITLE_NAME, p_TITLE_NAME2, p_FUNC_NAME, p_FUNC_NAME2);
        }

        public DataTable getSpecialDats(string p_ACCOUNT, string p_FUNC_NAME,string p_GroupName)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_GROUPPO.getSpecialDats(l_dt, p_ACCOUNT, p_FUNC_NAME, p_GroupName);
        }

        public DataTable getDatsbyStaff(string p_Branch, string p_SMID, string p_FUNC_NAME)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_GROUPPO.getDatsbyStaff(l_dt, p_Branch, p_SMID, p_FUNC_NAME);
        }

        # endregion

        # region 員介車抓單位名稱
        public string getGroupNamebySMID(string SMID)
        {
            DataTable dt = new DataTable();
            return this.CTB_HR_GROUPPO.getGroupNamebySMID(dt, SMID);
        }

        public string getNamebySMID(string SMID)
        {
            DataTable dt = new DataTable();
            return this.CTB_HR_GROUPPO.getNamebySMID(dt, SMID);
        }

        # endregion

    }
}
