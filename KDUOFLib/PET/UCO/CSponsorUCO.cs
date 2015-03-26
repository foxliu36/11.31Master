using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KDUOFLib.PET.PO;
using System.Web;

namespace KDUOFLib.PET.UCO
{
    public class CSponsorUCO
    {
        private PETDataSet PETDS = new PETDataSet();
        private CSponsorPO _CSponsorPO = null;
        private CSponsorPO CSponsorPO
        {
            get
            {
                if (_CSponsorPO == null)
                    _CSponsorPO = new CSponsorPO();
                return _CSponsorPO;
            }
        }
        public DataRow NewRow()
        {
            return PETDS.TB_PET_SPONSOR.NewRow();
        }

        public DataTable QuerySponsorDatas(string No)
        {
            PETDS.TB_PET_SPONSOR.Clear();
            if (string.IsNullOrEmpty(No))
            {
                return  PETDS.TB_PET_SPONSOR;
            }
            CSponsorPO.QueryDatas(No, PETDS.TB_PET_SPONSOR);
            return PETDS.TB_PET_SPONSOR;
        }

        //public void InsertSponsorData(DataRow row)
        //{
        //     CSponsorPO.InsertData(row);
        //}
        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            CSponsorPO.Update(PETDS);
        }

        public void Update(DataRow row)
        {
            CSponsorPO.Update(PETDS);
        }

        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                PETDS.TB_PET_SPONSOR.Rows.Add(row);
            CSponsorPO.Update(PETDS);
        }
    }
}
