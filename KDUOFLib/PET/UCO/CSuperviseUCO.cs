using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KDUOFLib.PET.PO;
using System.Web;

namespace KDUOFLib.PET.UCO
{
    public class CSuperviseUCO
    {
        private PETDataSet PETDS = new PETDataSet();
        private CSupervisePO _CSupervisePO = null;
        private CSupervisePO CSupervisePO
        {
            get
            {
                if (_CSupervisePO == null)
                    _CSupervisePO = new CSupervisePO();
                return _CSupervisePO;
            }
        }

        public DataTable QuerySuperviseDatas()
        {
            PETDS.TB_PET_SUPERVISE.Clear();
            CSupervisePO.QueryDatas(PETDS.TB_PET_SUPERVISE);
            return PETDS.TB_PET_SUPERVISE;
        }
        public bool QuerySuperviseDatasByID(string id)
        {
            DataTable dt = new DataTable();
            CSupervisePO.QuerySuperviseDatasByID(dt, id);

            if (dt.Rows.Count <= 0)
            {
                return false;
            }
            return true;
        }

        //public void InsertSuperviseData(DataRow row)
        //{
        //     CSupervisePO.InsertData(row);
        //}
        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            CSupervisePO.Update(PETDS);
        }

        public void Update(DataRow row)
        {
            CSupervisePO.Update(PETDS);
        }

        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                PETDS.TB_PET_SUPERVISE.Rows.Add(row);
            CSupervisePO.Update(PETDS);
        }
    }
}
