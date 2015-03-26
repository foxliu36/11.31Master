using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KDUOFLib.PET.PO;
using System.Web;

namespace KDUOFLib.PET.UCO
{
    public class CAgreeUCO
    {
        private PETDataSet PETDS = new PETDataSet();
        private CAgreePO _CAgreePO = null;
        private CAgreePO CAgreePO
        {
            get
            {
                if (_CAgreePO == null)
                    _CAgreePO = new CAgreePO();
                return _CAgreePO;
            }
        }

        //public DataTable QueryAgreeDatas()
        //{
        //    PETDS.TB_PET_AGREE.Clear();
        //    CAgreePO.QueryDatas(PETDS.TB_PET_AGREE);
        //    return PETDS.TB_PET_AGREE;
        //}

        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            CAgreePO.Update(PETDS);
        }

        public void Update(DataRow row)
        {
            CAgreePO.Update(PETDS);
        }

        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                PETDS.TB_PET_AGREE.Rows.Add(row);
            CAgreePO.Update(PETDS);
        }
        public DataTable QueryDatasByConditions(string txtORDERNO, string txtNO)
        {
            PETDS.TB_PET_AGREE.Clear();
            //DataTable dt = new DataTable();
            //CAgreePO.QueryDatasByConditions(dt, txtORDERNO, txtNO);
            CAgreePO.QueryDatasByConditions(PETDS.TB_PET_AGREE, txtORDERNO, txtNO);
            //return dt;
            return PETDS.TB_PET_AGREE;
        }
        public DataTable QueryDatasByInsert(string txtORDERNO)
        {
            //PETDS.TB_PET_AGREE.Clear();
            DataTable dt = new DataTable();
            CAgreePO.QueryDatasByInsert(dt, txtORDERNO);
            //return PETDS.TB_PET_AGREE;
            return dt;
        }
        
        #region Print
        public DataTable QueryDatasByAgreePrint(string licenseno, string orderno, string name)
        {
            DataTable dt = new DataTable();
            CAgreePO.QueryDatasByAgreePrint(licenseno, orderno, name, dt);
            return dt;
        }
        #endregion  
    }
}
