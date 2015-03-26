using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

namespace KDUOFLib.HR.UCO
{
    public class WORKTIMEUCO
    {
        private HRDataSet HR = new HRDataSet();
        private WORKTIMEPO _WORKTIMEPO = null;

        private WORKTIMEPO WORKTIMEPO
        {
            get
            {
                if (_WORKTIMEPO == null)
                    _WORKTIMEPO = new WORKTIMEPO();
                return _WORKTIMEPO;
            }
        }

        public DataRow NewRow()
        {
            return HR.TB_HR_WORKTIME.NewRow();
        }

        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                HR.TB_HR_WORKTIME.Rows.Add(row);
            this.WORKTIMEPO.Update(HR);
        }

        public DataTable QueryParentGroupIDBySmid(string smid)
        {
            DataTable dt = new DataTable();
            this.WORKTIMEPO.QueryParentGroupIDBySmid(dt, smid);
            return dt;
        }
        public DataTable QueryBySmid(string smid)
        {
            DataTable dt = new DataTable();
            this.WORKTIMEPO.QueryBySmid(dt, smid);
            return dt;
        }
        public void Insert(DataRow[] rows)
        {
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].RowState != DataRowState.Added)
                    HR.TB_HR_WORKTIME.Rows.Add(rows[i]);
            }
            this.WORKTIMEPO.Update(HR);
        }

        public DataTable getDatasByAccountReport(string creatBdate, string creatEdate, string brandid, string smid)
        {
            DataTable dt = new DataTable();
            this.WORKTIMEPO.getDatasByAccountReport(dt, creatBdate, creatEdate, brandid, smid);
            return dt;
        }

        public void del(string UID)
        {
            DataTable dt = new DataTable();
            this.WORKTIMEPO.DelByUID(dt,UID);
        }

    }
}
