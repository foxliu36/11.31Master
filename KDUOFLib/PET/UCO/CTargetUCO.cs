using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.PET.PO;
using System.Data;

namespace KDUOFLib.PET.UCO
{
    public class CTargetUCO
    {
        private PETDataSet PETDS=new PETDataSet();
        private CTargetPO _CTargetPO = null;
        private CTargetPO CTargetPO {
            get
            {
                if (_CTargetPO == null)
                    _CTargetPO = new CTargetPO();
                return _CTargetPO;
            }
        }

        public DataTable QueryTargetDatas()
        {
            PETDS.TB_PET_TARGET.Clear();
             CTargetPO.QueryDatas(PETDS.TB_PET_TARGET);
             return PETDS.TB_PET_TARGET;
        }

        public DataTable QueryTargetDatasByReport()
        {
            DataTable dt = new DataTable();
            CTargetPO.QueryTargetDatasByReport(dt);
            return dt;
        }
        public DataTable QueryTargetDatasByReportForBranch(string group_name)
        {
            DataTable dt = new DataTable();
            CTargetPO.QueryTargetDatasByReportForBranch(dt, group_name);
            return dt;
        }
        public DataTable QueryTargetDatasByReportForSec(string group_id)
        {
            DataTable dt = new DataTable();
            CTargetPO.QueryTargetDatasByReportForSec(dt, group_id);
            return dt;
        }
        //public void InsertTargetData(DataRow row)
        //{
        //     CTargetPO.InsertData(row);
        //}
        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            CTargetPO.Update(PETDS);
        }

        public void Update(DataRow row)
        {
            CTargetPO.Update(PETDS);
        }

        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                PETDS.TB_PET_TARGET.Rows.Add(row);
            CTargetPO.Update(PETDS);
        }
    }
}
