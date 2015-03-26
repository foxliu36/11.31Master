using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.TONER.PO;
using System.Data;

namespace KDUOFLib.TONER.UCO
{
    public class COrderUCO
    {
        private TONERDataSet TONER = new TONERDataSet();
        private COrderPO _COrderPO = null;
        private COrderPO COrderPO
        {
            get
            {
                if (_COrderPO == null)
                    _COrderPO = new COrderPO();
                return _COrderPO;
            }
        }

        public DataRow NewRow()
        {
            return TONER.TB_TONER_ORDER.NewRow();
        }
        public void Update(DataRow row)
        {
            this.COrderPO.Update(TONER);
        }
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                TONER.TB_TONER_ORDER.Rows.Add(row);
            this.COrderPO.Update(TONER);
        }
        //public void Delete(DataRow row)
        //{
        //    if (row.RowState != DataRowState.Deleted)
        //        row.Delete();
        //    this.COrderPO.Update(TONER);
        //}

        public void Delete(string orderno)
        {
            this.COrderPO.Delete(orderno);
        }

        public DataTable MonthQuery(string SDATE, string EDATE, string p_unit, string p_empid)
        {
            DataTable l_dt = new DataTable();
            COrderPO.MonthQuery(SDATE, EDATE, p_unit, p_empid, l_dt);
            return l_dt;
        }

        public DataTable DateQuery(string p_orderno,string SDATE, string EDATE, string p_unit, string p_empid)
        {
            DataTable l_dt = new DataTable();
            COrderPO.DateQuery(p_orderno, SDATE, EDATE, p_unit, p_empid, l_dt);
            return l_dt;
        }

        public DataTable IflowQuery(string p_companyid, string SDATE, string EDATE, string p_unit)
        {
            DataTable l_dt = new DataTable();
            COrderPO.IflowQuery(p_companyid, SDATE, EDATE, p_unit, l_dt);
            return l_dt;
        }

        public DataTable PlanningQuery( string p_unit, string p_empid, string p_companyid)
        {
            DataTable l_dt = new DataTable();
            COrderPO.PlanningQuery(p_unit,p_empid, p_companyid, l_dt);
            return l_dt;
        }

    }
}
