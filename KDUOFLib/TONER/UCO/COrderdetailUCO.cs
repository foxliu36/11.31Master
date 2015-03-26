using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.TONER.PO;
using System.Data;

namespace KDUOFLib.TONER.UCO
{
    public class COrderdetailUCO
    {
        private TONERDataSet TONER = new TONERDataSet();
        private COrderdetailPO _COrderdetailPO = null;
        private COrderdetailPO COrderdetailPO
        {
            get
            {
                if (_COrderdetailPO == null)
                    _COrderdetailPO = new COrderdetailPO();
                return _COrderdetailPO;
            }
        }
        public DataRow NewRow()
        {
            return TONER.TB_TONER_ORDERDETAIL.NewRow();
        }
        public void Update(DataRow row)
        {
            this.COrderdetailPO.Update(TONER);
        }
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                TONER.TB_TONER_ORDERDETAIL.Rows.Add(row);
            this.COrderdetailPO.Update(TONER);
        }
        //public void Delete(DataRow row)
        //{
        //    if (row.RowState != DataRowState.Deleted)
        //        row.Delete();
        //    this.COrderdetailPO.Update(TONER);
        //}

        public void Delete(string orderno)
        {
            this.COrderdetailPO.Delete(orderno);
        }

    }
}
