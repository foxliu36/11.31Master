using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.REW.PO;
using System.Data;

namespace KDUOFLib.REW.UCO
{
    public class CSaleDocUCO
    {
        private REWDataSet REWDS = new REWDataSet();
        private CSaleDocPO _CSaleDocPO = null;


        private CSaleDocPO CSaleDocPO
        {
            get
            {
                if (_CSaleDocPO == null)
                    _CSaleDocPO = new CSaleDocPO();
                return _CSaleDocPO;
            }
        }

        public DataRow NewRow()
        {
            return REWDS.TB_REW_SALEDOC.NewRow();
        }
        public void Update(DataRow row)
        {
            this.CSaleDocPO.Update(REWDS);
        }

        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                REWDS.TB_REW_SALEDOC.Rows.Add(row);
            this.CSaleDocPO.Update(REWDS);
        }

        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            this.CSaleDocPO.Update(REWDS);
        }
        public void DeleteByOrderno(string orderno)
        {
            this.CSaleDocPO.DeleteByOrderno(orderno);
        }

        
        public DataTable QueryCSaleDocDatas(string Orderno)
        {
            REWDS.TB_REW_SALEDOC.Clear();
            this.CSaleDocPO.QuerySALEDOCSpecialsaleDataByOrderno(REWDS.TB_REW_SALEDOC, Orderno);
            return REWDS.TB_REW_SALEDOC;
        }

        public DataTable QuerySALEDOCByREWAdmin(string saledBdate, string saledEdate, string orderno, string branchId, string status, string saleBDay, string saleEDay, string smid, string insurance, string bigtype, string specialtype, string carcod)
        {
            DataTable dt = new DataTable();
            this.CSaleDocPO.QuerySALEDOCByREWAdmin(dt, saledBdate, saledEdate, orderno, branchId, status, saleBDay, saleEDay, smid, insurance, bigtype, specialtype, carcod);
            return dt;
        }
        public DataTable QuerySALEDOCByREWARDDialog(string orderno)
        {
            DataTable dt = new DataTable();
            this.CSaleDocPO.QuerySALEDOCByREWARDDialog(dt, orderno);
            return dt;
        }

        public void UpdateByAfterReward(string orderno,int status)
        {
            this.CSaleDocPO.UpdateByAfterReward(orderno, status);
        }
    }
}
