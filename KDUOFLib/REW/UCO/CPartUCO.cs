using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.REW.PO;
using System.Data;

namespace KDUOFLib.REW.UCO
{
    public class CPartUCO
    {
        private REWDataSet REWDS = new REWDataSet();
        private CPartPO _CPartPO = null;

        private CPartPO CPartPO
        {
            get
            {
                if (_CPartPO == null)
                    _CPartPO = new CPartPO();
                return _CPartPO;
            }
        }

        public DataTable QueryPartDatas()
        {
            REWDS.TB_REW_PART.Clear();
            this.CPartPO.QueryDatas(REWDS.TB_REW_PART);
            return REWDS.TB_REW_PART;
        }
        public void DeletePartDatasByOrderNo(string ORDERNO)
        {
            this.CPartPO.DeletePartDatasByOrderNo(ORDERNO);
        }
        
        public DataTable QueryPartDatasByOrderNo(string ORDERNO)
        {
            REWDS.TB_REW_PART.Clear();
            this.CPartPO.QueryPartDatasByOrderNo(REWDS.TB_REW_PART, ORDERNO);
            return REWDS.TB_REW_PART;
        }

        public void Update(DataRow row)
        {
            this.CPartPO.Update(REWDS);
        }
        public void Update()
        {
            this.CPartPO.Update(REWDS);
        }

        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                REWDS.TB_REW_PART.Rows.Add(row);
            this.CPartPO.Update(REWDS);
        }

        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            this.CPartPO.Update(REWDS);
        }

        public DataTable QueryAllKDParts()
        {
            return this.CPartPO.QueryAllKDParts();
        }
        public DataTable QueryKDParts(string keyStr)
        {
            return this.CPartPO.QueryKDParts(keyStr);
        }
        public DataTable QueryKDPartsByOrderno(string orderno)
        {
            return this.CPartPO.QueryKDPartsByOrderno(orderno);
        }
        
        public DataTable GetEmptyPartTable()
        {
            REWDS.TB_REW_PART.Clear();
            return REWDS.TB_REW_PART;
        }
    }
}
