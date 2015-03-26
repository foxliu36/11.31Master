using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.REW.PO;
using System.Data;

namespace KDUOFLib.REW.UCO
{
    public class CTB_REW_StaffPresentCarUCO
    {
        private REWDataSet REW = new REWDataSet();
        private CTB_REW_StaffPresentCar_PO _CTB_REW_StaffPresentCar_PO = null;
        private CTB_REW_StaffPresentCar_PO CTB_REW_StaffPresentCar_PO
        {
            get
            {
                if (_CTB_REW_StaffPresentCar_PO == null)
                    _CTB_REW_StaffPresentCar_PO = new CTB_REW_StaffPresentCar_PO();
                return _CTB_REW_StaffPresentCar_PO;
            }
        }

        public DataRow NewRow()
        {
            return REW.TB_REW_StaffPresentCar.NewRow();
        }

        public void Delete(string OrderNo)
        {
            this.CTB_REW_StaffPresentCar_PO.Delete(OrderNo);
        }

        public void Update(DataRow row)
        {
            this.CTB_REW_StaffPresentCar_PO.Update(REW);
        }

        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                REW.TB_REW_StaffPresentCar.Rows.Add(row);
            this.CTB_REW_StaffPresentCar_PO.Update(REW);
        }

        public DataTable HaveData(string OrderNo)
        {
            DataTable dt = new DataTable();
            return this.CTB_REW_StaffPresentCar_PO.HaveData(dt, OrderNo);
        }

        public DataTable getData(string SDate, string EDate, string PresentUnit, string Unit, string PresentAccount, string StaffAccount, string OrderNo, string Plate)
        {
            DataTable dt = new DataTable();
            return this.CTB_REW_StaffPresentCar_PO.getData(dt, SDate, EDate, PresentUnit, Unit, PresentAccount, StaffAccount, OrderNo, Plate);
        }

        public void UpdatebyManager(DataRow row)
        {
            this.CTB_REW_StaffPresentCar_PO.UpdatebyManager(row);
        }

    }
}
